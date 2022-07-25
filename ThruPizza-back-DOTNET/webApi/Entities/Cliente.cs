using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class Cliente
{    
    [Key]
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public string VerificationToken { get; set; }
    public string ResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
    public DateTime? PasswordReset { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }

    public bool OwnsToken(string token) 
    {
        return this.RefreshTokens?.Where(x => x.Token == token) != null;
    }
}