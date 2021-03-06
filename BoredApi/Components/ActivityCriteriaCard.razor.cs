using BoredApi.Helpers;
using BoredApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BoredApi.Components
{
    public partial class ActivityCriteriaCard
    {
        [Parameter]
        public List<ActivityResponse> Activities { get; set; }
        [Parameter]
        public EventCallback<List<ActivityResponse>> ActivitiesChanged { get; set; }

        private bool gettingActivities;
        private string selectedType = "";
        private int participants;

        private PriceRange selectedMinPrice = new();
        private PriceRange selectedMaxPrice = new();

        private AccessibilityRange selectedMinAccessibilityRange = new();
        private AccessibilityRange selectedMaxAccessibilityRange = new();

        private ElementReference minPriceSelect;
        private ElementReference maxPriceSelect;
        private ElementReference minAccessibilitySelect;
        private ElementReference maxAccessibilitySelect;

        private readonly List<string> types = BoredApiLists.ActivityTypes;
        private readonly List<PriceRange> priceRanges = BoredApiLists.PriceRanges;
        private readonly List<AccessibilityRange> accessibilityRanges = BoredApiLists.AccessibilityRanges;

        protected override void OnInitialized()
        {
            Http.BaseAddress = new Uri("https://www.boredapi.com/api/activity");
        }

        private async Task CureBoredom()
        {
            StringBuilder builder = new("?");
            if (selectedMinPrice.Id > 0 || selectedMaxPrice.Id > 0)
            {
                builder.Append($"minprice={selectedMinPrice.Price}&maxprice={selectedMaxPrice.Price}");
            }
            if (selectedMinAccessibilityRange.Id > 0 || selectedMaxAccessibilityRange.Id > 0)
            {
                builder.Append('&');
                builder.Append($"minaccessibility={selectedMinAccessibilityRange.Accessibility}&maxaccessibility={selectedMaxAccessibilityRange.Accessibility}");
            }
            if (participants > 0)
            {
                builder.Append('&');
                builder.Append($"participants={participants}");
            }
            if (!string.IsNullOrEmpty(selectedType))
            {
                builder.Append('&');
                builder.Append($"type={selectedType.ToLower()}");
            }

            var queryString = builder.ToString();

            Activities = new();
            gettingActivities = true;
            await ActivitiesChanged.InvokeAsync(Activities);
            for (int i = 0; i < 4; i++)
            {
                var activity = await Http.GetFromJsonAsync<ActivityResponse>(queryString);
                if (!activity.HasError)
                {
                    Activities.Add(activity);
                    await ActivitiesChanged.InvokeAsync(Activities);
                }
            }
            gettingActivities = false;
        }

        private void TypeSelected(ChangeEventArgs e)
        {
            selectedType = e.Value.ToString();
        }

        private async Task MinPriceSelected(ChangeEventArgs e)
        {
            var selectedId = Convert.ToInt32(e.Value);

            if (selectedMaxPrice.Id < selectedId)
            {
                await MaxPriceSelected(new ChangeEventArgs() { Value = selectedId });
                await JSRuntime.InvokeVoidAsync("appFunctions.selectElement", maxPriceSelect, selectedId - 1);
            }

            selectedMinPrice = priceRanges.First(x => x.Id == selectedId);
        }

        private async Task MaxPriceSelected(ChangeEventArgs e)
        {
            var selectedId = Convert.ToInt32(e.Value);

            if (selectedMinPrice.Id > selectedId)
            {
                await MinPriceSelected(new ChangeEventArgs() { Value = selectedId });
                await JSRuntime.InvokeVoidAsync("appFunctions.selectElement", minPriceSelect, selectedId - 1);
            }

            selectedMaxPrice = priceRanges.First(x => x.Id == selectedId);
        }

        private async Task MinAccessibilitySelected(ChangeEventArgs e)
        {
            var selectedId = Convert.ToInt32(e.Value);

            if (selectedMaxAccessibilityRange.Id < selectedId)
            {
                await MaxAccessibilitySelected(new ChangeEventArgs() { Value = selectedId });
                await JSRuntime.InvokeVoidAsync("appFunctions.selectElement", maxAccessibilitySelect, selectedId - 1);
            }

            selectedMinAccessibilityRange = accessibilityRanges.First(x => x.Id == selectedId);
        }

        private async Task MaxAccessibilitySelected(ChangeEventArgs e)
        {
            var selectedId = Convert.ToInt32(e.Value);

            if (selectedMinAccessibilityRange.Id > selectedId)
            {
                await MinAccessibilitySelected(new ChangeEventArgs() { Value = selectedId });
                await JSRuntime.InvokeVoidAsync("appFunctions.selectElement", minAccessibilitySelect, selectedId - 1);
            }

            selectedMaxAccessibilityRange = accessibilityRanges.First(x => x.Id == selectedId);
        }

        private void ClearFilters()
        {
        }

        
    }
}