
namespace AirportCheck
{
    partial class AirportDetailInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirportDetailInfo));
            this.tbDetailInfo = new System.Windows.Forms.TextBox();
            this.tbDetailValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbDetailInfo
            // 
            this.tbDetailInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDetailInfo.BackColor = System.Drawing.Color.White;
            this.tbDetailInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDetailInfo.Enabled = false;
            this.tbDetailInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetailInfo.ForeColor = System.Drawing.Color.DimGray;
            this.tbDetailInfo.Location = new System.Drawing.Point(12, 9);
            this.tbDetailInfo.Name = "tbDetailInfo";
            this.tbDetailInfo.Size = new System.Drawing.Size(119, 15);
            this.tbDetailInfo.TabIndex = 0;
            this.tbDetailInfo.Text = "DetailInfo";
            this.tbDetailInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDetailInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tbDetailInfo_MouseMove);
            // 
            // tbDetailValue
            // 
            this.tbDetailValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDetailValue.BackColor = System.Drawing.Color.White;
            this.tbDetailValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDetailValue.Enabled = false;
            this.tbDetailValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetailValue.ForeColor = System.Drawing.Color.DimGray;
            this.tbDetailValue.Location = new System.Drawing.Point(12, 30);
            this.tbDetailValue.Name = "tbDetailValue";
            this.tbDetailValue.Size = new System.Drawing.Size(119, 18);
            this.tbDetailValue.TabIndex = 1;
            this.tbDetailValue.Text = "DetailValue";
            this.tbDetailValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDetailValue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tbDetailValue_MouseMove);
            // 
            // AirportDetailInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(143, 60);
            this.Controls.Add(this.tbDetailValue);
            this.Controls.Add(this.tbDetailInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AirportDetailInfo";
            this.Text = "DetailInfo";
            this.TopMost = true;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AirportDetailInfo_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDetailInfo;
        private System.Windows.Forms.TextBox tbDetailValue;
    }
}