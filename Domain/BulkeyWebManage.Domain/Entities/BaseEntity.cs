using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkeyWebManage.Domain.Entites;

public class BaseEntity
{
    //[Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// atribute Identity -> fiel auto increment
    [StringLength(1000)]
    public int Id { get; set; }

}
