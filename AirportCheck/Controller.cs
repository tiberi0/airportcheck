using MongoDB.Bson;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AirportCheck
{

    public partial class Controller : Form
    {
        private ControllerAPI controllerApi;

        public SplashScreen splash;
        public AirportDetailInfo temperatureInfo;
        public AirportDetailInfo windInfo;
        public AirportDetailInfo conditionInfo;
        public AirplaneList arrivalsInfo;
        public AirplaneList departuresInfo;

        public string programStatus = "starting";

        Thread t;

        public Controller()
        {
            InitializeComponent();
            //this.timer1.Interval = 1000 * 180;

            controllerApi = new ControllerAPI();

            splash = new SplashScreen();
            splash.Show();

            splash.progressValue = 15;
            splash.infoText = "Build the user interface...";

            temperatureInfo = new AirportDetailInfo("Temperature");

            windInfo = new AirportDetailInfo("Wind");

            conditionInfo = new AirportDetailInfo("Condition");

            arrivalsInfo = new AirplaneList("ARRIVALS");

            departuresInfo = new AirplaneList("DEPARTURES");

            t = new Thread(new ThreadStart(startWidgets));
            t.Start();
        }

        public void startWidgets()
        {
            getDataFR24();
            programStatus = "finished";
        }

        void startProgram()
        {
            splash.Hide();
            tbAeroporto.Text = Properties.Settings.Default.AirportCode;
            this.Opacity = 100;

            temperatureInfo.Show();
            temperatureInfo.Location = Properties.Settings.Default.Temperature;

            windInfo.Show();
            windInfo.Location = Properties.Settings.Default.Wind;

            conditionInfo.Show();
            conditionInfo.Location = Properties.Settings.Default.Condition;

            arrivalsInfo.Show();
            arrivalsInfo.Location = Properties.Settings.Default.Arrivals;

            departuresInfo.Show();
            departuresInfo.Location = Properties.Settings.Default.Departures;
        }

        #region Check's Events 

        private void cbTemperature_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTemperature.Checked)
                temperatureInfo.Show();
            else
                temperatureInfo.Hide();
        }

        private void cbConditions_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConditions.Checked)
                conditionInfo.Show();
            else
                conditionInfo.Hide();
        }

        private void cbWind_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWind.Checked)
                windInfo.Show();
            else
                windInfo.Hide();
        }

        private void cbArrivals_CheckedChanged(object sender, EventArgs e)
        {
            if (cbArrivals.Checked)
                arrivalsInfo.Show();
            else
                arrivalsInfo.Hide();
        }

        private void cbDepartures_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDepartures.Checked)
                departuresInfo.Show();
            else
                departuresInfo.Hide();
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (programStatus == "monitoring")
            {
                getDataFR24();
            }
            else
            {
                if (programStatus == "finished")
                {
                    this.timer1.Interval = 1000 * 180;
                    programStatus = "monitoring";
                    startProgram();
                }
            }

        }

        private void getDataFR24()
        {
            splash.progressValue = 30;
            splash.infoText = "Loading Airport Info...";
            setAirportInfo();
            Thread.Sleep(1000);
            splash.progressValue = 60;
            splash.infoText = "Loading Arrivals...";
            setArrivals();            
            Thread.Sleep(1000);
            splash.progressValue = 80;
            splash.infoText = "Loading Departures...";
            setDepartures();
            Thread.Sleep(1000);
            splash.progressValue = 100;
            splash.infoText = "Finished!";
            Thread.Sleep(1000);
        }

        private void setAirportInfo()
        {
            BsonDocument airportInfo = controllerApi.getAirportInfo();

            temperatureInfo.setDetailValue(airportInfo["temperature"].AsString);

            windInfo.setDetailValue(airportInfo["wind"].AsString);

            conditionInfo.setDetailValue(airportInfo["condition"].AsString);            
        }

        /// <summary>
        /// Get and set arrivals in Airplane list form
        /// </summary>
        private void setArrivals()
        {
            try
            {
                BsonDocument docArr = controllerApi.getArrivalsDepartures("arrivals");

                arrivalsInfo.loadAirplanes(docArr["arrivals"].AsBsonArray);
            }catch(Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
        }

        /// <summary>
        /// Get and set Departures in Airplane list form
        /// </summary>
        private void setDepartures()
        {
            try
            {
                BsonDocument docDep = controllerApi.getArrivalsDepartures("departures");

                departuresInfo.loadAirplanes(docDep["departures"].AsBsonArray);
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AirportCode = tbAeroporto.Text;
            Properties.Settings.Default.Save();
            getDataFR24();
        }

        private void cbBloquar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLock.Checked)
            {
                temperatureInfo.FormBorderStyle = FormBorderStyle.None;
                windInfo.FormBorderStyle = FormBorderStyle.None;
                conditionInfo.FormBorderStyle = FormBorderStyle.None;
                arrivalsInfo.FormBorderStyle = FormBorderStyle.None;
                departuresInfo.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                temperatureInfo.FormBorderStyle = FormBorderStyle.Sizable;
                windInfo.FormBorderStyle = FormBorderStyle.Sizable;
                conditionInfo.FormBorderStyle = FormBorderStyle.Sizable;
                arrivalsInfo.FormBorderStyle = FormBorderStyle.Sizable;
                departuresInfo.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((components != null))
            {
                components.Dispose();
            }
            base.Dispose(true);
        }
    }
}
