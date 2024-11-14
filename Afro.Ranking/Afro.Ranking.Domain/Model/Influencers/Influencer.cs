using Afro.Ranking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afro.Ranking.Domain.Model.Influencers
{
    public class Influencer
    {
        private readonly HashSet<SocialMediaBase> _channels = new HashSet<SocialMediaBase>();
        private Influencer() { }
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public bool IsFaceBook { get; private set; } = false;
        public bool IsYouTube { get; private set; } = false;
        public bool IsInstagram { get; private set; } = false;
        public bool IsTwitter { get; private set; } = false;
        public bool IsTikTok { get; private set; } = false;
        public string Image { get; private set; } = string.Empty;
        public Int64 GetTotal()
        {
            
            if (_channels.Count == 0)
            {
                return 0;
            }

            return _channels.Select(c => c.Total).Sum();
        }
        // factory method for creating Influencer
        public static Influencer Create(string name, string city, string country, string image)
        {
            Influencer influencer = new Influencer()
            {
                City = city,
                Country = country,
                Image = image,
                Name = name
            };
            return influencer;
        }
        public void AddChannel(SocialMediaBase channel)
        {
            if (channel.GetType() == typeof(FaceBook))
            {
                IsFaceBook = true;
            }
            if (channel.GetType() == typeof(TikTok))
            {
                IsTikTok = true;
            }
            if (channel.GetType() == typeof(Twitter))
            {
                IsTwitter = true;
            }
            if (channel.GetType() == typeof(YouTube))
            {
                IsYouTube = true;
            }
            _channels.Add(channel);
        }


    }
    public abstract class SocialMediaBase
    {
        public int Id { get; set; }
        public virtual long Total { get; }
    }
    public class FaceBook : SocialMediaBase
    {
        public long Likes { get; set; }
        public long TalkingAbout { get; set; }
        public string IconImage { get; set; } = string.Empty;
        public override long Total { get { return Likes + TalkingAbout; } }
    }
    public class YouTube : SocialMediaBase
    {
        public long Subscribers { get; set; }
        public long Views { get; set; }
        public string IconImage { get; set; } = string.Empty;
        public override long Total { get { return Subscribers + Views; } }
    }
    public class Instagram : SocialMediaBase
    {
        public long Followers { get; set; }
        public long EngagementRate { get; set; }
        public long AverageLikes { get; set; }
        public long AverageComments { get; set; }
        public string IconImage { get; set; } = string.Empty;
        public override long Total
        {
            get { return Followers + EngagementRate + AverageComments + AverageLikes; }

        }
        public class Twitter : SocialMediaBase
        {
            public long Followers { get; set; }
            public string IconImage { get; set; } = string.Empty;
            public override long Total { get { return Followers ; } }
        }
    }
}
