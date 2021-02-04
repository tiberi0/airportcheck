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
            this.Text = mode;
        }

        /// <summary>
        /// Load top 5 aiplane inside of list
        /// This function will be refactored in the future
        /// </summary>
        /// <param name="list"></param>
        public void loadAirplanes(BsonArray list)
        {            
            lbTitle.Text = this.mode + " - " + DateTime.Now.ToShortDateString();

            if (list.Count>0)
            {
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
                        lbStatus1.Visible = true;
                        lbairplane1.Visible = true;
                        lbCity1.Visible = true;
                        lbHour1.Visible = true;
                        lbIata1.Visible = true;
                        pbLogo1.Visible = true;
                        panel01.Visible = true;
                    }
                }
                catch (Exception ae)
                {

                }
            }
            else
            {
                lbStatus1.Visible = false;
                lbairplane1.Visible = false;
                lbCity1.Visible = false;
                lbHour1.Visible = false;
                lbIata1.Visible = false;
                pbLogo1.Visible = false;
                panel01.Visible = false;
            }


            if (list.Count > 1)
            {
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
                        lbStatus2.Visible = true;
                        lbAirplane2.Visible = true;
                        lbCity2.Visible = true;
                        lbHour2.Visible = true;
                        lbIata2.Visible = true;
                        pbLogo2.Visible = true;
                        panel2.Visible = true;
                    }
                }
                catch (Exception ae)
                {

                }
            }
            else
            {
                lbStatus2.Visible = false;
                lbAirplane2.Visible = false;
                lbCity2.Visible = false;
                lbHour2.Visible = false;
                lbIata2.Visible = false;
                pbLogo2.Visible = false;
                panel2.Visible = false;
            }

            if (list.Count > 2)
            {
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
                        lbStatus3.Visible = true;
                        lbAirplane3.Visible = true;
                        lbCity3.Visible = true;
                        lbHour3.Visible = true;
                        lbIata3.Visible = true;
                        pbLogo3.Visible = true;
                        panel3.Visible = true;
                    }
                }
                catch (Exception ae)
                {

                }
            }
            else
            {
                lbStatus3.Visible = false;
                lbAirplane3.Visible = false;
                lbCity3.Visible = false;
                lbHour3.Visible = false;
                lbIata3.Visible = false;
                pbLogo3.Visible = false;
                panel3.Visible = false;
            }

            if (list.Count > 3)
            {
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

                        lbStatus4.Visible = true;
                        lbAirplane4.Visible = true;
                        lbCity4.Visible = true;
                        lbHour4.Visible = true;
                        lbIata4.Visible = true;
                        pbLogo4.Visible = true;
                        panel4.Visible = true;
                    }
                }
                catch (Exception ae)
                {

                }
            }
            else
            {
                lbStatus4.Visible = false;
                lbAirplane4.Visible = false;
                lbCity4.Visible = false;
                lbHour4.Visible = false;
                lbIata4.Visible = false;
                pbLogo4.Visible = false;
                panel4.Visible = false;
            }


            if (list.Count > 4)
            {
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

                        lbStatus5.Visible = true;
                        lbAirplane5.Visible = true;
                        lbCity5.Visible = true;
                        lbHour5.Visible = true;
                        lbIata5.Visible = true;
                        pbLogo5.Visible = true;
                        panel5.Visible = true;
                    }
                }
                catch (Exception ae)
                {

                }
            }
            else
            {
                lbStatus5.Visible = false;
                lbAirplane5.Visible = false;
                lbCity5.Visible = false;
                lbHour5.Visible = false;
                lbIata5.Visible = false;
                pbLogo5.Visible = false;
                panel5.Visible = false;
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
