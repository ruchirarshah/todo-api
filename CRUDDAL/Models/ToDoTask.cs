using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUD_DAL.Models
{
    [Table("ToDoTasks", Schema = "dbo")]
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "TaskName")]
        public string TaskName { get; set; }

      
        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "UpdatedOn")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;

        [Required]
        [Display(Name = "IsComplete")]
        public bool IsComplete { get; set; } = false;

    }
}
