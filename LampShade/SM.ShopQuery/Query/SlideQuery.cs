using SM.Infrastructure.EFCore;
using SM.ShopQuery.Contracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.ShopQuery.Query
{
    public class SlideQuery
    {
        private readonly ShopContext _context;
        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides.Where(x => x.IsDeleted == false).Select(x => new SlideQueryModel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTittle = x.PictureTittle,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Link = x.Link,
                Text = x.Text,
                Title = x.Title,
            }).ToList();
        }
    }
}
