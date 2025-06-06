using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class OrganizationModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long OrganizationId { get; set; }
    public string? Razao { get; set; }
    public string Cnpj { get; set; } = null!;
    public bool? IsActive { get; set; }
    public string? Address { get; set; }
    public string? NumberAddr { get; set; }
    public string? ZipCode { get; set; }
    public string? District { get; set; }
    public string? CreditCardNumber { get; set; }
    public string? Cv { get; set; }
    public string? EmailContact { get; set; }
    public long CityModelCityId { get; set; }
    public virtual CityModel CityModelCity { get; set; } = null!;
    public virtual ICollection<SignatureModel> SignatureModels { get; set; } = new List<SignatureModel>();
}
