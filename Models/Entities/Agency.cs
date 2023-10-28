using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Agency.Models.Entities.Member;

namespace Agency.Models.Entities.Agency;

public class AgencyEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }
    public string Location { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public ICollection<MemberEntity> Users { get; set; }
    public string logo { get; set; }
}
