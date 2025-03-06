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
            this.SuspendLayout();
            // 
            // ZB_pathBTN
            // 
            this.ZB_pathBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZB_pathBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZB_pathBTN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZB_pathBTN.Location = new System.Drawing.Point(701, 47);
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
            this.ZB_path.Location = new System.Drawing.Point(14, 53);
            this.ZB_path.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ZB_path.MinimumSize = new System.Drawing.Size(1, 16);
            this.ZB_path.Name = "ZB_path";
            this.ZB_path.Padding = new System.Windows.Forms.Padding(5);
            this.ZB_path.ShowText = false;
            this.ZB_path.Size = new System.Drawing.Size(680, 29);
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
            this.TargetPath.Location = new System.Drawing.Point(14, 100);
            this.TargetPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TargetPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TargetPath.Name = "TargetPath";
            this.TargetPath.Padding = new System.Windows.Forms.Padding(5);
            this.TargetPath.ShowText = false;
            this.TargetPath.Size = new System.Drawing.Size(680, 29);
            this.TargetPath.TabIndex = 4;
            this.TargetPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TargetPath.Watermark = "";
            // 
            // TargetPathBtn
            // 
            this.TargetPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetPathBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TargetPathBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TargetPathBtn.Location = new System.Drawing.Point(701, 94);
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
            this.StartBtn.Location = new System.Drawing.Point(701, 135);
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
            this.AddSQlBtn.Location = new System.Drawing.Point(458, 135);
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
            this.log.Location = new System.Drawing.Point(14, 178);
            this.log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.log.MinimumSize = new System.Drawing.Size(1, 1);
            this.log.Name = "log";
            this.log.Padding = new System.Windows.Forms.Padding(2);
            this.log.ShowText = false;
            this.log.Size = new System.Drawing.Size(787, 290);
            this.log.TabIndex = 7;
            this.log.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(585, 135);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 8;
            this.uiButton1.Text = "查看子包";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(816, 489);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.AddSQlBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.TargetPath);
            this.Controls.Add(this.ZB_path);
            this.Controls.Add(this.TargetPathBtn);
            this.Controls.Add(this.ZB_pathBTN);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "数据分包";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 816, 489);
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
    }
}

