using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Repository.DTOs.CategoryDTOs
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public IFormFile ImageFile { get; set; }
        public Nullable<int> ParentId { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {

    }
}
