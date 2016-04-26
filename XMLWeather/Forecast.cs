using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XMLWeather
{
    public partial class Forecast : UserControl
    {
        public Forecast()
        {
            InitializeComponent();
        }

        private void Forecast_Load(object sender, EventArgs e)
        {
            ExtractForecast();
        }

        public void ExtractForecast()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;
            int day = 0;

            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == "forecast")
                {
                    foreach (XmlNode grandchild in child.ChildNodes)
                    {

                        switch (day)
                        {
                            case 0:
                                day++;
                                break;

                            case 1:
                                day++;

                                #region Get Data
                                if (grandchild.Name == "time")
                                {
                                    dateLabel.Text = grandchild.Attributes["day"].Value;

                                    foreach (XmlNode greatgrandchild in grandchild.ChildNodes)
                                    {
                                        if (greatgrandchild.Name == "windSpeed")
                                        {
                                            windLAbel.Text = greatgrandchild.Attributes["name"].Value;
                                        }
                                        if (greatgrandchild.Name == "")
                                        {
                                        }
                                    }
                                }
                                #endregion
                                break;

                            case 2:
                                day++;
                                break;

                            default:
                                break;
                        }

                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // f is the form that this control is on - ("this" is the current User Control)
            Form f = this.FindForm();
            f.Controls.Remove(this);

            //if there is a wrong press then game over
            Current c = new Current();
            f.Controls.Add(c);
        }
    }
}
