using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class StateModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long StateId { get; set; }

    public string? Name { get; set; }

    public string? Uf { get; set; }

    public string? Ibgecode { get; set; }

    public string? Ddd { get; set; }

    public long CountryModelCountryId { get; set; }

    public virtual ICollection<CityModel> CityModels { get; set; } = new List<CityModel>();

    public virtual CountryModel CountryModelCountry { get; set; } = null!;
}
