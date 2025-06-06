using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class CityModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CityId { get; set; }
    public string? Name { get; set; }
    public string? Ibge { get; set; }
    public long StateModelStateId { get; set; }
    public virtual ICollection<OrganizationModel> OrganizationModels { get; set; } = new List<OrganizationModel>();
    public virtual StateModel StateModelState { get; set; } = null!;
}
