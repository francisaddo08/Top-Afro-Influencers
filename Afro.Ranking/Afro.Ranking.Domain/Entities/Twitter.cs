using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Afro.Ranking.Domain.Entities
{
    public class Twitter
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
