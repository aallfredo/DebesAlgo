using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace debesalgo.Models
{
    public enum Status { Open,Closed,
        Unknown
    }

    public class ClosedBusinessBase
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        public string DateClosed { set; get; }


        private Status _currentStatus;

        public Status CurrentStatus
        {
            set
            {
                _currentStatus = value;
                CurrentStatusText = value.ToString();
            }
            get
            {
                return _currentStatus;
            }
        }

        [NotMapped]
        public string CurrentStatusText { private set; get; }

        public string ArticleLink { set; get; }

        public string Img { set; get; }
        public string Details { get; set; }

        public string Owner { get; set; }

        public Decimal TotalMoneyOwed { get; set; }

    }


    public class ClosedBusiness: ClosedBusinessBase
    {      
    }

    public class ClosedBusinessInReview: ClosedBusinessBase
    {
        public DateTime Updated { get; set; }
    }
}
