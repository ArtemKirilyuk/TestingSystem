﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.DTO;

namespace PL.ViewModels
{
    public class TestCompleteViewModel
    {
        public string Result { get; set; }
        public int GoodAnswers { get; set; }
        public int Questions { get; set; }
        public string Description { get; set; }
    }
}