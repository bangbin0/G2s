using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Sunny.UI;


namespace G2S
{
    public partial class Form2 : UIForm
    {
        // 添加静态事件
        public static event EventHandler ConfigurationChanged;

        private Dictionary<string, string> sqlConfigs;
        private Dictionary<string, bool> packageStates;  // 添加状态字典
        private readonly string configPath = "sqlconfig.json";

        public Form2()
        {
            InitializeComponent();
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
                }
                else
                {
                    sqlConfigs = new Dictionary<string, string>();
                    packageStates = new Dictionary<string, bool>();
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

        private void Add_Click(object sender, EventArgs e)
        {
            string name = FB_Name.Text.Trim();
            string sql = Sql.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sql))
            {
                MessageBox.Show("分包名称和SQL内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sqlConfigs.ContainsKey(name))
            {
                MessageBox.Show("该分包名称已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sqlConfigs[name] = sql;
            packageStates[name] = true;  // 修改这里：新添加的配置默认为启用状态
            SaveConfigs();
            MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // 清空输入框
            FB_Name.Text = "";
            Sql.Text = "";

            // 触发配置变更事件
            ConfigurationChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
