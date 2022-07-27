using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P129Repository.Data.Entities;
using P129Repository.Data.Repositories;
using P129Repository.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoryPostDto categoryPostDto)
        {
            Category category = new Category
            {
                Name = categoryPostDto.Name,
                IsMain = categoryPostDto.IsMain,
                Image = "catetgory.jpg",
                ParentId = categoryPostDto.ParentId,
                CreatedAt = DateTime.UtcNow.AddHours(4)
            };

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.CommitAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = await _categoryRepository.GetAllAsync(c=>!c.IsDeleted);

            List<CategoryListDto> categoryListDtos = new List<CategoryListDto>();

            foreach (Category category in categories)
            {
                CategoryListDto categoryListDto = new CategoryListDto
                {
                    Id = category.Id,
                    IsMain = category.IsMain,
                    Name = category.Name
                };

                categoryListDtos.Add(categoryListDto);
            }

            return Ok(categoryListDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _categoryRepository.GetAsync(c=>!c.IsDeleted && c.Id == id));
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromForm] CategoryPutDto categoryPutDto)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id);

            category.Name = categoryPutDto.Name;
            category.IsMain = categoryPutDto.IsMain;
            category.Image = "category.jpg";
            category.ParentId = categoryPutDto.ParentId;
            category.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id);
            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("deletefromdb/{id?}")]
        public async Task<IActionResult> DeleteFromDb(int? id)
        {
            Category category = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == id);
            _categoryRepository.Remove(category);
            await _categoryRepository.CommitAsync();

            return NoContent();
        }
    }
}
