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

namespace G2S
{
    public partial class Form1 : UIForm
    {
        private Form2 form2 = new Form2();
        private bool isProcessing = false;
        private CancellationTokenSource cancellationTokenSource;
        private UIProcessBar processBar;

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

                // 获取启用的包数量
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
                    // 首先从总包中提取数据库文件
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
                            dbEntry.ExtractToFile(originalDbPath);
                        }
                    }, token);

                    // 将数据库文件复制到目标目录
                    string targetDbDir = Path.Combine(TargetPath.Text, "databases");
                    if (!Directory.Exists(targetDbDir))
                    {
                        Directory.CreateDirectory(targetDbDir);
                    }
                    string targetDbPath = Path.Combine(targetDbDir, "beida_soft.db");
                    File.Copy(originalDbPath, targetDbPath, true);
                    UpdateLog("数据库文件已复制到目标目录\n");

                    // 创建一个用于存放解压文件的临时目录
                    string tempZipDir = Path.Combine(workDir, "zip_content");
                    Directory.CreateDirectory(tempZipDir);

                    // 解压总包到临时目录
                    UpdateLog("正在解压总包...\n");
                    await Task.Run(() =>
                    {
                        using (var archive = ZipFile.OpenRead(ZB_path.Text))
                        {
                            foreach (var entry in archive.Entries)
                            {
                                token.ThrowIfCancellationRequested();
                                string destinationPath = Path.Combine(tempZipDir, entry.FullName);
                                string destinationDir = Path.GetDirectoryName(destinationPath);

                                if (!Directory.Exists(destinationDir))
                                {
                                    Directory.CreateDirectory(destinationDir);
                                }

                                if (!string.IsNullOrEmpty(entry.Name))
                                {
                                    entry.ExtractToFile(destinationPath, true);
                                }
                            }
                        }
                    }, token);

                    int totalSteps = enabledPackages.Count;
                    int currentStep = 0;

                    foreach (var packageName in enabledPackages)
                    {
                        if (token.IsCancellationRequested)
                        {
                            UpdateLog("用户取消操作\n");
                            break;
                        }

                        var packageStopwatch = new Stopwatch();
                        packageStopwatch.Start();

                        await Task.Run(async () =>
                        {
                            try
                            {
                                string sql = sqlConfigs[packageName];
                                UpdateLog($"正在处理分包：{packageName}\n");
                                UpdateProgress((int)((double)currentStep / totalSteps * 100));

                                // 为当前分包创建数据库副本
                                string currentDbPath = Path.Combine(workDir, $"beida_soft_{packageName}.db");
                                File.Copy(originalDbPath, currentDbPath, true);

                                UpdateLog($"正在执行SQL...\n");
                                await Task.Run(() =>
                                {
                                    using (var connection = new SQLiteConnection($"Data Source={currentDbPath};Version=3;"))
                                    {
                                        connection.Open();
                                        using (var transaction = connection.BeginTransaction())
                                        {
                                            try
                                            {
                                                var sqlStatements = sql.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                                                     .Select(s => s.Trim())
                                                                     .Where(s => !string.IsNullOrEmpty(s));

                                                foreach (var sqlStatement in sqlStatements)
                                                {
                                                    token.ThrowIfCancellationRequested();
                                                    using (var command = new SQLiteCommand(sqlStatement, connection, transaction))
                                                    {
                                                        UpdateLog($"执行SQL: {sqlStatement.Substring(0, Math.Min(50, sqlStatement.Length))}...\n");
                                                        command.ExecuteNonQuery();
                                                    }
                                                }
                                                transaction.Commit();
                                                UpdateLog("SQL执行完成\n");
                                            }
                                            catch
                                            {
                                                transaction.Rollback();
                                                throw;
                                            }
                                        }
                                    }
                                }, token);

                                // 替换临时目录中的数据库文件
                                string tempDbPath = Path.Combine(tempZipDir, "databases", "beida_soft.db");
                                File.Copy(currentDbPath, tempDbPath, true);

                                // 创建新的zip文件
                                string zipFileName = Path.GetFileNameWithoutExtension(ZB_path.Text);
                                string targetDir = TargetPath.Text;
                                string newZipName = ReplacePackageName(zipFileName, packageName);
                                string newZipPath = Path.Combine(targetDir, newZipName + ".zip");

                                UpdateLog($"正在创建新的压缩包...\n");
                                if (File.Exists(newZipPath))
                                {
                                    File.Delete(newZipPath);
                                }

                                await Task.Run(() =>
                                {
                                    using (var archive = ZipFile.Open(newZipPath, ZipArchiveMode.Create))
                                    {
                                        foreach (string filePath in Directory.GetFiles(tempZipDir, "*.*", SearchOption.AllDirectories))
                                        {
                                            token.ThrowIfCancellationRequested();
                                            string relativePath = filePath.Substring(tempZipDir.Length + 1);
                                            string entryName = relativePath.Replace('\\', '/');
                                            using (var stream = File.OpenRead(filePath))
                                            {
                                                var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                                                using (var entryStream = entry.Open())
                                                {
                                                    stream.CopyTo(entryStream);
                                                }
                                            }
                                        }
                                    }
                                }, token);

                                UpdateLog($"分包 {packageName} 处理完成，用时：{packageStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}\n");
                                currentStep++;
                                UpdateProgress((int)((double)currentStep / totalSteps * 100));
                            }
                            catch (OperationCanceledException)
                            {
                                UpdateLog($"处理分包 {packageName} 时被用户取消，用时：{packageStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}\n");
                                throw;
                            }
                            catch (Exception ex)
                            {
                                UpdateLog($"处理分包 {packageName} 时出错：{ex.Message}，用时：{packageStopwatch.Elapsed.ToString(@"mm\:ss\.fff")}\n");
                                throw;
                            }
                        });
                    }

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
    }
}
