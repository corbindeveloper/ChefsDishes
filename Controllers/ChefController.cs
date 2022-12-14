using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers;

public class ChefController : Controller
{
    private ChefsDishesContext _context;

    // here we can "inject" our context service into the constructor
    public ChefController(ChefsDishesContext context)
    {
        _context = context;
    }

    // =====================================
    // INDEX
    [HttpGet("/")]
    public IActionResult AllChefs()
    {
        List<Chef> AllChefs = _context.Chefs.Include(dish => dish.AllDishes).ToList();

        return View("AllChefs", AllChefs);
    }

    // =====================================
    // NEW
    [HttpGet("/new/chef")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }

    // =====================================
    // CREATE
    [HttpPost("/create/chef")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid == false) {
            // by not defaulting the return of View() in New, we can invoke the New() function & not have to re-write code return View("New");

            return NewChef();
        }

        //this only runs if ModelState.IsValid == true
        _context.Chefs.Add(newChef);
        // our sql database doesn't update until we save changes
        // after calling SaveChanges, our newPost will now have a value stored in PostId that was automatically generated by our database
        _context.SaveChanges();

        return AllChefs();
    }

 }