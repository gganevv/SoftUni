using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardMaxName)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; } 
    }
}
