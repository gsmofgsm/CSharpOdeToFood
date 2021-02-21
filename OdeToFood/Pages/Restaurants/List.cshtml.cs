using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }  // to access in the page via @Model.Message
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet() // model binding, it will look in post request, query string, headers ..., even custom binder
        {// if searchTerm is not found, it will be given null reference, if its type is int, there will be null reference exception, but with string, it is ok
            // HttpContext.Request.QueryString;  // each razor page has a HttpContext property
            // but a better way is model binding

            logger.LogError("Executing ListModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
