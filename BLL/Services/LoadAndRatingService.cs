using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoadAndRatingService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReporterRating, ReporterRatingDTO>().ReverseMap();
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<NewsWorkFlow, NewsWorkFlowDTO>().ReverseMap();
                cfg.CreateMap<PublishFrequencyBLL, PublishFrequency>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<ReporterRatingDTO> ReporterRating() 
        {
            var data =  DataAccessFactory.LoadRating().GetAll();
            return GetMapper().Map<List<ReporterRatingDTO>>(data);
        }
        public static float ApprovalRateByReporter(int id)
        {
            var NewsCount = DataAccessFactory.LoadRating().GetNewsByEmpID(id).Count();
            var RewsApprovedCount = DataAccessFactory.LoadRating().GetNewsByEmpID(id).Where(s=> s.Status == "Published" || s.Status == "Approved").Count();
            return ApprovalRateByReporter(NewsCount, RewsApprovedCount);
        }
        public static float ApprovalRateByReporter(int Total, int Approved)
        {
            var approvalRate = ((float)Approved / Total) * 100;
            return approvalRate;
        }
        public static List<NewsDTO> PendingCnt()
        {
            var data = DataAccessFactory.LoadRating().GetAllPending();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static List<NewsWorkFlowDTO> ReviewCnt(int id)
        {
            var data = DataAccessFactory.LoadRating().GetWorkFlowByEmpID(id);
            return GetMapper().Map<List<NewsWorkFlowDTO>>(data);
        }
        public static List<NewsDTO> PublishDay(DateTime date)
        {
            var data = DataAccessFactory.LoadRating().PublishDay(date);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static List<PublishFrequencyBLL> PublishFreq(string type)
        {
            var data = DataAccessFactory.LoadRating().GetPublishFrequency(type);
            return GetMapper().Map<List<PublishFrequencyBLL>>(data);
        }
    }
}
