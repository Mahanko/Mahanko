using _0_Framework.Domain;
using SM.ApplicationContracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.SlideAgg
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlide GetDeatls(long id);
        List<SlideViewModel> GetList();
    }
}
