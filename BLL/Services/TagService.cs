using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TagService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Tag, TagDTO>().ReverseMap();
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static bool AddTags(List<TagDTO> tags)
        {
            var returnValue = true;
            foreach (var tagDto in tags)
            {
                var existingTag = DataAccessFactory.EditTags().GetByName(tagDto.TagName);
                if (existingTag == null) 
                {
                    var newTag = GetMapper().Map<Tag>(tagDto);
                    returnValue = DataAccessFactory.EditTags().AddTag(newTag);
                }
            }
            return returnValue;
        }
        public static bool AddNewsTags(NewsDTO news, List<TagDTO> tags)
        {
            var returnValue = true;
            foreach (var tag in tags)
            {
                var existingTag = DataAccessFactory.EditTags().GetByName(tag.TagName);
                if (existingTag == null)
                {
                    return false;
                }
                else 
                {
                    var mapTag = GetMapper().Map<Tag>(tag);
                    var mapNews = GetMapper().Map<News>(news);
                    returnValue = DataAccessFactory.EditTags().AddNewsTag(mapNews, mapTag);
                }
            }
            return returnValue;
        }
        public static bool DeleteByNews(int id) 
        {
            return DataAccessFactory.EditTags().Delete(id);
        }
        public static bool UpdateNewsTag(int newsID, List<Tag> tags) 
        {
            var returnValue = true;
            foreach (var tag in tags)
            {
                var existingTag = DataAccessFactory.EditTags().GetByName(tag.TagName);
                if (existingTag == null)
                {
                    return false;
                }
                else 
                {
                    DataAccessFactory.EditTags().Delete(newsID);
                }
            }
            foreach (var tag in tags)
            {
                returnValue = DataAccessFactory.EditTags().UpdateNewsTag(newsID, tag);
            }
            return returnValue;
        }
    }
}
