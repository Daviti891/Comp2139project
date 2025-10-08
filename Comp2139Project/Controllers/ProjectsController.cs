using Microsoft.AspNetCore.Mvc;
using Comp2139Project.Models;   
using System.Collections.Generic;

namespace Comp2139Project.Controllers
{
    public class ProjectsController : Controller
    {
        private static List<Project> projects = new()
        {
            new Project { Id = 1, Title = "Artificial Intelligence Research", Description = "Exploring AI", Owner = "John", StartDate = DateTime.Now },
            new Project { Id = 2, Title = "Digital Shop", Description = "Floral Online Store", Owner = "Bobby", StartDate = DateTime.Now },
            new Project { Id = 3, Title = "Personal Health Monitor", Description = "A mobile application designed to monitor fitness progress and health objectives", Owner = "Jane", StartDate = DateTime.Now }
        };


        public IActionResult Index()
        {
            return View(projects);   
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Project project)
        {
            project.Id = projects.Count + 1;
            projects.Add(project);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var project = projects.Find(p => p.Id == id);
            if (project == null) return NotFound();
            return View(project);
        }
    }
}