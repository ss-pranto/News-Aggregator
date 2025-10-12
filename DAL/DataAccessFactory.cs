using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static INews<News, int, bool> GetNews()
        {
            return new NewsRepos();
        }
        public static INews<News, int, bool> NewsWorkflowBase()
        {
            return new NewsWorkflowRepo();
        }
        public static IWorkflow NewsWorkflowExtend()
        {
            return new NewsWorkflowRepo();
        }
        public static INews<Tag, int, bool> GetTags()
        {
            return new TagRepo();
        }
        public static ITags EditTags()
        {
            return new TagRepo();
        }
        public static IEditor EditorNews()
        {
            return new EditorRepo();
        }
        public static IPublisher PublisherNews()
        {
            return new PublisherRepo();
        }
        public static ILoadRating LoadRating()
        {
            return new LoadRatingRepo();
        }
        public static IRecommendation Recommendation()
        {
            return new RecommendationRepo();
        }
        public static IFilter FilterNews()
        {
            return new NewsFilterRepo();
        }
        public static IActivity AddActivity()
        {
            return new ReaderActivityRepo();
        }
        public static ILogin UserLoginControl()
        {
            return new LoginRepo();
        }
    }
}
