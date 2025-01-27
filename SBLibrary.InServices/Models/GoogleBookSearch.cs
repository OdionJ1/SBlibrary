﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.InServices.Models
{
    public class GoogleBookSearch
    {
        [Display(Name = "Search Book Title")]
        [Required(ErrorMessage = "Enter book title")]
        public string SearchBookName { get; set; }
    }
}
