using BoredApi.Helpers;
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
        [Parameter]
        public bool IsFavourite { get; set; } = false;

        private Dictionary<float, string> PriceDictionary;
        private Dictionary<float, string> AccessibilityDictionary;

        protected override void OnInitialized()
        {
            PriceDictionary = BoredApiLists.PriceRanges.ToDictionary(x => x.Price, x => x.Name);
            AccessibilityDictionary = BoredApiLists.AccessibilityRanges.ToDictionary(x => x.Accessibility, x => x.Name);
        }

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
            IsFavourite = !IsFavourite;
            await OnFavourite.InvokeAsync();
        }
    }
}
