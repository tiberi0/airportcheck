using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportCheck
{
    public partial class SplashScreen : Form
    {
        public int progressValue = 0;
        public string infoText = "Loading...";
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressValue;
            label1.Text = infoText;
            if (progressValue >= 100)
                timer1.Stop();
        }
    }
}
