using System.ComponentModel.DataAnnotations;

namespace Comp2139Project.Models;

public class Project
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public string Owner { get; set; }
}