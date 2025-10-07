using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Comp2139Project.Controllers
{
    public class ProjectsController : Controller
    {
        // Action to show all projects
        public IActionResult Index()
        {
            // Sample project data
            var projects = new List<Project>
            {
                new Project { Id = 1, Name = "Artificial Intelligence Research", Description = "Exploring AI technologies" },
                new Project { Id = 2, Name = "Web Development", Description = "Developing a flower shop website" },
                new Project { Id = 3, Name = "App Development", Description = "Mobile app development project" }
            };

            // Send the data to the view.
            return View(projects);
        }
    }

    // A simple model class for demonstration purposes
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}