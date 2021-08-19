using BoredApi.Models;
using System.Collections.Generic;

namespace BoredApi.Pages
{
    public partial class Bored
    {
        private List<ActivityResponse> Activities = new();
        private List<ActivityResponse> FavouriteActivities = new();

        private void HandleFavourite(ActivityResponse activity)
        {
            if(activity != null && !FavouriteActivities.Contains(activity))
            {
                FavouriteActivities.Add(activity);
                Activities.Remove(activity);
            }
            else if (FavouriteActivities.Contains(activity))
            {
                FavouriteActivities.Remove(activity);
                Activities.Add(activity);
            }
        }
    }
}