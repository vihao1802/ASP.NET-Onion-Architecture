using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkeyWebManage.Domain.Entites;

public class Book:BaseEntity
{

    
    [StringLength(500)]
    public required string Title {get; set;}

    [StringLength(500)]
    public string? Author {get; set;}

    [StringLength(500)]
    public required string Publisher { get; set; }

    [Required]
    public int Available {get; set;}
    public double Price {get; set;}
    public DateTime CreatedOn {get; set;}
    public bool IsActive{get;set;}

    //[Required]
    public required int GenreId{get; set;}

    [ForeignKey("GenreId")] //"GenreId", table GenreId get PK Id ref  GenreId is FK of Book 
    public required Genre Genre {get; set;}

}

  