using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        #region Variables
        //ints
        int day1, mounth, year, finaltotoal = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();

            // get information about current and forecast weather from the internet
            GetData();

            // take info from the current weather file and display it to the screen
            // ExtractCurrent();

            // take info from the forecast weather file and display it to the screen
            //ExtractForecast();

            // f is the form that this control is on - ("this" is the current User Control)
            Form f = this.FindForm();
            f.Controls.Remove(this);

            //if there is a wrong press then game over
            Current ms = new Current();
            f.Controls.Add(ms);
        }

        private static void GetData()
        {
            WebClient client = new WebClient();

            string currentFile = "http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0";
            string forecastFile = "http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0";
            
            client.DownloadFile(currentFile, "WeatherData.xml");
            client.DownloadFile(forecastFile, "WeatherData7Day.xml");
        }     

        private void MakePictureParent()
        {
            
        }

    }
}
