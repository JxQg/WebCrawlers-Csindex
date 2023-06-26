namespace Csindex.WebCrawlers
{
    partial class DownloadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.DownloadButton = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.Label();
            this.triggleJobCheckBox = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.DownloadButton, "DownloadButton");
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.UseVisualStyleBackColor = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // msg
            // 
            resources.ApplyResources(this.msg, "msg");
            this.msg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msg.Name = "msg";
            // 
            // triggleJobCheckBox
            // 
            resources.ApplyResources(this.triggleJobCheckBox, "triggleJobCheckBox");
            this.triggleJobCheckBox.Name = "triggleJobCheckBox";
            this.triggleJobCheckBox.UseVisualStyleBackColor = true;
            this.triggleJobCheckBox.CheckedChanged += new System.EventHandler(this.TriggleJob_CheckedChanged);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // startupCheckBox
            // 
            resources.ApplyResources(this.startupCheckBox, "startupCheckBox");
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            this.startupCheckBox.CheckedChanged += new System.EventHandler(this.startupCheckBox_CheckedChanged);
            // 
            // DownloadForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.startupCheckBox);
            this.Controls.Add(this.triggleJobCheckBox);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.DownloadButton);
            this.Name = "DownloadForm";
            this.Resize += new System.EventHandler(this.DownloadForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.CheckBox triggleJobCheckBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox startupCheckBox;
    }
}

