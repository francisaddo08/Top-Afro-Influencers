using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Afro.Ranking.Domain.Entities
{
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("InfluencerDetail")]
        public int InfluencerDetailId { get; set; }
        public string? Name { get; set; }
        public int? Followers { get; set; }
        public int? Subcribers { get; set; }
        public int? Views { get; set; }
        public string? ImageUrl { get; set; }
    }
}
