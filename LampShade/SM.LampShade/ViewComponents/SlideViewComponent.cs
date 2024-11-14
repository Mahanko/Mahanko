using _01_LampShadeQuery.Contracts.Slides;
using Microsoft.AspNetCore.Mvc;

namespace SM.LampShade.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        public readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slides = _slideQuery.GetSlides();
            return View(slides);
        }
    }
}
