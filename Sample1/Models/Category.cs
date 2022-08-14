using System.ComponentModel.DataAnnotations.Schema;

namespace Sample1.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime _created;

        public DateTime Created
        {
            get
            {
                return _created;
            }
            set 
            {
                _created = value;
            }
        }
    }
}
