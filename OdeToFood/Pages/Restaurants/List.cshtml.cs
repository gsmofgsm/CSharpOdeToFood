using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurant;

        public string Message { get; set; }  // to access in the page via @Model.Message

        public ListModel(IConfiguration config, IRestaurantData restaurant)
        {
            this.config = config;
            this.restaurant = restaurant;
        }

        public void OnGet()
        {
            Message = config["Message"];
        }
    }
}
