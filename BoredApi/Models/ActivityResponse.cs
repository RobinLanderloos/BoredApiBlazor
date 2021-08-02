using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoredApi.Models
{
    public class ActivityResponse
    {
        public string Activity { get; set; }
        public double Accessibility { get; set; }
        public string Type { get; set; }
        public int Participants { get; set; }
        public double Price { get; set; }
        public string Link { get; set; }
        public string Key { get; set; }
        public string Error { get; set; }

        public bool HasError
        {
            get
            {
                return !string.IsNullOrEmpty(Error);
            }
        }
    }
}
