using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Agency.Models.Entities.MemberRole;

namespace Agency.Member.Entities;
public class MemberEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    // public Guid AgencyId { get; set; }
    // public virtual AgencyEntity Agency { get; set; }

    [StringLength(255)]
    public string FirstName { get; set; }

    [StringLength(255)]
    public string LastName { get; set; }

    [Required]
    [StringLength(255)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    public string ContactNo { get; set; }

    [StringLength(255)]
    public string Location { get; set; }

    [Required]
    [StringLength(255)]
    public string Gender { get; set; }

    [StringLength(255)]
    public string About { get; set; }

    [StringLength(255)]
    public string ProfileImage { get; set; }

    [StringLength(255)]
    public string Password { get; set; }

    [StringLength(255)]
    public string Language { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime DateRegistered { get; set; }

    public ICollection<MemberRoleEntity> MemberRoles { get; set; }
}