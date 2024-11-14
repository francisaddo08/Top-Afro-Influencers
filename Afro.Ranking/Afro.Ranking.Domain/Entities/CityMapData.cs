using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Domain.Entities
{
    public class CityMapData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Influencer")]
        public int InfluencerId { get; set; }
        public string? PlaceId { get; set; }

        public double? BoundsNELat { get; set; }
        public double? BoundsNELong { get; set; }
        public double? BoundsSWLat { get; set; }
        public double? BoundSWLong { get; set; }

        public double? ViewPortNELat { get; set; }
        public double? ViewPortNELong { get; set; }
        public double? ViewPortSWLat { get; set; }
        public double? ViewPortSWLong { get; set; }

        public double? LocationLat { get; set; }
        public double? LocationLong { get; set; }
    }
}
