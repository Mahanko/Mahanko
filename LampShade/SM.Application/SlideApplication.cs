using _0_Framework.Application;
using SM.ApplicationContracts.Slide;
using SM.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SM.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var opration = new OperationResult();
            var slide = new Slide(command.Picture, command.PictureAlt,command.Link, command.PictureTittle, command.Heading, command.Title, command.Text
                , command.BtnText);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult Edit(EditSlide command)
        {
            var opration = new OperationResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide == null)
            {
                return opration.Failed(ApplicationMessages.RecordNotFound);
            }
            slide.Edit(command.Picture, command.PictureAlt,command.Link, command.PictureTittle, command.Heading, command.Title, command.Text, command.BtnText);
            _slideRepository.SaveChanges();
            return opration.Successful();
        }

        public EditSlide GetDetails(long id)
        {
           return _slideRepository.GetDeatls(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var opration = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
            {
                return opration.Failed(ApplicationMessages.RecordNotFound);
            }
            slide.Delete();
            _slideRepository.SaveChanges();
            return opration.Successful();
        }

        public OperationResult Restore(long id)
        {
            var opration = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
            {
                return opration.Failed(ApplicationMessages.RecordNotFound);
            }
            slide.Restore();
            _slideRepository.SaveChanges();
            return opration.Successful();
        }
    }
}
