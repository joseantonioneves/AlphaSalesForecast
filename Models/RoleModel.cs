using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class RoleModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long RoleId { get; set; }
    public string? RoleName { get; set; }
    public virtual ICollection<UserModel> UserModels { get; set; } = new List<UserModel>();
}
