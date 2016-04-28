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
    public partial class Current : UserControl
    {
        #region Varialbes
        //images
        Image[] weather = new Image[] {Properties.Resources._0, Properties.Resources._1, Properties.Resources._2,
                                        Properties.Resources._3, Properties.Resources._4, Properties.Resources._5,
                                            Properties.Resources._6, Properties.Resources._7};

        #endregion

        public Current()
        {
            InitializeComponent();
        }

        private void Current_Load(object sender, EventArgs e)
        {
            //Load the currnet weather
            ExtractCurrent();
        }

        private void ExtractCurrent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            //set date
            dateLabel.Text = DateTime.Now.ToString("MMM dd");

            //check each child of the parent element
            foreach (XmlNode child in parent.ChildNodes)
            {
                // if the "city" element is found display the value of it's "name" attribute
                if (child.Name == "city")
                {
                    locationLabel.Text = child.Attributes["name"].Value;

                    foreach (XmlNode grandchild in child.ChildNodes)
                    {
                        // show the current location
                        if (grandchild.Name == "country")
                        {
                            locationLabel.Text += ", " + grandchild.InnerText;
                        }
                    }
                }

                //show the current temperature and the range for the day
                if (child.Name == "temperature")
                {
                    tempLabel.Text = child.Attributes["max"].Value + " to " + child.Attributes["min"].Value + "   C";

                    currentLabel.Text = child.Attributes["value"].Value + " C";
                }

                //show the current type of wind outside
                if (child.Name == "wind")
                {
                    foreach (XmlNode grandchild in child.ChildNodes)
                    {
                        if (grandchild.Name == "speed")
                        {
                            windLAbel.Text = grandchild.Attributes["name"].Value;
                        }
                    }
                }

                //display a image depending on the current weather outside
                if (child.Name == "weather")
                {
                    if (Convert.ToInt16(child.Attributes["number"].Value) < 300)
                    {
                        weatherBox.BackgroundImage = Properties.Resources._4;
                    }
                    else if (Convert.ToInt16(child.Attributes["number"].Value) < 600)
                    {
                        weatherBox.BackgroundImage = Properties.Resources._3;
                    }
                    else if (Convert.ToInt16(child.Attributes["number"].Value) < 700)
                    {
                        weatherBox.BackgroundImage = Properties.Resources._5;
                    }
                    else if (Convert.ToInt16(child.Attributes["number"].Value) == 800)
                    {
                        weatherBox.BackgroundImage = Properties.Resources._0;
                    }
                    else if (Convert.ToInt16(child.Attributes["number"].Value) < 900)
                    {
                        weatherBox.BackgroundImage = Properties.Resources._1;
                    }
                }
            }
        }

        //switch the controls to the forecast screen
        private void button1_Click(object sender, EventArgs e)
        {
            // f is the form that this control is on - ("this" is the current User Control)
            Form f = this.FindForm();
            f.Controls.Remove(this);

            //if there is a wrong press then game over
            Forecast fc = new Forecast();
            f.Controls.Add(fc);
        }

    }
}
