using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using SM.ApplicationContracts.Slide;
using SM.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context) 
        {
            _context = context;
        }

        public EditSlide GetDeatls(long id)
        {
           return _context.Slides.Select(x => new EditSlide
            {
                Id = id,
                BtnText= x.BtnText,
                Picture= x.Picture,
                Heading= x.Heading,
                PictureAlt= x.PictureAlt,
                PictureTittle= x.PictureTittle,
                Link= x.Link,
                Text= x.Text,
                Title= x.Title,
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x=>new SlideViewModel
            {
                Id=x.Id,
                Heading=x.Heading,
                Picture=x.Picture,
                Title=x.Title,
                IsDeleted=x.IsDeleted,
                
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
