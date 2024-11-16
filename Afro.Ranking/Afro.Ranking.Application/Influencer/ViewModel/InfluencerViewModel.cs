using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Application.Influencer.ViewModel
{
    public class InfluencerViewModel
    {
        public string? ImageCssClass { get; set; }
        public string? NameCssClass { get; set; }
        public string? RankCssClass { get; set; }
        public string? ContainerCssClass { get; set; }
        public int? Rank { get; set; }
        public int? PositionInRow { get; set; }
        public int? RowGroup { get; set; }
        public string? Name { get; set; }
        public bool IsFaceBook { get; set; }
        public bool IsYouTube { get; set; }
        public bool? IsInstagram { get; set; }
        public bool? IsTwitter { get; set; }
        public string? Image { get; set; }

        public Int64 Total { get; set; }
        public string TotalStringValue { get; set; } = string.Empty;

    }
}
