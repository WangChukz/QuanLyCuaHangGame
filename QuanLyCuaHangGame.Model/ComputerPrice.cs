using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangGame.Model
{
    public class ComputerPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public virtual Computer Computer { get; set; }

        [Column(TypeName = "decimal")]
        public decimal PricePerHour { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public bool IsCurrent { get; set; } = true;
    }
}
