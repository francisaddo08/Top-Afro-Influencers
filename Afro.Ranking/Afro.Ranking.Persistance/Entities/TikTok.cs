using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Afro.Ranking.Persistance.Entities
{
    public class TikTok
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Influencer")]
        public int InfluencerId { get; set; }
        public Int64 Followers { get; set; }
        public Int64 Views { get; set; }
        public string? IconImage { get; set; }

    }
}
