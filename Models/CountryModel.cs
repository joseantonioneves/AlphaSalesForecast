using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models;

public partial class CountryModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CountryId { get; set; }
    public string? Name { get; set; }
    public string? Codigo { get; set; }
    public string? Fone { get; set; }
    public string? Iso { get; set; }
    public string? Iso3 { get; set; }
    public string? NomeFormal { get; set; }
    public virtual ICollection<StateModel> StateModels { get; set; } = new List<StateModel>();
}
