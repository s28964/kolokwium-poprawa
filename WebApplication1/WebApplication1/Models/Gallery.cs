using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Gallery")]
public class Gallery
{
    [Key]
    public int GalleryId { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    
    public DateTime EstablishmentDate { get; set; }
    
    public ICollection<Exhibition> Exhibitions { get; set; } = null!;
}