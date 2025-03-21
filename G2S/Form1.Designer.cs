namespace G2S
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ZB_pathBTN = new Sunny.UI.UIButton();
            this.ZB_path = new Sunny.UI.UITextBox();
            this.TargetPath = new Sunny.UI.UITextBox();
            this.TargetPathBtn = new Sunny.UI.UIButton();
            this.StartBtn = new Sunny.UI.UISymbolButton();
            this.AddSQlBtn = new Sunny.UI.UIButton();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.log = new Sunny.UI.UIRichTextBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.P1 = new System.Windows.Forms.TabPage();
            this.P2 = new System.Windows.Forms.TabPage();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.P2_Log = new Sunny.UI.UIRichTextBox();
            this.uiTabControl1.SuspendLayout();
            this.P1.SuspendLayout();
            this.P2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ZB_pathBTN
            // 
            this.ZB_pathBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZB_pathBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZB_pathBTN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZB_pathBTN.Location = new System.Drawing.Point(1210, -2);
            this.ZB_pathBTN.MinimumSize = new System.Drawing.Size(1, 1);
            this.ZB_pathBTN.Name = "ZB_pathBTN";
            this.ZB_pathBTN.Size = new System.Drawing.Size(100, 35);
            this.ZB_pathBTN.TabIndex = 0;
            this.ZB_pathBTN.Text = "选择总包";
            this.ZB_pathBTN.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZB_pathBTN.Click += new System.EventHandler(this.ZB_pathBTN_Click);
            // 
            // ZB_path
            // 
            this.ZB_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZB_path.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ZB_path.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZB_path.Location = new System.Drawing.Point(4, 4);
            this.ZB_path.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ZB_path.MinimumSize = new System.Drawing.Size(1, 16);
            this.ZB_path.Name = "ZB_path";
            this.ZB_path.Padding = new System.Windows.Forms.Padding(5);
            this.ZB_path.ShowText = false;
            this.ZB_path.Size = new System.Drawing.Size(671, 29);
            this.ZB_path.TabIndex = 1;
            this.ZB_path.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZB_path.Watermark = "";
            // 
            // TargetPath
            // 
            this.TargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TargetPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TargetPath.Location = new System.Drawing.Point(4, 51);
            this.TargetPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TargetPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TargetPath.Name = "TargetPath";
            this.TargetPath.Padding = new System.Windows.Forms.Padding(5);
            this.TargetPath.ShowText = false;
            this.TargetPath.Size = new System.Drawing.Size(671, 29);
            this.TargetPath.TabIndex = 4;
            this.TargetPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TargetPath.Watermark = "";
            // 
            // TargetPathBtn
            // 
            this.TargetPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetPathBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TargetPathBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TargetPathBtn.Location = new System.Drawing.Point(712, 4);
            this.TargetPathBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.TargetPathBtn.Name = "TargetPathBtn";
            this.TargetPathBtn.Size = new System.Drawing.Size(100, 35);
            this.TargetPathBtn.TabIndex = 3;
            this.TargetPathBtn.Text = "选择生成目录";
            this.TargetPathBtn.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TargetPathBtn.Click += new System.EventHandler(this.TargetPathBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartBtn.Location = new System.Drawing.Point(713, 45);
            this.StartBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(100, 35);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "开始生成";
            this.StartBtn.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // AddSQlBtn
            // 
            this.AddSQlBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSQlBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSQlBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddSQlBtn.Location = new System.Drawing.Point(712, 86);
            this.AddSQlBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.AddSQlBtn.Name = "AddSQlBtn";
            this.AddSQlBtn.Size = new System.Drawing.Size(100, 35);
            this.AddSQlBtn.TabIndex = 6;
            this.AddSQlBtn.Text = "添加分包代码";
            this.AddSQlBtn.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddSQlBtn.Click += new System.EventHandler(this.AddSQlBtn_Click);
            // 
            // uiStyleManager1
            // 
            this.uiStyleManager1.DPIScale = true;
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.FillColor = System.Drawing.Color.White;
            this.log.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.log.Location = new System.Drawing.Point(4, 129);
            this.log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.log.MinimumSize = new System.Drawing.Size(1, 1);
            this.log.Name = "log";
            this.log.Padding = new System.Windows.Forms.Padding(2);
            this.log.ShowText = false;
            this.log.Size = new System.Drawing.Size(808, 280);
            this.log.TabIndex = 7;
            this.log.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(575, 86);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 8;
            this.uiButton1.Text = "查看子包";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.Controls.Add(this.P1);
            this.uiTabControl1.Controls.Add(this.P2);
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 35);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(816, 454);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 9;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // P1
            // 
            this.P1.Controls.Add(this.TargetPath);
            this.P1.Controls.Add(this.uiButton1);
            this.P1.Controls.Add(this.ZB_pathBTN);
            this.P1.Controls.Add(this.log);
            this.P1.Controls.Add(this.TargetPathBtn);
            this.P1.Controls.Add(this.AddSQlBtn);
            this.P1.Controls.Add(this.ZB_path);
            this.P1.Controls.Add(this.StartBtn);
            this.P1.Location = new System.Drawing.Point(0, 40);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(816, 414);
            this.P1.TabIndex = 0;
            this.P1.Text = "数据分包";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // P2
            // 
            this.P2.Controls.Add(this.P2_Log);
            this.P2.Controls.Add(this.uiButton2);
            this.P2.Controls.Add(this.uiTextBox1);
            this.P2.Location = new System.Drawing.Point(0, 40);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(816, 414);
            this.P2.TabIndex = 1;
            this.P2.Text = "数据调整";
            this.P2.UseVisualStyleBackColor = true;
            // 
            // uiButton2
            // 
            this.uiButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(712, 5);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 5;
            this.uiButton2.Text = "选择zip包目录";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.Location = new System.Drawing.Point(4, 5);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(671, 29);
            this.uiTextBox1.TabIndex = 4;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // P2_Log
            // 
            this.P2_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.P2_Log.FillColor = System.Drawing.Color.White;
            this.P2_Log.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.P2_Log.Location = new System.Drawing.Point(4, 48);
            this.P2_Log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.P2_Log.MinimumSize = new System.Drawing.Size(1, 1);
            this.P2_Log.Name = "P2_Log";
            this.P2_Log.Padding = new System.Windows.Forms.Padding(2);
            this.P2_Log.ShowText = false;
            this.P2_Log.Size = new System.Drawing.Size(808, 361);
            this.P2_Log.TabIndex = 8;
            this.P2_Log.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(816, 489);
            this.Controls.Add(this.uiTabControl1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "数据分包";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 816, 489);
            this.uiTabControl1.ResumeLayout(false);
            this.P1.ResumeLayout(false);
            this.P2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton ZB_pathBTN;
        private Sunny.UI.UITextBox ZB_path;
        private Sunny.UI.UITextBox TargetPath;
        private Sunny.UI.UIButton TargetPathBtn;
        private Sunny.UI.UIButton AddSQlBtn;
        private Sunny.UI.UIStyleManager uiStyleManager1;
        private Sunny.UI.UIRichTextBox log;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UISymbolButton StartBtn;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage P1;
        private System.Windows.Forms.TabPage P2;
        private Sunny.UI.UIRichTextBox P2_Log;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UITextBox uiTextBox1;
    }
}

