using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Entities
{
    public class ToDoList
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Text { get; set; }
    }
}
