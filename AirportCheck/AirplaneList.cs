using MongoDB.Bson;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AirportCheck
{
    public partial class AirplaneList : Form
    {
        private string mode = "";
        public AirplaneList(string mode)
        {
            this.mode = mode;
            InitializeComponent();
        }

        /// <summary>
        /// Load top 5 aiplane inside of list
        /// This function will be refactored in the future
        /// </summary>
        /// <param name="list"></param>
        public void loadAirplanes(BsonArray list)
        {            
            lbTitle.Text = this.mode + " - " + DateTime.Now.ToShortDateString();

            var flight1 = list[0].AsBsonDocument;
            try
            {
                if (flight1.Contains("status"))
                {
                    lbStatus1.Text = flight1["status"].AsString;                    
                    lbairplane1.Text = flight1["identification"].AsString;
                    lbCity1.Text = flight1["city"].AsString;
                    lbHour1.Text = flight1["hour"].AsString;
                    lbIata1.Text = flight1["iata"].AsString;                    
                    pbLogo1.Load(flight1["logo"].AsString);                    
                }
            }
            catch (Exception ae)
            {

            }

            var flight2 = list[1].AsBsonDocument;
            try
            {
                if (flight2.Contains("status"))
                {
                    lbStatus2.Text = flight2["status"].AsString;
                    lbAirplane2.Text = flight2["identification"].AsString;
                    lbCity2.Text = flight2["city"].AsString;
                    lbHour2.Text = flight2["hour"].AsString;
                    lbIata2.Text = flight2["iata"].AsString;
                    pbLogo2.Load(flight2["logo"].AsString);
                }
            }
            catch (Exception ae)
            {

            }

            var flight3 = list[2].AsBsonDocument;
            try
            {
                if (flight3.Contains("status"))
                {
                    lbStatus3.Text = flight3["status"].AsString;
                    lbAirplane3.Text = flight3["identification"].AsString;
                    lbCity3.Text = flight3["city"].AsString;
                    lbHour3.Text = flight3["hour"].AsString;
                    lbIata3.Text = flight3["iata"].AsString;
                    pbLogo3.Load(flight3["logo"].AsString);
                }
            }
            catch (Exception ae)
            {

            }

            var flight4 = list[3].AsBsonDocument;
            try
            {
                if (flight4.Contains("status"))
                {
                    lbStatus4.Text = flight4["status"].AsString;
                    lbAirplane4.Text = flight4["identification"].AsString;
                    lbCity4.Text = flight4["city"].AsString;
                    lbHour4.Text = flight4["hour"].AsString;
                    lbIata4.Text = flight4["iata"].AsString;
                    pbLogo4.Load(flight4["logo"].AsString);
                }
            }
            catch (Exception ae)
            {

            }

            var flight5 = list[4].AsBsonDocument;
            try
            {
                if (flight5.Contains("status"))
                {
                    lbStatus5.Text = flight5["status"].AsString;
                    lbAirplane5.Text = flight5["identification"].AsString;
                    lbCity5.Text = flight5["city"].AsString;
                    lbHour5.Text = flight5["hour"].AsString;
                    lbIata5.Text = flight5["iata"].AsString;
                    pbLogo5.Load(flight5["logo"].AsString);
                }
            }
            catch (Exception ae)
            {

            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);

                if (this.mode == "ARRIVALS")
                    Properties.Settings.Default.Arrivals = this.Location;

                if (this.mode == "DEPARTURES")
                    Properties.Settings.Default.Departures = this.Location;

                Properties.Settings.Default.Save();
            }
        }

        private void lbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);

                if (this.mode == "ARRIVALS")
                    Properties.Settings.Default.Arrivals = this.Location;

                if (this.mode == "DEPARTURES")
                    Properties.Settings.Default.Departures = this.Location;

                Properties.Settings.Default.Save();
            }
        }
    }    
}
