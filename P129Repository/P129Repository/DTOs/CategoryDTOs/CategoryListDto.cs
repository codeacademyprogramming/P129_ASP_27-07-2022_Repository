using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Repository.DTOs.CategoryDTOs
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
    }
}
