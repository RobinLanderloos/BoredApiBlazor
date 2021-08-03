using BoredApi.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoredApi.Components
{
    public partial class ActivityCard
    {
        [Parameter]
        public ActivityResponse Activity { get; set; }

        private string GenerateHowToLink(string activity)
        {
            if (!string.IsNullOrEmpty(activity))
            {
                var howToQuery = "How to " + Activity.Activity;
                return "https://www.google.com/search?q=" + howToQuery.Replace(' ', '+');
            }

            return "https://www.google.com";
        }
    }
}
