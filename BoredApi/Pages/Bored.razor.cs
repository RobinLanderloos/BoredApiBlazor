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

namespace BoredApi.Pages
{
    public partial class Bored
    {
        private List<ActivityResponse> Activities = new List<ActivityResponse>();
    }
}