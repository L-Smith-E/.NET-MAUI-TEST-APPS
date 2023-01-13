using System.ComponentModel.DataAnnotations;

namespace MAUI_Test_API.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string? ToDoName { get; set; }
    }
}
