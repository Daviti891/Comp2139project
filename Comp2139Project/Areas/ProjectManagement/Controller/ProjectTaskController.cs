using Comp2139Project.Areas.ProjectManagement.Models;
using Comp2139Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Comp2139Project.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]
    [Route("[area]/[controller]/[action]")]
    public class ProjectTaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index/{projectId:int}")]
        public async Task<IActionResult> Index(int projectId)
        {
            var tasks = await _context.ProjectTasks
                                .Where(t => t.ProjectId == projectId)
                                .ToListAsync();
            ViewBag.ProjectId = projectId;
            return View(tasks);
        }

        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var task = await _context.ProjectTasks
                            .Include(t => t.Project)
                            .FirstOrDefaultAsync(t => t.ProjectTaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpGet("Create/{projectId:int}")]
        public async Task<IActionResult> Create(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
            {
                return NotFound();
            }
            var task = new ProjectTask
            {
                ProjectId = projectId,
                Title = "",
                Description = ""
            };
            return View(task);
        }

        [HttpPost("Create/{projectId:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,ProjectId")] ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                await _context.ProjectTasks.AddAsync(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { projectId = task.ProjectId });
            }
            return View(task);
        }
    }
}
