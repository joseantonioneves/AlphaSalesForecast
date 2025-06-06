using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class SignatureModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long SignatureId { get; set; }

    public string? KeySignature { get; set; }

    public bool? IsActive { get; set; }

    public long OrganizationModelOrganizationId { get; set; }

    public long BillModelBillId { get; set; }

    public long AppId { get; set; }

    public string OrganizationModelCnpj { get; set; } = null!;

    public virtual BillModel BillModelBill { get; set; } = null!;

    public virtual ICollection<EnrollmentModel> EnrollmentModels { get; set; } = new List<EnrollmentModel>();

    public virtual OrganizationModel OrganizationModel { get; set; } = null!;
}
