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
        [Parameter]
        public EventCallback<int> OnFavourite { get; set; }

        private bool isFavourite = false;

        private string GenerateHowToLink(string activity)
        {
            if (!string.IsNullOrEmpty(activity))
            {
                var howToQuery = "How to " + Activity.Activity;
                return "https://www.google.com/search?q=" + howToQuery.Replace(' ', '+');
            }

            return "https://www.google.com";
        }

        private async Task Favourite()
        {
            isFavourite = !isFavourite;
            await OnFavourite.InvokeAsync();
        }
    }
}
