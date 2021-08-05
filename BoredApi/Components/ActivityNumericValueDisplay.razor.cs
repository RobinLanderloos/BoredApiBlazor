using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoredApi.Components
{
    public partial class ActivityNumericValueDisplay
    {
        [Parameter]
        public float Number { get; set; } = 0f;

        [Parameter]
        public string DisplayName { get; set; } = "Unknown";

        [Parameter]
        public Dictionary<float, string> NumberToTextValues { get; set; }

        private string displayValue;

        protected override void OnInitialized()
        {
            if (float.IsNaN(Number))
            {
                displayValue = "Invalid price value!";
            }
            else
            {
                foreach (var numberToTextValue in NumberToTextValues)
                {
                    if(Number <= numberToTextValue.Key)
                    {
                        displayValue = numberToTextValue.Value;
                        break;
                    }
                }

                if (!NumberToTextValues.Values.Contains(displayValue))
                {
                    displayValue = "Unkown value";
                }
            }
        }
    }
}