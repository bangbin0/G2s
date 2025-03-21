using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using Newtonsoft.Json;
using System.IO;
using System.Data.SQLite;
using Sunny.UI;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace G2S
{
    public partial class Form1 : UIForm
    {
        private Form2 form2 = new Form2();
        private bool isProcessing = false;
        private CancellationTokenSource cancellationTokenSource;
        private UIProcessBar processBar;
        private Dictionary<string, string> adjustSqlConfigs = new Dictionary<string, string>();
        private string currentAdjustSQL = "";
        private string currentAdjustConfigPath = "adjustconfig.sql";

        public Form1()
        {
            InitializeComponent();
            InitializeProcessBar();
        }

        private void InitializeProcessBar()
        {
            processBar = new UIProcessBar();
            processBar.Visible = false;
            processBar.Size = new Size(300, 23);
            processBar.Location = new Point(
                (this.ClientSize.Width - processBar.Width) / 2,
                StartBtn.Location.Y + StartBtn.Height + 10);
            this.Controls.Add(processBar);
        }

        private void AddSQlBtn_Click(object sender, EventArgs e)
        {
            form2.Show();
        }

        private void ZB_pathBTN_Click(object sender, EventArgs e)
        {
            // 创建 OpenFileDialog 实例
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 设置文件类型过滤器，只显示 zip 文件
                openFileDialog.Filter = "ZIP Files (*.zip)|*.zip";

                // 弹出文件选择对话框
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 将选择的文件路径显示到文本框
                    ZB_path.Text = openFileDialog.FileName;
                }
            }
        }

        private void TargetPathBtn_Click(object sender, EventArgs e)
        {
            // 创建 FolderBrowserDialog 实例
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                // 设置初始目录（可选）
                folderDialog.SelectedPath = @"C:\";

                // 弹出文件夹选择对话框
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // 将选择的目录路径显示到文本框
                    TargetPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            if (isProcessing)
            {
                if (MessageBox.Show("是否取消当前处理？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cancellationTokenSource?.Cancel();
                }
                return;
            }

            if (string.IsNullOrEmpty(ZB_path.Text) || string.IsNullOrEmpty(TargetPath.Text))
            {
                MessageBox.Show("请选择总包文件和目标路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(ZB_path.Text))
            {
                MessageBox.Show("总包文件不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var totalStopwatch = new Stopwatch();
            totalStopwatch.Start();

            try
            {
                isProcessing = true;
                StartBtn.Text = "取消处理";
                StartBtn.Symbol = 61453;
                AddSQlBtn.Enabled = false;
                ZB_pathBTN.Enabled = false;
                TargetPathBtn.Enabled = false;
                processBar.Visible = true;
                processBar.Value = 0;

                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;

                string configPath = "sqlconfig.json";
                if (!File.Exists(configPath))
                {
                    MessageBox.Show("未找到分包配置文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string json = await Task.Run(() => File.ReadAllText(configPath));
                var config = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                
                var sqlConfigs = JsonConvert.DeserializeObject<Dictionary<string, string>>(config["sqlConfigs"].ToString());
                var packageStates = JsonConvert.DeserializeObject<Dictionary<string, bool>>(config["packageStates"].ToString());

                if (sqlConfigs.Count == 0)
                {
                    MessageBox.Show("没有分包配置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var enabledPackages = sqlConfigs.Keys.Where(k => packageStates.ContainsKey(k) && packageStates[k]).ToList();
                if (enabledPackages.Count == 0)
                {
                    MessageBox.Show("没有启用的分包配置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 创建工作目录
                string workDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(workDir);

                try
                {
                    // 从总包中提取数据库文件
                    UpdateLog("正在从总包中提取数据库文件...\n");
                    string originalDbPath = Path.Combine(workDir, "original_beida_soft.db");
                    
                    await Task.Run(() =>
                    {
                        using (var archive = ZipFile.OpenRead(ZB_path.Text))
                        {
                            var dbEntry = archive.GetEntry("databases/beida_soft.db");
                            if (dbEntry == null)
                            {
                                throw new FileNotFoundException("在总包中未找到数据库文件：databases/beida_soft.db");
                            }

                            // 使用缓冲流复制文件
                            using (var source = dbEntry.Open())
                            using (var destination = File.Create(originalDbPath))
                            {
                                CopyStream(source, destination, token);
                            }
                        }
                    }, token);

                    int totalSteps = enabledPackages.Count;
                    int currentStep = 0;

                    // 创建并行处理选项
                    var parallelOptions = new ParallelOptions
                    {
                        MaxDegreeOfParallelism = Math.Min(Environment.ProcessorCount, 4),
                        CancellationToken = token
                    };

                    // 并行处理每个分包
                    await Task.Run(() => Parallel.ForEach(enabledPackages, parallelOptions, (packageName) =>
                    {
                        var packageStopwatch = new Stopwatch();
                        packageStopwatch.Start();

                        try
                        {
                            string sql = sqlConfigs[packageName];
                            UpdateLog($"正在处理分包：{packageName}\n");

                            // 为当前分包创建数据库副本
                            string currentDbPath = Path.Combine(workDir, $"beida_soft_{packageName}.db");
                            
                            // 使用文件流复制数据库
                            using (var source = File.OpenRead(originalDbPath))
                            using (var destination = File.Create(currentDbPath))
                            {
                                CopyStream(source, destination, token);
                            }

                            UpdateLog($"正在执行SQL...\n");
                            // 优化SQLite连接字符串，最大化性能参数
                            var connectionStringBuilder = new SQLiteConnectionStringBuilder
                            {
                                DataSource = currentDbPath,
                                Version = 3,
                                CacheSize = -10000,  // 约10MB缓存，设置为负值表示使用KB为单位
                                JournalMode = SQLiteJournalModeEnum.Memory,  // 日志放在内存中
                                Pooling = true,
                                SyncMode = SynchronizationModes.Off,  // 关闭同步模式
                                PageSize = 32768,    // 增加页面大小到32KB
                                DefaultTimeout = 300, // 增加超时时间到5分钟
                                ReadOnly = false,
                                BusyTimeout = 30000, // 繁忙时等待30秒
                            };

                            using (var connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
                            {
                                connection.Open();
                                
                                // 设置一些性能优化的PRAGMA
                                using (var cmd = new SQLiteCommand(connection))
                                {
                                    cmd.CommandText = @"
                                        PRAGMA temp_store = MEMORY;
                                        PRAGMA mmap_size = 1099511627776;  -- 1TB
                                        PRAGMA page_size = 32768;
                                        PRAGMA cache_size = -10000;
                                        PRAGMA journal_mode = MEMORY;
                                        PRAGMA synchronous = OFF;
                                        PRAGMA foreign_keys = OFF;
                                        PRAGMA count_changes = 0;
                                        PRAGMA locking_mode = NORMAL;
                                        PRAGMA secure_delete = OFF;
                                    ";
                                    cmd.ExecuteNonQuery();
                                }
                                
                                // 预先处理SQL语句
                                var sqlStatements = sql.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(s => s.Trim())
                                                      .Where(s => !string.IsNullOrEmpty(s))
                                                      .ToList();

                                // 使用单个事务执行所有SQL
                                using (var transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))  // 使用最低隔离级别
                                {
                                    try
                                    {
                                        // 预编译所有SQL语句
                                        var commands = new List<SQLiteCommand>();
                                        foreach (var sqlStatement in sqlStatements)
                                        {
                                            token.ThrowIfCancellationRequested();
                                            var command = new SQLiteCommand(sqlStatement, connection, transaction);
                                            command.CommandTimeout = 0; // 无超时限制
                                            commands.Add(command);
                                        }

                                        // 批量执行
                                        foreach (var command in commands)
                                        {
                                            token.ThrowIfCancellationRequested();
                                            command.ExecuteNonQuery();
                                        }

                                        // 清理命令
                                        foreach (var command in commands)
                                        {
                                            command.Dispose();
                                        }

                                        transaction.Commit();
                                    }
                                    catch
                                    {
                                        transaction.Rollback();
                                        throw;
                                    }
                                }

                                // 在关闭连接前执行VACUUM以优化数据库文件
                                using (var cmd = new SQLiteCommand("VACUUM;", connection))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 创建新的zip文件
                            string zipFileName = Path.GetFileNameWithoutExtension(ZB_path.Text);
                            string targetDir = TargetPath.Text;
                            string newZipName = ReplacePackageName(zipFileName, packageName);
                            string newZipPath = Path.Combine(targetDir, newZipName + ".zip");

                            if (File.Exists(newZipPath))
                            {
                                File.Delete(newZipPath);
                            }

                            // 使用流式处理创建新的压缩包
                            using (var sourceArchive = ZipFile.OpenRead(ZB_path.Text))
                            using (var destArchive = ZipFile.Open(newZipPath, ZipArchiveMode.Create))
                            {
                                foreach (var entry in sourceArchive.Entries)
                                {
                                    token.ThrowIfCancellationRequested();

                                    var newEntry = destArchive.CreateEntry(entry.FullName, CompressionLevel.Optimal);
                                    
                                    // 使用缓冲流复制文件内容
                                    using (var sourceStream = entry.Open())
                                    using (var destStream = newEntry.Open())
                                    {
                                        if (entry.FullName.Equals("databases/beida_soft.db", StringComparison.OrdinalIgnoreCase))
                                        {
                                            // 如果是数据库文件，使用处理后的数据库
                                            using (var dbFileStream = File.OpenRead(currentDbPath))
                                            {
                                                CopyStream(dbFileStream, destStream, token);
                                            }
                                        }
                                        else
                                        {
                                            // 其他文件直接复制
                                            CopyStream(sourceStream, destStream, token);
                                        }
                                    }
                                }
                            }

                            UpdateLog($"分包 {packageName} 处理完成，用时：{packageStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}\n");
                            Interlocked.Increment(ref currentStep);
                            UpdateProgress((int)((double)currentStep / totalSteps * 100));
                        }
                        catch (OperationCanceledException)
                        {
                            UpdateLog($"处理分包 {packageName} 时被用户取消\n");
                            throw;
                        }
                        catch (Exception ex)
                        {
                            UpdateLog($"处理分包 {packageName} 时出错：{ex.Message}\n");
                            throw;
                        }
                        finally
                        {
                            // 及时删除临时数据库文件
                            try
                            {
                                string currentDbPath = Path.Combine(workDir, $"beida_soft_{packageName}.db");
                                if (File.Exists(currentDbPath))
                                {
                                    File.Delete(currentDbPath);
                                }
                            }
                            catch { }
                        }
                    }));

                    if (!token.IsCancellationRequested)
                    {
                        totalStopwatch.Stop();
                        MessageBox.Show($"分包生成完成！\n总用时：{totalStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                finally
                {
                    // 清理工作目录
                    try
                    {
                        if (Directory.Exists(workDir))
                        {
                            Directory.Delete(workDir, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        UpdateLog($"清理临时文件时出错：{ex.Message}\n");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                totalStopwatch.Stop();
                MessageBox.Show($"操作已取消\n总用时：{totalStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                totalStopwatch.Stop();
                MessageBox.Show($"生成分包时出错：{ex.Message}\n总用时：{totalStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateLog($"错误：{ex.Message}\n");
            }
            finally
            {
                if (totalStopwatch.IsRunning)
                {
                    totalStopwatch.Stop();
                }
                UpdateLog($"总用时：{totalStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}\n");
                
                isProcessing = false;
                StartBtn.Text = "开始生成";
                StartBtn.Symbol = 61452;
                AddSQlBtn.Enabled = true;
                ZB_pathBTN.Enabled = true;
                TargetPathBtn.Enabled = true;
                processBar.Visible = false;
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        private void UpdateProgress(int value)
        {
            if (processBar.InvokeRequired)
            {
                processBar.Invoke(new Action(() => UpdateProgress(value)));
            }
            else
            {
                processBar.Value = value;
            }
        }

        private void UpdateLog(string message)
        {
            if (log.InvokeRequired)
            {
                log.Invoke(new Action(() => UpdateLog(message)));
            }
            else
            {
                log.AppendText(message);
                log.ScrollToCaret();
            }
        }

        private string ReplacePackageName(string originalName, string newName)
        {
            return System.Text.RegularExpressions.Regex.Replace(originalName, @"\(.*?\)", $"({newName})");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isProcessing)
            {
                if (MessageBox.Show("正在处理中，确定要退出吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                cancellationTokenSource?.Cancel();
            }
            base.OnFormClosing(e);
        }

        // 添加一个新的方法用于流式复制文件
        private void CopyStream(Stream source, Stream destination, CancellationToken token, int bufferSize = 81920)
        {
            byte[] buffer = new byte[bufferSize];
            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                token.ThrowIfCancellationRequested();
                destination.Write(buffer, 0, read);
            }
        }

        private async void ExecuteAdjustSql(string zipPath, string sql)
        {
            try
            {
                string workDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(workDir);

                using (var sourceArchive = ZipFile.OpenRead(zipPath))
                {
                    var dbEntry = sourceArchive.GetEntry("databases/beida_soft.db");
                    if (dbEntry == null)
                    {
                        UpdateP2Log($"在包 {Path.GetFileName(zipPath)} 中未找到数据库文件\n");
                        return;
                    }

                    string dbPath = Path.Combine(workDir, "beida_soft.db");
                    dbEntry.ExtractToFile(dbPath);

                    var connectionString = new SQLiteConnectionStringBuilder
                    {
                        DataSource = dbPath,
                        DefaultTimeout = 300,
                        SyncMode = SynchronizationModes.Off
                    }.ToString();

                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        await conn.OpenAsync();
                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                var commands = sql.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var cmdText in commands)
                                {
                                    using (var cmd = new SQLiteCommand(cmdText.Trim(), conn, transaction))
                                    {
                                        await cmd.ExecuteNonQueryAsync();
                                    }
                                }
                                transaction.Commit();
                                UpdateP2Log($"成功处理包：{Path.GetFileName(zipPath)}\n");
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }

                    // 更新压缩包中的数据库
                    using (var destArchive = new ZipArchive(File.Open(zipPath, FileMode.Open), ZipArchiveMode.Update))
                    {
                        var entry = destArchive.GetEntry("databases/beida_soft.db");
                        entry.Delete();
                        var newEntry = destArchive.CreateEntry("databases/beida_soft.db");
                        using (var stream = newEntry.Open())
                        using (var fileStream = File.OpenRead(dbPath))
                        {
                            await fileStream.CopyToAsync(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateP2Log($"处理包 {Path.GetFileName(zipPath)} 失败：{ex.Message}\n");
            }
        }

        private void UpdateP2Log(string message)
        {
            if (P2_Log.InvokeRequired)
            {
                P2_Log.Invoke(new Action(() => UpdateP2Log(message)));
            }
            else
            {
                P2_Log.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}");
                P2_Log.ScrollToCaret();
            }
        }

        // 选择zip包目录
        private void uiButton2_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    uiTextBox1.Text = folderDialog.SelectedPath;
                }
            }
        }

        // 设置SQL
        private void uiButton3_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            if (form4.ShowDialog() == DialogResult.OK)
            {
                currentAdjustSQL = form4.SqlContent;
                File.WriteAllText(currentAdjustConfigPath, currentAdjustSQL);
            }
        }

        // 执行调整（需要先在Designer中添加uiButton4控件）
        private async void uiButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBox1.Text) || !Directory.Exists(uiTextBox1.Text))
            {
                MessageBox.Show("请选择有效的ZIP包目录");
                return;
            }

            if (!File.Exists(currentAdjustConfigPath))
            {
                MessageBox.Show("请先设置调整SQL");
                return;
            }

            currentAdjustSQL = File.ReadAllText(currentAdjustConfigPath);

            var zipFiles = Directory.GetFiles(uiTextBox1.Text, "*.zip");
            foreach (var zipFile in zipFiles)
            {
                UpdateP2Log($"正在处理：{Path.GetFileName(zipFile)}...\n");
                await Task.Run(() => ExecuteAdjustSql(zipFile, currentAdjustSQL));
            }
            UpdateP2Log("所有调整操作已完成！\n");
        }

        // 添加新的执行方法
        private async void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBox1.Text) || !Directory.Exists(uiTextBox1.Text))
            {
                MessageBox.Show("请先选择包含数据包的目录");
                return;
            }

            if (!File.Exists(currentAdjustConfigPath))
            {
                MessageBox.Show("请先设置调整SQL");
                return;
            }

            try
            {
                currentAdjustSQL = File.ReadAllText(currentAdjustConfigPath);
                var zipFiles = Directory.GetFiles(uiTextBox1.Text, "*.zip");
                
                // 禁用按钮防止重复点击
                uiSymbolButton1.Enabled = false;
                UpdateP2Log("开始批量处理数据包...\n");

                foreach (var zipFile in zipFiles)
                {
                    try
                    {
                        UpdateP2Log($"正在处理：{Path.GetFileName(zipFile)}...");
                        await Task.Run(() => ExecuteAdjustSql(zipFile, currentAdjustSQL));
                        UpdateP2Log(" 完成\n");
                    }
                    catch (Exception ex)
                    {
                        UpdateP2Log($" 失败：{ex.Message}\n");
                    }
                }

                UpdateP2Log("所有数据包处理完成！\n");
            }
            finally
            {
                uiSymbolButton1.Enabled = true;
            }
        }
    }
}
