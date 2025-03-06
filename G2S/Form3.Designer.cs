namespace G2S
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                // 取消订阅事件
                if (configChangeHandler != null)
                {
                    Form2.ConfigurationChanged -= configChangeHandler;
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new Sunny.UI.UIListBox();
            this.sqlContent = new Sunny.UI.UIRichTextBox();
            this.editBtn = new Sunny.UI.UIButton();
            this.saveBtn = new Sunny.UI.UIButton();
            this.deleteBtn = new Sunny.UI.UIButton();
            this.enableSwitch = new Sunny.UI.UISwitch();
            this.enableLabel = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.listBox1.Location = new System.Drawing.Point(12, 47);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Padding = new System.Windows.Forms.Padding(2);
            this.listBox1.ShowText = false;
            this.listBox1.Size = new System.Drawing.Size(200, 426);
            this.listBox1.TabIndex = 0;
            this.listBox1.Text = "分包列表";
            // 
            // sqlContent
            // 
            this.sqlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlContent.FillColor = System.Drawing.Color.White;
            this.sqlContent.Font = new System.Drawing.Font("宋体", 12F);
            this.sqlContent.Location = new System.Drawing.Point(218, 48);
            this.sqlContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sqlContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.sqlContent.Name = "sqlContent";
            this.sqlContent.Padding = new System.Windows.Forms.Padding(2);
            this.sqlContent.ReadOnly = true;
            this.sqlContent.ShowText = false;
            this.sqlContent.Size = new System.Drawing.Size(582, 386);
            this.sqlContent.TabIndex = 1;
            this.sqlContent.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editBtn.Font = new System.Drawing.Font("宋体", 12F);
            this.editBtn.Location = new System.Drawing.Point(488, 442);
            this.editBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(100, 32);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "编辑";
            this.editBtn.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("宋体", 12F);
            this.saveBtn.Location = new System.Drawing.Point(594, 442);
            this.saveBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 32);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "保存";
            this.saveBtn.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.Font = new System.Drawing.Font("宋体", 12F);
            this.deleteBtn.Location = new System.Drawing.Point(700, 442);
            this.deleteBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(100, 32);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "删除";
            this.deleteBtn.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // enableSwitch
            // 
            this.enableSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.enableSwitch.Font = new System.Drawing.Font("宋体", 12F);
            this.enableSwitch.Location = new System.Drawing.Point(318, 442);
            this.enableSwitch.MinimumSize = new System.Drawing.Size(1, 1);
            this.enableSwitch.Name = "enableSwitch";
            this.enableSwitch.Size = new System.Drawing.Size(75, 32);
            this.enableSwitch.TabIndex = 5;
            // 
            // enableLabel
            // 
            this.enableLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.enableLabel.Location = new System.Drawing.Point(218, 442);
            this.enableLabel.Name = "enableLabel";
            this.enableLabel.Size = new System.Drawing.Size(100, 32);
            this.enableLabel.Text = "启用状态：";
            this.enableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(816, 489);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.sqlContent);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.enableSwitch);
            this.Controls.Add(this.enableLabel);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form3";
            this.Text = "查看分包配置";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 816, 489);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIListBox listBox1;
        private Sunny.UI.UIRichTextBox sqlContent;
        private Sunny.UI.UIButton editBtn;
        private Sunny.UI.UIButton saveBtn;
        private Sunny.UI.UIButton deleteBtn;
        private Sunny.UI.UISwitch enableSwitch;
        private Sunny.UI.UILabel enableLabel;
    }
}