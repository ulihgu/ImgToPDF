
namespace ImgToPDF
{
    partial class PDFMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFMain));
            this.start = new System.Windows.Forms.Button();
            this.SelectImgPath = new System.Windows.Forms.Button();
            this.pathText = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(869, 1);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(142, 23);
            this.start.TabIndex = 0;
            this.start.Text = "生成PDF";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // SelectImgPath
            // 
            this.SelectImgPath.Location = new System.Drawing.Point(755, 2);
            this.SelectImgPath.Name = "SelectImgPath";
            this.SelectImgPath.Size = new System.Drawing.Size(111, 23);
            this.SelectImgPath.TabIndex = 1;
            this.SelectImgPath.Text = "浏览目录";
            this.SelectImgPath.UseVisualStyleBackColor = true;
            this.SelectImgPath.Click += new System.EventHandler(this.SelectImgPath_Click);
            // 
            // pathText
            // 
            this.pathText.BackColor = System.Drawing.SystemColors.Highlight;
            this.pathText.Location = new System.Drawing.Point(3, 2);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(753, 21);
            this.pathText.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 26);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1007, 524);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // PDFMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 555);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pathText);
            this.Controls.Add(this.SelectImgPath);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PDFMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片转PDF文件工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button SelectImgPath;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

