using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangGame.Model
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public virtual Computer Computer { get; set; }

        public int OpenedByUserId { get; set; }
        [ForeignKey("OpenedByUserId")]
        public virtual User OpenedByUser { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [StringLength(100)]
        public string GuestName { get; set; }

        [Column(TypeName = "decimal")]
        public decimal PricePerHour { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;

        public DateTime? EndTime { get; set; }

        [Column(TypeName = "decimal")]
        public decimal? HoursUsed { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Active";
    }
}
