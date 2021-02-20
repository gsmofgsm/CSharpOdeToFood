using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant // implement IValidatableObject to have more validation options 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
