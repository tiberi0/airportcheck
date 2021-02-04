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
    public partial class AirportDetailInfo : Form
    {
        //Define data category
        private string categoryDetail = "";
        public AirportDetailInfo(string categoryDetail)
        {
            this.categoryDetail = categoryDetail;
            InitializeComponent();
            setDetailInfo(categoryDetail);
            this.Text = categoryDetail;
        }

        public void setDetailInfo(string detailInfo)
        {
            tbDetailInfo.Text = detailInfo;
        }
        public void setDetailValue(string detailValue)
        {
            tbDetailValue.Text = detailValue;
        }

        #region Interface Mouse Move functions
        private void AirportDetailInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                this.saveMousePosition();
            }
        }

        private void tbDetailInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                this.saveMousePosition();
            }
        }

        private void tbDetailValue_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                this.saveMousePosition();
            }
        }

        private void saveMousePosition()
        {
            switch (this.categoryDetail)
            {
                case "Temperature": Properties.Settings.Default.Temperature = this.Location;break;
                case "Wind": Properties.Settings.Default.Wind = this.Location; break;
                case "Condition": Properties.Settings.Default.Condition = this.Location; break;
            }
            Properties.Settings.Default.Save();
        }
        #endregion

        
    }
}
