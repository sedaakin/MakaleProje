using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleProje.DAL
{
    public static class MyAutoMapper<TSource, TDestination>
    {
        private static Mapper _myMapper = new Mapper(new MapperConfiguration(m => m.CreateMap<TSource, TDestination>().ReverseMap()));

        public static TDestination MyMap(TSource source)
        {
            return _myMapper.DefaultContext.Mapper.Map<TDestination>(source);
        }
        public static List<TDestination> MyMapList(List<TSource> sources)
        {
            var list = new List<TDestination>();
            sources.ForEach(x=>list.Add(MyMap(x)));
            return list;
        }
    }
}
