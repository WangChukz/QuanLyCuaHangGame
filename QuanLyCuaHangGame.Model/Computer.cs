using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangGame.Model
{
    public class Computer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [Required]
        [StringLength(10)]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Tier { get; set; }

        [StringLength(100)]
        public string Cpu { get; set; }

        [StringLength(100)]
        public string Gpu { get; set; }

        [StringLength(50)]
        public string Ram { get; set; }

        [StringLength(100)]
        public string Storage { get; set; }

        [Required]
        [StringLength(20)]
        public string Condition { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
