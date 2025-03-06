
namespace G2S
{
    partial class Form2
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.Add = new Sunny.UI.UIButton();
            this.FB_Name = new Sunny.UI.UITextBox();
            this.Sql = new Sunny.UI.UIRichTextBox();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add.Location = new System.Drawing.Point(692, 442);
            this.Add.MinimumSize = new System.Drawing.Size(1, 1);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(100, 35);
            this.Add.TabIndex = 0;
            this.Add.Text = "添加";
            this.Add.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // FB_Name
            // 
            this.FB_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FB_Name.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FB_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FB_Name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FB_Name.Location = new System.Drawing.Point(29, 53);
            this.FB_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FB_Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.FB_Name.Name = "FB_Name";
            this.FB_Name.Padding = new System.Windows.Forms.Padding(5);
            this.FB_Name.ShowText = false;
            this.FB_Name.Size = new System.Drawing.Size(763, 29);
            this.FB_Name.TabIndex = 1;
            this.FB_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.FB_Name.Watermark = "";
            // 
            // Sql
            // 
            this.Sql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sql.FillColor = System.Drawing.Color.White;
            this.Sql.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sql.Location = new System.Drawing.Point(29, 92);
            this.Sql.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Sql.MinimumSize = new System.Drawing.Size(1, 1);
            this.Sql.Name = "Sql";
            this.Sql.Padding = new System.Windows.Forms.Padding(2);
            this.Sql.ShowText = false;
            this.Sql.Size = new System.Drawing.Size(763, 342);
            this.Sql.TabIndex = 2;
            this.Sql.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiStyleManager1
            // 
            this.uiStyleManager1.DPIScale = true;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(816, 489);
            this.Controls.Add(this.Sql);
            this.Controls.Add(this.FB_Name);
            this.Controls.Add(this.Add);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form2";
            this.Text = "添加分包配置";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 816, 489);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton Add;
        private Sunny.UI.UITextBox FB_Name;
        private Sunny.UI.UIRichTextBox Sql;
        private Sunny.UI.UIStyleManager uiStyleManager1;
    }
}