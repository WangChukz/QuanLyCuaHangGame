using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangGame.Model
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SessionId { get; set; }
        [ForeignKey("SessionId")]
        [Index(IsUnique = true)]
        public virtual Session Session { get; set; }

        public int ClosedByUserId { get; set; }
        [ForeignKey("ClosedByUserId")]
        public virtual User ClosedByUser { get; set; }

        [Column(TypeName = "decimal")]
        public decimal SessionAmount { get; set; }

        [Column(TypeName = "decimal")]
        public decimal ServiceAmount { get; set; }

        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal")]
        public decimal PaidByBalance { get; set; } = 0;

        [Column(TypeName = "decimal")]
        public decimal PaidByCash { get; set; } = 0;

        [Column(TypeName = "decimal")]
        public decimal ChangeGiven { get; set; } = 0;

        public DateTime PaidAt { get; set; } = DateTime.Now;
    }
}
