using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class BillModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long BillId { get; set; }
    /// <summary>
    /// Tipo do meio de pagamento...
    /// </summary>
    public string? Tipo { get; set; }
    public string? UrlApi { get; set; }
    public virtual ICollection<SignatureModel> SignatureModels { get; set; } = new List<SignatureModel>();
}
