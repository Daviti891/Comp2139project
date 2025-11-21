using Comp2139Project.Areas.ProjectManagement.Controllers;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Comp2139Project.Models;

namespace Comp2139Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        // Lab 6 - Part1 - #3 - General Search for Projects or ProjectTasks
        // Redirects users to the appropriate search function
        [HttpGet]
        public IActionResult GeneralSearch(string searchType, string searchString)
        {
            // Ensure searchType is not null and handle case-insensitivity
            searchType = searchType?.Trim().ToLower() ?? string.Empty;  
        
            // Ensure the search string is not empty
            if (string.IsNullOrWhiteSpace(searchType) || string.IsNullOrWhiteSpace(searchString))
            {
                // Redirect back to home if the search is empty
                return RedirectToAction(nameof(Index), "Home");
            }
        
            // Determine where to redirect based on search type
            if (searchType == "projects")
            {
                // Redirect to Project search
                return RedirectToAction("Search", "Project", new { area = "ProjectManagement", searchString });
            }
            else if (searchType == "tasks")
            {               
                // Redirect to ProjectTask search
                return RedirectToAction("Search", "ProjectTask", new { area = "ProjectManagement", searchString });             
            }
        
            // If searchType is invalid, redirect to Home page
            return RedirectToAction(nameof(Index), "Home");
        }
        
        //Lab 6 - #1 - c - NotFound() Action added
        public IActionResult NotFound(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }
        
            return View("Error");
        }
    }
}
