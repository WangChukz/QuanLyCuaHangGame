using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangGame.Model
{
    public class TopUpTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int ProcessedByUserId { get; set; }
        [ForeignKey("ProcessedByUserId")]
        public virtual User ProcessedByUser { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
