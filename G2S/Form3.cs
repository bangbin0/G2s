using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Sunny.UI;


namespace G2S
{
    public partial class Form3 : UIForm
    {
        private Dictionary<string, string> sqlConfigs;
        private Dictionary<string, bool> packageStates; // 存储包的启用状态
        private readonly string configPath = "sqlconfig.json";
        private EventHandler configChangeHandler; // 添加字段保存事件处理器

        public Form3()
        {
            InitializeComponent();
            // 初始化时禁用所有按钮和开关
            editBtn.Enabled = false;
            saveBtn.Enabled = false;
            deleteBtn.Enabled = false;
            enableSwitch.Enabled = false;
            packageStates = new Dictionary<string, bool>();
            
            // 创建并保存事件处理器
            configChangeHandler = (sender, e) => 
            {
                // 在UI线程中刷新配置
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(LoadConfigs));
                }
                else
                {
                    LoadConfigs();
                }
            };
            
            // 订阅配置变更事件
            Form2.ConfigurationChanged += configChangeHandler;

            InitializeEvents();
            LoadConfigs();
        }

        private void LoadConfigs()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    var config = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    
                    // 加载SQL配置
                    sqlConfigs = config.ContainsKey("sqlConfigs") 
                        ? JsonConvert.DeserializeObject<Dictionary<string, string>>(config["sqlConfigs"].ToString())
                        : new Dictionary<string, string>();
                    
                    // 加载启用状态
                    packageStates = config.ContainsKey("packageStates")
                        ? JsonConvert.DeserializeObject<Dictionary<string, bool>>(config["packageStates"].ToString())
                        : new Dictionary<string, bool>();

                    // 清空并添加所有分包名称到ListBox
                    listBox1.Items.Clear();
                    foreach (var key in sqlConfigs.Keys)
                    {
                        listBox1.Items.Add(key);
                        // 如果没有状态记录，默认为未选中
                        if (!packageStates.ContainsKey(key))
                        {
                            packageStates[key] = false;
                        }
                    }

                    // 如果有数据，默认选中第一条并启用按钮
                    if (listBox1.Items.Count > 0)
                    {
                        listBox1.SelectedIndex = 0;
                        editBtn.Enabled = true;
                        deleteBtn.Enabled = true;
                        enableSwitch.Enabled = true;
                    }
                }
                else
                {
                    sqlConfigs = new Dictionary<string, string>();
                    packageStates = new Dictionary<string, bool>();
                    MessageBox.Show("未找到配置文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载配置文件失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConfigs = new Dictionary<string, string>();
                packageStates = new Dictionary<string, bool>();
            }
        }

        private void SaveConfigs()
        {
            try
            {
                var config = new Dictionary<string, object>
                {
                    ["sqlConfigs"] = sqlConfigs,
                    ["packageStates"] = packageStates
                };

                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(configPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存配置文件失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEvents()
        {
            // CheckBoxGroup选择变更事件
            listBox1.SelectedIndexChanged += (sender, e) =>
            {
                if (listBox1.SelectedItem != null)
                {
                    string selectedKey = listBox1.SelectedItem.ToString();
                    if (sqlConfigs.ContainsKey(selectedKey))
                    {
                        sqlContent.Text = sqlConfigs[selectedKey];
                        editBtn.Enabled = true;
                        deleteBtn.Enabled = true;
                        enableSwitch.Enabled = true;
                        
                        // 设置开关状态
                        enableSwitch.Active = packageStates[selectedKey];
                    }
                }
                else
                {
                    sqlContent.Clear();
                    editBtn.Enabled = false;
                    saveBtn.Enabled = false;
                    deleteBtn.Enabled = false;
                    enableSwitch.Enabled = false;
                }
            };

            // 启用状态变更事件
            enableSwitch.ValueChanged += (sender, e) =>
            {
                if (listBox1.SelectedItem != null)
                {
                    string selectedKey = listBox1.SelectedItem.ToString();
                    packageStates[selectedKey] = enableSwitch.Active;
                    SaveConfigs();
                }
            };

            // 编辑按钮事件
            editBtn.Click += (sender, e) =>
            {
                sqlContent.ReadOnly = false;
                saveBtn.Enabled = true;
                editBtn.Enabled = false;
            };

            // 保存按钮事件
            saveBtn.Click += (sender, e) =>
            {
                if (listBox1.SelectedItem != null)
                {
                    string selectedKey = listBox1.SelectedItem.ToString();
                    sqlConfigs[selectedKey] = sqlContent.Text;
                    SaveConfigs();
                    
                    sqlContent.ReadOnly = true;
                    saveBtn.Enabled = false;
                    editBtn.Enabled = true;
                }
            };

            // 删除按钮事件
            deleteBtn.Click += (sender, e) =>
            {
                if (listBox1.SelectedItem != null)
                {
                    string selectedKey = listBox1.SelectedItem.ToString();
                    if (MessageBox.Show($"确定要删除分包 {selectedKey} 吗？", "确认删除", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int currentIndex = listBox1.SelectedIndex;
                        sqlConfigs.Remove(selectedKey);
                        listBox1.Items.Remove(selectedKey);
                        
                        if (listBox1.Items.Count > 0)
                        {
                            if (currentIndex >= listBox1.Items.Count)
                            {
                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                            }
                            else
                            {
                                listBox1.SelectedIndex = currentIndex;
                            }
                        }
                        else
                        {
                            // 如果删除最后一条数据，清空内容并禁用所有按钮
                            sqlContent.Clear();
                            editBtn.Enabled = false;
                            saveBtn.Enabled = false;
                            deleteBtn.Enabled = false;
                        }
                        
                        SaveConfigs();
                    }
                }
            };
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
