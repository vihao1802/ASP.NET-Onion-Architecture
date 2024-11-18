using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using BulkeyWebManage.Domain.Entites;

public class Genre : BaseEntity// do thua ke , Genre con lại thuoc tinh con lại 
{
    [StringLength(250)]
    public string Name { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

}
