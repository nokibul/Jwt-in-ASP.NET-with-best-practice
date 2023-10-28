using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Agency.Models.Entities.MemberRole;
using Agency.Models.Entities.RolePermission;

namespace Agency.Models.Entities.Role;
public class RoleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public ICollection<MemberRoleEntity> RoleMembers { get; set; }

    public ICollection<RolePermissionEntity> RolePermissions { get; set; }
}
