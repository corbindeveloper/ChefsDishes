#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }


    // DISH NAME
    [Required(ErrorMessage = "is required")]
    [Display(Name = "Dish Name:")]
    public string DishName { get; set; }


    // CALORIES
    [Required(ErrorMessage = "Calories is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Calories must be greater than 0.")]
    [Display(Name = "Total Calories:")]
    public int Calories { get; set; }


    // DESCRIPTION
    [Required(ErrorMessage = "is required")]
    [Display(Name = "Description:")]
    public string Description { get; set; }


    // CHEF NAME
    [Required(ErrorMessage = "is required")]
    [Display(Name = "Chef Name:")]
    public int ChefId { get; set; }


    // TASTINESS
    [Required(ErrorMessage = "Tastiness is required")]
    [Range(0, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    [Display(Name = "Tastiness:")]
    public int Tastiness { get; set; }

    // Navigation property for related Chef object
    public Chef? Cook { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}