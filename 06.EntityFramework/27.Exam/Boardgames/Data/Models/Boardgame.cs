namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Boardgames.Data.Models.Enums;

public class Boardgame
{
    public Boardgame()
    {
        this.BoardgamesSellers = new HashSet<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;

    public double Rating { get; set; }

    public int YearPublished { get; set; }

    public CategoryType CategoryType { get; set; }

    public string Mechanics { get; set; } = null!;

    [ForeignKey(nameof(Creator))]
    public int CreatorId { get; set; }

    public virtual Creator Creator { get; set; }

    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
}
