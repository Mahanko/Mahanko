﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contracts.Slides
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
