
using Afro.Ranking.Application.Constants;
using Afro.Ranking.Application.Influencer.ViewModel;
using Afro.Ranking.Domain.Model.Influencers;
using Afro.Ranking.Persistance.Repositories;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Afro.Ranking.Domain.Model.Influencers.Instagram;

namespace Afro.Ranking.Application.Influencer
{
    public class InfluencerService
    {
        public InfluencerService() { }
        public List<InfluencerViewModel> FakeInfluencers( int count)
        {
            List<InfluencerViewModel> viewModels = new();


            
            long? fakeTotal = 1000;
            if (count < 30)
            {
                for (int i = 0; i < (30 - count); i++)
                {
                    fakeTotal = fakeTotal + (100 * (i + 1));

                    viewModels.Add(new InfluencerViewModel
                    {
                        Name = "NoData",
                        IsFaceBook = true,
                        IsInstagram = true,
                        IsTwitter = true,
                        IsYouTube = true,
                        Total = (long) fakeTotal,
                    }
                );
                }
               
            }
            return viewModels;
        }
        public async Task<List<InfluencerViewModel>> GetInfluencerViewModels()
        {
            List<InfluencerViewModel> viewResult = new();
            var data = await GetInfluencers();
            if(data != null) 
            {
                foreach (var r in data.Where(s => s.Total() > 0))
                {
                    viewResult.Add(new InfluencerViewModel()
                    {
                        Name = r.Name,
                        Image = r.Image,
                        IsFaceBook = r.IsFaceBook,
                        IsInstagram = r.IsInstagram,
                        IsTwitter = r.IsTwitter,
                        IsYouTube = r.IsYouTube,
                        TotalStringValue = r.TotalString(),
                        Total = r.Total()
                    });
                }
            }
            if(viewResult.Count < ApplicationConstants.TotalInfluencers)
            {
                foreach (var item in FakeInfluencers(viewResult.Count).ToList())
                {
                    viewResult.Add(item);
                
                }
                
            }
            viewResult = viewResult.OrderByDescending(x => x.Total).ToList();
            int secondRowStart = 1;
            int rank = 0;

            foreach (var item in viewResult)
            {

                rank = rank + 1;
                item.Rank = rank;
                if (item.Rank == 1)
                {
                    item.RowGroup = 1;
                    item.PositionInRow = 3;
                    item.ImageCssClass = "top-image";
                    item.NameCssClass = "top-name";
                    item.RankCssClass = "top-rank";
                    item.ContainerCssClass = "top-container";
                }
                else if (item.Rank == 2)
                {
                    item.RowGroup = 1;
                    item.PositionInRow = 4;
                    item.ImageCssClass = "top-2-image";
                    item.NameCssClass = "top-2-name";
                    item.RankCssClass = "top-2-rank";
                    item.ContainerCssClass = "top2-container";
                }
                else if (item.Rank == 3)
                {
                    item.RowGroup = 1;
                    item.PositionInRow = 2;
                    item.ImageCssClass = "top-3-image";
                    item.NameCssClass = "top-3-name";
                    item.RankCssClass = "top-3-rank";
                    item.ContainerCssClass = "top3-container";
                }
                else if (item.Rank == 4)
                {

                    item.RowGroup = 1;
                    item.PositionInRow = 1;
                    item.ImageCssClass = "top-4-image";
                    item.NameCssClass = "top-4-name";
                    item.RankCssClass = "top-4-rank";
                    item.ContainerCssClass = "top4-container";
                }
                else if (item.Rank == 5)
                {

                    item.RowGroup = 1;
                    item.PositionInRow = 5;
                    item.ImageCssClass = "top-5-image";
                    item.NameCssClass = "top-5-name";
                    item.RankCssClass = "top-5-rank";
                    item.ContainerCssClass = "top5-container";
                }

                else if (item.Rank >= 6 && item.Rank < 13)
                {
                    item.RowGroup = 2;
                    item.PositionInRow = secondRowStart;
                    secondRowStart++;
                    if (item.Rank % 2 == 0)
                    {
                        item.ImageCssClass = "top20even-image";
                        item.NameCssClass = "top20even-name";
                        item.RankCssClass = "top20even-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }
                    else
                    {
                        item.ImageCssClass = "top20odd-image";
                        item.NameCssClass = "top20old-name";
                        item.RankCssClass = "top20old-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }
                }
                else if (item.Rank >= 13 && item.Rank <= 24)
                {
                    item.RowGroup = 3;
                    if (item.Rank == 13)
                    {
                        item.PositionInRow = 2;
                    }
                    else if (item.Rank == 14)
                    {
                        item.PositionInRow = 4;
                    }
                    else if (item.Rank == 15)
                    {
                        item.PositionInRow = 5;
                    }
                    else if (item.Rank == 16)
                    {
                        item.PositionInRow = 6;
                    }
                    else if (item.Rank == 17)
                    {
                        item.PositionInRow = 8;
                    }
                    else if (item.Rank == 18)
                    {
                        item.PositionInRow = 1;
                    }
                    else if (item.Rank == 19)
                    {
                        item.PositionInRow = 3;
                    }
                    else if (item.Rank == 20)
                    {
                        item.PositionInRow = 10;
                    }
                    else if (item.Rank == 21)
                    {
                        item.PositionInRow = 11;
                    }

                    else if (item.Rank == 22)
                    {
                        item.PositionInRow = 12;
                    }
                    else if (item.Rank == 23)
                    {
                        item.PositionInRow = 7;
                    }
                    else if (item.Rank == 24)
                    {
                        item.PositionInRow = 9;
                    }


                    if (item.Rank % 2 == 0)
                    {
                        item.ImageCssClass = "top30even-image";
                        item.NameCssClass = "top30old-name";
                        item.RankCssClass = "top30old-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }
                    else
                    {
                        item.ImageCssClass = "top30odd-image";
                        item.NameCssClass = "top30old-name";
                        item.RankCssClass = "top30old-rank";
                        item.ContainerCssClass = "top" + item.Rank + "-container";
                    }

                }
                else if (item.Rank > 24)
                {
                    item.RowGroup = 4;
                    item.PositionInRow = 6;
                    item.ImageCssClass = "last-image";
                    item.NameCssClass = "last-name";
                    item.RankCssClass = "last-rank";
                    item.ContainerCssClass = "top" + item.Rank + "-container";

                }


            }
            viewResult = viewResult.OrderBy(x => x.RowGroup).ToList();
            return viewResult;


        }

        public async Task<List<Domain.Model.Influencers.Influencer>> GetInfluencers()
        {
            List<Domain.Model.Influencers.Influencer> data = new();
            using (var repo = InfluencerRepository.GetInstance())
            {
                var d = await repo.GetAll();
                if (d != null)
                {
                    foreach (var item in d)
                    {
                        Domain.Model.Influencers.Influencer influencer =
                        Domain.Model.Influencers.Influencer.Create(item.Name ?? "", item.City ?? "", item.Country ?? "", item.Image ?? "");
                        FaceBook f = new FaceBook()
                        {
                            Likes = item.FaceBook == null ? 0 : item.FaceBook.Likes,
                            TalkingAbout = item.FaceBook == null ? 0 : item.FaceBook.TalkingAbout,
                            IconImage = item.FaceBook == null ? "" : item.FaceBook.IconImage ?? ""
                        };
                        influencer.AddChannel(f);
                        Instagram i = new Instagram()
                        {
                            Followers = item.Instagram == null ? 0 : item.Instagram.Followers,
                            AverageComments = item.Instagram == null ? 0 : (long)item.Instagram.AverageComments,
                            AverageLikes = item.Instagram == null ? 0 : item.Instagram.AverageLikes,
                            EngagementRate = item.Instagram == null ? 0 : (long)item.Instagram.EngagementRate,
                            IconImage = item.Instagram == null ? "" : item.Instagram.IconImage ?? "",

                        };
                        Twitter tw = new Twitter()
                        {
                            Followers = item.Twitter == null ? 0 : item.Twitter.Followers,
                            IconImage = item.Twitter == null ? "" : item.Twitter.IconImage ?? ""



                        };
                        TikTok ti = new TikTok()
                        {
                            Followers = item.TikTok == null ? 0 : item.TikTok.Followers,
                            Views = item.TikTok == null ? 0 : item.TikTok.Views,
                            IconImage = item.TikTok == null ? "" : item.TikTok.IconImage ?? ""



                        };
                        influencer.AddChannel(ti);
                        YouTube y = new YouTube()
                        {
                            Subscribers = item.YouTube == null ? 0 : item.YouTube.Subscribers,
                            Views = item.YouTube == null ? 0 : item.YouTube.Views,
                            IconImage = item.YouTube == null ? "" : item.YouTube.IconImage ?? ""



                        };
                        influencer.AddChannel(y);
                        data.Add(influencer);
                    }
                }
            }
            
            return data;
        }
    }
}
