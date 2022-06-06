using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("GoiTap")]
    public class GoiTap
    {
        public GoiTap()
        {
            this.TheHVs = new HashSet<TheHV>();
        }
        
        [Key]
        [StringLength(9)]
        [Required]
        public string MaGT { get; set; }
        public string TenGT { get; set; }
        public string ThoiHan { get; set; }
        public double Gia { get; set; }
        public virtual ICollection<TheHV> TheHVs { get; set; }


    }
}
