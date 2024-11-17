using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace  Afro.Ranking.Persistance.Entities
{
    public class Instagram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Influencer")]
        public int InfluencerId { get; set; }
        public Int64 Followers { get; set; }
        public double EngagementRate { get; set; }
        public Int64  AverageLikes { get; set; }
        public double   AverageComments { get; set; }
        public string? IconImage { get; set; }

    }
}