using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Agency.Models.Entities.Role;
using Agency.Member.Entities;

namespace Agency.Models.Entities.MemberRole;

public class MemberRoleEntity
{
    [Required]
    public Guid MemberId { get; set; }

    [Required]
    public MemberEntity Member { get; set; }

    [Required]
    public Guid RoleId { get; set; }

    [Required]
    public RoleEntity Role { get; set; }
}
