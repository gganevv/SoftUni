using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class User
{
    public User()
    {
        Bets = new HashSet<Bet>();
    }

    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.UserUserNameMaxLength)]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstrants.UserPasswordMaxLength)]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstrants.UserEmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstrants.UserNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}