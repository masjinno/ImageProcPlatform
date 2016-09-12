namespace ImageProcPlatform
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ImageToolStrip = new System.Windows.Forms.ToolStrip();
            this.OpenImageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveImageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ResetImageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ImageToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ProcImageToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.ProcImageSettingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ProcImageExecToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ImageToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ImageStatusStrip = new System.Windows.Forms.StatusStrip();
            this.MousePosToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ImageSizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ImageViewPanel = new System.Windows.Forms.Panel();
            this.ImageViewerPictureBox = new System.Windows.Forms.PictureBox();
            this.IPStatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ImageProcToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ImageToolStrip.SuspendLayout();
            this.ImageStatusStrip.SuspendLayout();
            this.ImageViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageToolStrip
            // 
            this.ImageToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripButton,
            this.SaveImageToolStripButton,
            this.ResetImageToolStripButton,
            this.ImageToolStripSeparator1,
            this.ProcImageToolStripComboBox,
            this.ProcImageSettingToolStripButton,
            this.ProcImageExecToolStripButton,
            this.ImageToolStripSeparator2});
            this.ImageToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ImageToolStrip.Name = "ImageToolStrip";
            this.ImageToolStrip.Size = new System.Drawing.Size(784, 26);
            this.ImageToolStrip.TabIndex = 0;
            this.ImageToolStrip.Text = "toolStrip1";
            // 
            // OpenImageToolStripButton
            // 
            this.OpenImageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenImageToolStripButton.Image")));
            this.OpenImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenImageToolStripButton.Name = "OpenImageToolStripButton";
            this.OpenImageToolStripButton.Size = new System.Drawing.Size(71, 23);
            this.OpenImageToolStripButton.Text = "開く(&O)";
            this.OpenImageToolStripButton.Click += new System.EventHandler(this.openImageToolStripButton_Click);
            // 
            // SaveImageToolStripButton
            // 
            this.SaveImageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveImageToolStripButton.Image")));
            this.SaveImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveImageToolStripButton.Name = "SaveImageToolStripButton";
            this.SaveImageToolStripButton.Size = new System.Drawing.Size(142, 23);
            this.SaveImageToolStripButton.Text = "名前をつけて保存(&S)";
            this.SaveImageToolStripButton.Click += new System.EventHandler(this.saveImageToolStripButton_Click);
            // 
            // ResetImageToolStripButton
            // 
            this.ResetImageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ResetImageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetImageToolStripButton.Image")));
            this.ResetImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetImageToolStripButton.Name = "ResetImageToolStripButton";
            this.ResetImageToolStripButton.Size = new System.Drawing.Size(90, 23);
            this.ResetImageToolStripButton.Text = "画像初期化(&R)";
            this.ResetImageToolStripButton.Click += new System.EventHandler(this.resetImageToolStripButton_Click);
            // 
            // ImageToolStripSeparator1
            // 
            this.ImageToolStripSeparator1.Name = "ImageToolStripSeparator1";
            this.ImageToolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // ProcImageToolStripComboBox
            // 
            this.ProcImageToolStripComboBox.Name = "ProcImageToolStripComboBox";
            this.ProcImageToolStripComboBox.Size = new System.Drawing.Size(180, 26);
            // 
            // ProcImageSettingToolStripButton
            // 
            this.ProcImageSettingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProcImageSettingToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ProcImageSettingToolStripButton.Image")));
            this.ProcImageSettingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProcImageSettingToolStripButton.Name = "ProcImageSettingToolStripButton";
            this.ProcImageSettingToolStripButton.Size = new System.Drawing.Size(53, 23);
            this.ProcImageSettingToolStripButton.Text = "設定(&E)";
            this.ProcImageSettingToolStripButton.Click += new System.EventHandler(this.ProcImageSettingToolStripButton_Click);
            // 
            // ProcImageExecToolStripButton
            // 
            this.ProcImageExecToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProcImageExecToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ProcImageExecToolStripButton.Image")));
            this.ProcImageExecToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProcImageExecToolStripButton.Name = "ProcImageExecToolStripButton";
            this.ProcImageExecToolStripButton.Size = new System.Drawing.Size(77, 23);
            this.ProcImageExecToolStripButton.Text = "画像処理(&P)";
            this.ProcImageExecToolStripButton.Click += new System.EventHandler(this.ProcImageExecToolStripButton_Click);
            // 
            // ImageToolStripSeparator2
            // 
            this.ImageToolStripSeparator2.Name = "ImageToolStripSeparator2";
            this.ImageToolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // ImageStatusStrip
            // 
            this.ImageStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MousePosToolStripStatusLabel,
            this.ImageSizeToolStripStatusLabel,
            this.IPStatusToolStripStatusLabel,
            this.ImageProcToolStripProgressBar});
            this.ImageStatusStrip.Location = new System.Drawing.Point(0, 535);
            this.ImageStatusStrip.Name = "ImageStatusStrip";
            this.ImageStatusStrip.Size = new System.Drawing.Size(784, 27);
            this.ImageStatusStrip.TabIndex = 1;
            this.ImageStatusStrip.Text = "statusStrip1";
            // 
            // MousePosToolStripStatusLabel
            // 
            this.MousePosToolStripStatusLabel.AutoSize = false;
            this.MousePosToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.MousePosToolStripStatusLabel.Name = "MousePosToolStripStatusLabel";
            this.MousePosToolStripStatusLabel.Size = new System.Drawing.Size(120, 22);
            this.MousePosToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageSizeToolStripStatusLabel
            // 
            this.ImageSizeToolStripStatusLabel.AutoSize = false;
            this.ImageSizeToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ImageSizeToolStripStatusLabel.Name = "ImageSizeToolStripStatusLabel";
            this.ImageSizeToolStripStatusLabel.Size = new System.Drawing.Size(120, 22);
            this.ImageSizeToolStripStatusLabel.Text = "W x H px";
            this.ImageSizeToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageViewPanel
            // 
            this.ImageViewPanel.AutoScroll = true;
            this.ImageViewPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ImageViewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImageViewPanel.Controls.Add(this.ImageViewerPictureBox);
            this.ImageViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageViewPanel.Location = new System.Drawing.Point(0, 26);
            this.ImageViewPanel.Name = "ImageViewPanel";
            this.ImageViewPanel.Size = new System.Drawing.Size(784, 509);
            this.ImageViewPanel.TabIndex = 2;
            // 
            // ImageViewerPictureBox
            // 
            this.ImageViewerPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ImageViewerPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageViewerPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ImageViewerPictureBox.Location = new System.Drawing.Point(0, 0);
            this.ImageViewerPictureBox.Name = "ImageViewerPictureBox";
            this.ImageViewerPictureBox.Size = new System.Drawing.Size(642, 482);
            this.ImageViewerPictureBox.TabIndex = 0;
            this.ImageViewerPictureBox.TabStop = false;
            this.ImageViewerPictureBox.MouseLeave += new System.EventHandler(this.ImageViewerPictureBox_MouseLeave);
            this.ImageViewerPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageViewerPictureBox_MouseMove);
            // 
            // IPStatusToolStripStatusLabel
            // 
            this.IPStatusToolStripStatusLabel.AutoSize = false;
            this.IPStatusToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.IPStatusToolStripStatusLabel.Name = "IPStatusToolStripStatusLabel";
            this.IPStatusToolStripStatusLabel.Size = new System.Drawing.Size(220, 22);
            this.IPStatusToolStripStatusLabel.Text = "IPステータス";
            this.IPStatusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageProcToolStripProgressBar
            // 
            this.ImageProcToolStripProgressBar.Name = "ImageProcToolStripProgressBar";
            this.ImageProcToolStripProgressBar.Size = new System.Drawing.Size(100, 21);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.ImageViewPanel);
            this.Controls.Add(this.ImageStatusStrip);
            this.Controls.Add(this.ImageToolStrip);
            this.Name = "MainForm";
            this.Text = "画像処理";
            this.ImageToolStrip.ResumeLayout(false);
            this.ImageToolStrip.PerformLayout();
            this.ImageStatusStrip.ResumeLayout(false);
            this.ImageStatusStrip.PerformLayout();
            this.ImageViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ImageToolStrip;
        private System.Windows.Forms.StatusStrip ImageStatusStrip;
        private System.Windows.Forms.Panel ImageViewPanel;
        private System.Windows.Forms.PictureBox ImageViewerPictureBox;
        private System.Windows.Forms.ToolStripButton OpenImageToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveImageToolStripButton;
        private System.Windows.Forms.ToolStripButton ResetImageToolStripButton;
        private System.Windows.Forms.ToolStripSeparator ImageToolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox ProcImageToolStripComboBox;
        private System.Windows.Forms.ToolStripButton ProcImageSettingToolStripButton;
        private System.Windows.Forms.ToolStripButton ProcImageExecToolStripButton;
        private System.Windows.Forms.ToolStripSeparator ImageToolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel MousePosToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ImageSizeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel IPStatusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ImageProcToolStripProgressBar;
    }
}

