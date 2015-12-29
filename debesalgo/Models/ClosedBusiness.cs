using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace debesalgo.Models
{
    public enum Status { Open,Closed,
        Unknown
    }
    public class ClosedBusiness
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        public string DateClosed { set; get; }

        public Status CurrentStatus { set; get; }

        public string ArticleLink { set; get; }

        public string Img { set; get; }
        public string Details { get; set; }
    }
}
