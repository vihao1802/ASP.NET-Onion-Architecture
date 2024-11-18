using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BulkeyWebManage.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Bulkey.Domain.Entites;

public class UserAddress:BaseEntity
{
    
    [StringLength(500)]
    public required string Fullname{get;set;}
    [Required]
    [StringLength(500)]
    public required string PhoneNumber{get;set;}
    public string? Email {get;set;}
    public string? Address{get;set;}
    public string? IsActive{get;set;}
    public string? UserId{get;set;}
    [ForeignKey(nameof(UserId))]
    public ApplicationUser? ApplicationUser{get;set;}

}
