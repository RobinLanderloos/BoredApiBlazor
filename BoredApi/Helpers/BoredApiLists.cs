using BoredApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BoredApi.Helpers
{
    public static class BoredApiLists
    {
        public static List<PriceRange> PriceRanges
        {
            get
            {
                var ranges = new List<PriceRange>
                {
                    new() { Id = 1, Price = 0f, Name = "Free" },
                    new() { Id = 2, Price = 0.25f, Name = "Cheap" },
                    new() { Id = 3, Price = 0.5f, Name = "Normal" },
                    new() { Id = 4, Price = 0.75f, Name = "Expensive" },
                    new() { Id = 5, Price = 1.0f, Name = "Very expensive" }
                };

                ranges = ranges.OrderBy(x => x.Id).ToList();
                return ranges;
            }
        }

        public static List<AccessibilityRange> AccessibilityRanges
        {
            get
            {
                var ranges = new List<AccessibilityRange>
                {
                    new() { Id = 1, Accessibility = 0f, Name = "For everyone" },
                    new() { Id = 2, Accessibility = 0.25f, Name = "For almost everyone" },
                    new() { Id = 3, Accessibility = 0.5f, Name = "For most people" },
                    new() { Id = 4, Accessibility = 0.75f, Name = "Not for everyone" },
                    new() { Id = 5, Accessibility = 1.0f, Name = "Not for most people" }
                };

                ranges = ranges.OrderBy(x => x.Id).ToList();
                return ranges;
            }
        }

        public static List<string> ActivityTypes
        {
            get
            {
                var types = new List<string>
                {
                    "",
                    "Cooking",
                    "Busywork",
                    "Recreational",
                    "Education",
                    "Relaxation",
                    "Social",
                    "DIY",
                    "Music",
                    "Charity",
                };

                types.Sort();
                return types;
            }
        }
    }
}