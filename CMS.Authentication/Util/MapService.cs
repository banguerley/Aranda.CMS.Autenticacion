using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Authentication.Util
{
    public class MapService<T,T2>
    {

        public static T2 Map(object value)
        {
            var config= new AutoMapper.MapperConfiguration(mc => mc.CreateMap<T, T2>());
            var mapper = new AutoMapper.Mapper(config);
            return  mapper.Map<T, T2>((T)value);
            
        }

        public static T2 Map(MapperConfiguration config, object value)
        {          
            var mapper = new AutoMapper.Mapper(config);
            return mapper.Map<T, T2>((T)value);

        }

        public static List<T2> MapList(object value)
        {
            var config = new AutoMapper.MapperConfiguration(mc => mc.CreateMap<T, T2>());
            var mapper = new AutoMapper.Mapper(config);
            var tMappped = mapper.Map<List<T>, List<T2>>((List<T>)value);
            return tMappped;
        }

        public static List<T2> MapList(MapperConfiguration config, object value)        {
           
            var mapper = new AutoMapper.Mapper(config);
            var tMappped = mapper.Map<List<T>, List<T2>>((List<T>)value);
            return tMappped;
        }
    }
}