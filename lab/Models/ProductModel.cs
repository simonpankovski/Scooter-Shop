﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace lab.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Url]
        public string Url { get; set; }
        [Range(1,10000)]
        public int Price { get; set; }
        public string Description { get; set; }
        [Required]
        [StringLength(30)]
        public string Brand { get; set; }
        public string tags { get; set; }
        public DateTime timeStamp { get; set; }
        public int stock { get; set; }
    }
}