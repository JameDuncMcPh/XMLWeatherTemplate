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

                if (child.Name == "location")
                {
                    foreach (XmlNode grandchild in child.ChildNodes)
                    {
                        if (grandchild.Name == "name")
                        {
                            locationLabel.Text = grandchild.InnerText;
                        }

                        if  (grandchild.Name == "country")
                        {
                            locationLabel.Text +=  ", " + grandchild.InnerText;
                        }
                    }
                }

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
                                    dateLabel.Text = Convert.ToDateTime(grandchild.Attributes["day"].Value).ToString("MMM dd");

                                    foreach (XmlNode greatgrandchild in grandchild.ChildNodes)
                                    {
                                        if (greatgrandchild.Name == "symbol")
                                        {
                                            if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 300)
                                            {
                                                weatherBox.BackgroundImage = Properties.Resources._4;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 600)
                                            {
                                                weatherBox.BackgroundImage = Properties.Resources._3;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 700)
                                            {
                                                weatherBox.BackgroundImage = Properties.Resources._5;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) == 800)
                                            {
                                                weatherBox.BackgroundImage = Properties.Resources._0;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 900)
                                            {
                                                weatherBox.BackgroundImage = Properties.Resources._1;
                                            }
                                        }
                                        if (greatgrandchild.Name == "windSpeed")
                                        {
                                            windLAbel.Text = greatgrandchild.Attributes["name"].Value;
                                        }
                                        if (greatgrandchild.Name == "temperature")
                                        {
                                            tempLabel.Text = greatgrandchild.Attributes["max"].Value + " - " + greatgrandchild.Attributes["min"].Value;
                                        }
                                    }
                                }
                                #endregion
                                break;

                            case 2:
                                #region Get Data
                                if (grandchild.Name == "time")
                                {
                                    date2Label.Text = Convert.ToDateTime(grandchild.Attributes["day"].Value).ToString("MMM dd");

                                    foreach (XmlNode greatgrandchild in grandchild.ChildNodes)
                                    {
                                        if (greatgrandchild.Name == "symbol")
                                        {
                                            if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 300)
                                            {
                                                weather2Box.BackgroundImage = Properties.Resources._4;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 600)
                                            {
                                                weather2Box.BackgroundImage = Properties.Resources._3;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 700)
                                            {
                                                weather2Box.BackgroundImage = Properties.Resources._5;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) == 800)
                                            {
                                                weather2Box.BackgroundImage = Properties.Resources._0;
                                            }
                                            else if (Convert.ToInt16(greatgrandchild.Attributes["number"].Value) < 900)
                                            {
                                                weather2Box.BackgroundImage = Properties.Resources._1;
                                            }
                                        }
                                        if (greatgrandchild.Name == "windSpeed")
                                        {
                                            wind2Label.Text = greatgrandchild.Attributes["name"].Value;
                                        }
                                        if (greatgrandchild.Name == "temperature")
                                        {
                                            temp2Label.Text = greatgrandchild.Attributes["max"].Value + " - " + greatgrandchild.Attributes["min"].Value;
                                        }
                                    }
                                }
                                #endregion
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
