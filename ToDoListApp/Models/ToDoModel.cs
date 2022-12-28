using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
       
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
