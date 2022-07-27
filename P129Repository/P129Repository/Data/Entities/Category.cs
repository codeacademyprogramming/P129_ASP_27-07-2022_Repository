using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Repository.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public string Image { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Category Parent { get; set; }
        public IEnumerable<Category> Children { get; set; }
    }
}
