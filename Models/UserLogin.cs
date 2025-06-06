using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class UserLogin
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserLoginId { get; set; }

    public DateTime? CreateLogin { get; set; }

    public DateTime? LogTime { get; set; }

    public bool? AuthenticateResult { get; set; }

    public string? Log { get; set; }

    public long UserModelUserId { get; set; }

    public virtual UserModel UserModelUser { get; set; } = null!;
}
