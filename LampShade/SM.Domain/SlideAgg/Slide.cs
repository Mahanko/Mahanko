using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Picture { get;private set; }
        public string PictureAlt { get; private set; }
        public string PictureTittle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public string Link { get; private set; }
        public bool IsDeleted {  get; private set; }
        protected Slide() { }

        public Slide(string picture, string pictureAlt,string link, string pictureTittle, string heading, string title, string text, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTittle = pictureTittle;
            Heading = heading;
            Title = title;
            Link = link;
            Text = text;
            BtnText = btnText;
            IsDeleted = false;
        }
        public void Edit(string picture, string pictureAlt,string link, string pictureTittle, string heading, string title, string text, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTittle = pictureTittle;
            Heading = heading;
            Title = title;
            Text = text;
            Link = link;
            BtnText = btnText;
        }
        public void Delete() 
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
