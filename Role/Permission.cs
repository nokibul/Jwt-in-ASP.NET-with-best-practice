using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Agency.Models.Entities.RolePermission;

namespace Agency.Models.Entities.Permission;

public class PermissionEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }
    public ICollection<RolePermissionEntity> PermissionRoles { get; set; }
}
