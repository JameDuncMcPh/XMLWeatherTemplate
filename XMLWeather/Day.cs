using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    class Day
    {
        int high, low, windspeed, chanceorain;
        string clouds;

        public Day(int high_, int low_, int windspeed_, int chanceorain_, string clouds_)
        {
            high = high_;
            low = low_;
            windspeed = windspeed_;
            chanceorain = chanceorain_;
            clouds = clouds_;
        }
        
    }
}
