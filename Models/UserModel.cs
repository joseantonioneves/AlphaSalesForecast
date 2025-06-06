using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string Salt { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? EmailAddress { get; set; }

    public string? Role { get; set; }

    public string? Surname { get; set; }

    public string? GivenName { get; set; }

    public bool? IsActive { get; set; }

    public long RoleModelRoleId { get; set; }

    public virtual ICollection<EnrollmentModel> EnrollmentModels { get; set; } = new List<EnrollmentModel>();

    public virtual RoleModel RoleModelRole { get; set; } = null!;

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
