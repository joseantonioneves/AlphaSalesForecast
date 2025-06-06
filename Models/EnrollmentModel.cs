using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class EnrollmentModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long EnrollmentId { get; set; }
    public long AppPortifolioAppId { get; set; }
    public long SignatureModelSignatureId { get; set; }
    public long UserModelUserId { get; set; }
    public virtual AppPortifolio AppPortifolioApp { get; set; } = null!;
    public virtual SignatureModel SignatureModelSignature { get; set; } = null!;
    public virtual UserModel UserModelUser { get; set; } = null!;
}
