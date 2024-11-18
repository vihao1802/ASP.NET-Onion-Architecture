using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BulkeyWebManage.Domain.Entites;

public class ApplicationUser:IdentityUser
{
    // [StringLength(500)]
    // public required string Fullname { get; set; }
    
    [StringLength(500)]
    public string? MobilePhone {get;set;}

    // [StringLength(500)]
    // public required string Address { get; set; }

    public bool IsActive{get;set;}

}
