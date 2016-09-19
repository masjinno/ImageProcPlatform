namespace IP_Filter.Setting    //RENAME
{
    partial class FilterSetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.FilterSize_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FilterSize_Label = new System.Windows.Forms.Label();
            this.Filter_DataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FilterSize_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.Location = new System.Drawing.Point(116, 227);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 0;
            this.Cancel_Button.Text = "キャンセル";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_Button.Location = new System.Drawing.Point(197, 227);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 1;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // FilterSize_NumericUpDown
            // 
            this.FilterSize_NumericUpDown.Enabled = false;
            this.FilterSize_NumericUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.FilterSize_NumericUpDown.Location = new System.Drawing.Point(95, 7);
            this.FilterSize_NumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.FilterSize_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FilterSize_NumericUpDown.Name = "FilterSize_NumericUpDown";
            this.FilterSize_NumericUpDown.Size = new System.Drawing.Size(49, 19);
            this.FilterSize_NumericUpDown.TabIndex = 2;
            this.FilterSize_NumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.FilterSize_NumericUpDown.ValueChanged += new System.EventHandler(this.FilterSize_NumericUpDown_ValueChanged);
            // 
            // FilterSize_Label
            // 
            this.FilterSize_Label.AutoSize = true;
            this.FilterSize_Label.Location = new System.Drawing.Point(12, 9);
            this.FilterSize_Label.Name = "FilterSize_Label";
            this.FilterSize_Label.Size = new System.Drawing.Size(77, 12);
            this.FilterSize_Label.TabIndex = 3;
            this.FilterSize_Label.Text = "フィルターサイズ";
            // 
            // Filter_DataGridView
            // 
            this.Filter_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Filter_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.Filter_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.Filter_DataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Filter_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Filter_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Filter_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Filter_DataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Filter_DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.Filter_DataGridView.Location = new System.Drawing.Point(14, 32);
            this.Filter_DataGridView.Name = "Filter_DataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Filter_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Filter_DataGridView.RowHeadersVisible = false;
            this.Filter_DataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Filter_DataGridView.RowTemplate.Height = 21;
            this.Filter_DataGridView.Size = new System.Drawing.Size(258, 189);
            this.Filter_DataGridView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "(サイズ変更未実装)";
            // 
            // FilterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Filter_DataGridView);
            this.Controls.Add(this.FilterSize_Label);
            this.Controls.Add(this.FilterSize_NumericUpDown);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Name = "FilterSetting";
            this.Text = "FilterSetting";
            ((System.ComponentModel.ISupportInitialize)(this.FilterSize_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.NumericUpDown FilterSize_NumericUpDown;
        private System.Windows.Forms.Label FilterSize_Label;
        private System.Windows.Forms.DataGridView Filter_DataGridView;
        private System.Windows.Forms.Label label1;
    }
}