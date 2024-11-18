using System;
using System.ComponentModel.DataAnnotations;

namespace BulkeyWebManage.Domain.Entites;

public class Cart
{
    [Key]  // Đánh dấu thuộc tính này là khóa chính
    public int CartId { get; set; }

    public string? Note { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedOn { get; set; }
    // Các thuộc tính khác...
}
