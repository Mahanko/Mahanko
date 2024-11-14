using _1_ShopQuery.Contracts.Slide;
using SM.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_ShopQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
           return _context.Slides.Where(x=>x.IsDeleted==false).Select(x=>new SlideQueryModel
           {
               Picture=x.Picture,
               PictureAlt=x.PictureAlt,
               Heading=x.Heading,
               Title=x.Title,
               Link=x.Link,
               BtnText=x.BtnText,
               PictureTittle=x.PictureTittle,
               Text=x.Text,
           }).ToList();
        }
    }
}
