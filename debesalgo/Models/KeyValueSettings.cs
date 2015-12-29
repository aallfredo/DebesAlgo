using System.ComponentModel.DataAnnotations;

namespace debesalgo.Models
{
    public class KeyValueSettings
    {
        [Key]
        public int Id { set; get; }
        public string Key { set; get; }
        public string Value { set; get; }
    }
}