
namespace AirportCheck
{
    partial class Controller
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.Hide();
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOnGround = new System.Windows.Forms.CheckBox();
            this.cbTemperature = new System.Windows.Forms.CheckBox();
            this.cbArrivals = new System.Windows.Forms.CheckBox();
            this.cbConditions = new System.Windows.Forms.CheckBox();
            this.cbDepartures = new System.Windows.Forms.CheckBox();
            this.cbWind = new System.Windows.Forms.CheckBox();
            this.tbAeroporto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbLock = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbOnGround);
            this.groupBox1.Controls.Add(this.cbTemperature);
            this.groupBox1.Controls.Add(this.cbArrivals);
            this.groupBox1.Controls.Add(this.cbConditions);
            this.groupBox1.Controls.Add(this.cbDepartures);
            this.groupBox1.Controls.Add(this.cbWind);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Options";
            // 
            // cbOnGround
            // 
            this.cbOnGround.AutoSize = true;
            this.cbOnGround.Checked = true;
            this.cbOnGround.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnGround.Location = new System.Drawing.Point(155, 65);
            this.cbOnGround.Name = "cbOnGround";
            this.cbOnGround.Size = new System.Drawing.Size(78, 17);
            this.cbOnGround.TabIndex = 6;
            this.cbOnGround.Text = "On Gorund";
            this.cbOnGround.UseVisualStyleBackColor = true;
            // 
            // cbTemperature
            // 
            this.cbTemperature.AutoSize = true;
            this.cbTemperature.Checked = true;
            this.cbTemperature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTemperature.Location = new System.Drawing.Point(6, 19);
            this.cbTemperature.Name = "cbTemperature";
            this.cbTemperature.Size = new System.Drawing.Size(86, 17);
            this.cbTemperature.TabIndex = 1;
            this.cbTemperature.Text = "Temperature";
            this.cbTemperature.UseVisualStyleBackColor = true;
            this.cbTemperature.CheckedChanged += new System.EventHandler(this.cbTemperature_CheckedChanged);
            // 
            // cbArrivals
            // 
            this.cbArrivals.AutoSize = true;
            this.cbArrivals.Checked = true;
            this.cbArrivals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbArrivals.Location = new System.Drawing.Point(155, 42);
            this.cbArrivals.Name = "cbArrivals";
            this.cbArrivals.Size = new System.Drawing.Size(60, 17);
            this.cbArrivals.TabIndex = 5;
            this.cbArrivals.Text = "Arrivals";
            this.cbArrivals.UseVisualStyleBackColor = true;
            this.cbArrivals.CheckedChanged += new System.EventHandler(this.cbArrivals_CheckedChanged);
            // 
            // cbConditions
            // 
            this.cbConditions.AutoSize = true;
            this.cbConditions.Checked = true;
            this.cbConditions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConditions.Location = new System.Drawing.Point(6, 42);
            this.cbConditions.Name = "cbConditions";
            this.cbConditions.Size = new System.Drawing.Size(75, 17);
            this.cbConditions.TabIndex = 2;
            this.cbConditions.Text = "Conditions";
            this.cbConditions.UseVisualStyleBackColor = true;
            this.cbConditions.CheckedChanged += new System.EventHandler(this.cbConditions_CheckedChanged);
            // 
            // cbDepartures
            // 
            this.cbDepartures.AutoSize = true;
            this.cbDepartures.Checked = true;
            this.cbDepartures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDepartures.Location = new System.Drawing.Point(155, 19);
            this.cbDepartures.Name = "cbDepartures";
            this.cbDepartures.Size = new System.Drawing.Size(78, 17);
            this.cbDepartures.TabIndex = 4;
            this.cbDepartures.Text = "Departures";
            this.cbDepartures.UseVisualStyleBackColor = true;
            this.cbDepartures.CheckedChanged += new System.EventHandler(this.cbDepartures_CheckedChanged);
            // 
            // cbWind
            // 
            this.cbWind.AutoSize = true;
            this.cbWind.Checked = true;
            this.cbWind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWind.Location = new System.Drawing.Point(6, 65);
            this.cbWind.Name = "cbWind";
            this.cbWind.Size = new System.Drawing.Size(51, 17);
            this.cbWind.TabIndex = 3;
            this.cbWind.Text = "Wind";
            this.cbWind.UseVisualStyleBackColor = true;
            this.cbWind.CheckedChanged += new System.EventHandler(this.cbWind_CheckedChanged);
            // 
            // tbAeroporto
            // 
            this.tbAeroporto.Location = new System.Drawing.Point(12, 25);
            this.tbAeroporto.Name = "tbAeroporto";
            this.tbAeroporto.Size = new System.Drawing.Size(194, 20);
            this.tbAeroporto.TabIndex = 1;
            this.tbAeroporto.Text = "gru";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IATA";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(11, 148);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(258, 31);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Manual Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbLock
            // 
            this.cbLock.AutoSize = true;
            this.cbLock.Checked = true;
            this.cbLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLock.Location = new System.Drawing.Point(212, 28);
            this.cbLock.Name = "cbLock";
            this.cbLock.Size = new System.Drawing.Size(50, 17);
            this.cbLock.TabIndex = 7;
            this.cbLock.Text = "Lock";
            this.cbLock.UseVisualStyleBackColor = true;
            this.cbLock.CheckedChanged += new System.EventHandler(this.cbBloquar_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AirportCheck";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 188);
            this.Controls.Add(this.cbLock);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAeroporto);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Controller";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AirportCheck Controller";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbOnGround;
        private System.Windows.Forms.CheckBox cbTemperature;
        private System.Windows.Forms.CheckBox cbArrivals;
        private System.Windows.Forms.CheckBox cbConditions;
        private System.Windows.Forms.CheckBox cbDepartures;
        private System.Windows.Forms.CheckBox cbWind;
        private System.Windows.Forms.TextBox tbAeroporto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbLock;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}

