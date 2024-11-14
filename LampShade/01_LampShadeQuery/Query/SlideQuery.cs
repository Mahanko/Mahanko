using _01_LampShadeQuery.Contracts.Slides;
using SM.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
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
               Picture = x.Picture,
               BtnText = x.BtnText,
               Heading = x.Heading,
               Link = x.Link,
               PictureAlt = x.PictureAlt,
               PictureTittle = x.PictureTittle,
               Text = x.Text,
               Title = x.Title
           }).ToList();
        }
    }
}
