using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Agency.Models.Entities.Permission;
using Agency.Models.Entities.Role;

namespace Agency.Models.Entities.RolePermission;

public class RolePermissionEntity
{
    [Required]
    public Guid PermissionId { get; set; }

    [Required]
    public PermissionEntity Permission { get; set; }

    [Required]
    public Guid RoleId { get; set; }

    [Required]
    public RoleEntity Role { get; set; }
}
