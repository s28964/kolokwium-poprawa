using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Exhibition_Artwork")]
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
public class ExhibitionArtwork
{
    [ForeignKey(nameof(Exhibition))]
    public int ExhibitionId { get; set; }
    
    [ForeignKey(nameof(Artwork))]
    public int ArtworkId { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal InsuranceValue { get; set; }
    
    public Exhibition Exhibition { get; set; } = null!;
    
    public Artwork Artwork { get; set; } = null!;
}