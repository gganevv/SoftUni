using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class PlayerStatistic
{
    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }

    public virtual Game Game { get; set; } = null!;

    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }

    public virtual Player Player { get; set; } = null!;

    [Required]
    public int ScoredGoals { get; set; }

    [Required]
    public int Assists { get; set; }

    [Required]
    public int MinutesPlayed { get; set; }
}