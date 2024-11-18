using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkeyWebManage.Domain.Entites;

public class CartDetail
{
    [Key]  // Đánh dấu thuộc tính này là khóa chính
    public int CartDetailId { get; set; }

    public int CartId { get; set; }
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]  // Định nghĩa kiểu cột cho thuộc tính Price
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    // Các thuộc tính khác...
}
