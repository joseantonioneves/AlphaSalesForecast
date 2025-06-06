using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class AppPortifolio
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long AppId { get; set; }
    public string? ApplicationName { get; set; }
    public bool? IsActive { get; set; }
    public virtual ICollection<EnrollmentModel> EnrollmentModels { get; set; } = new List<EnrollmentModel>();
}
