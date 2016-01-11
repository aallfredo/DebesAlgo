using System.ComponentModel.DataAnnotations;

namespace debesalgo.Models
{
    public class Tag
    {
        [Key]
        public int Id { set; get; }     
        public string Name { set; get; }

        public ClosedBusiness TaggedBusiness { set; get;}
        public string Type { set; get; }
    }
}