using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BulkeyWebManage.Domain.Entites;

namespace Bulkey.Domain.Entites;

public class Catalogue:BaseEntity
{

    [Required]
    [StringLength(250)]
    public required string Name { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public bool IsActive { get; set; }

}