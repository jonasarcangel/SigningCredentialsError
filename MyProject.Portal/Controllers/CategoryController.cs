using MyProject.Core.Entities.Content;
using MyProject.Core.Helper;
using MyProject.Portal.Models;
using MyProject.Services.Content;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MyProject.Portal.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly INodeService _nodeService;

        public CategoryController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> IndexAsync(string slug)
        {
            var node = await _nodeService.GetBySlugAsync(Category.CATEGORY_MODULE, Category.CATEGORY_TYPE, slug);
            var category = node.ConvertTo<Category>();
            if (!string.IsNullOrEmpty(category.ParentId))
            {
                var parentNode = await _nodeService.GetAsync(category.ParentId);
                var parentCategory = parentNode.ConvertTo<Category>();
                ViewBag.ParentCategory = parentCategory;
            }
            var categoriesModel = new CategoriesModel(_nodeService)
            {
                ParentId = category.Id
            };
            await categoriesModel.OnGetAsync();
            ViewBag.Categories = categoriesModel.Data;
            var pagesModel = new PagesModel(_nodeService)
            {
                ParentId = category.Id
            };
            await pagesModel.OnGetAsync();
            ViewBag.Pages = pagesModel.Data;
            return View(category);
        }

        [HttpGet("add/{id?}")]
        public IActionResult Add(string id)
        {
            return View();
        }

        [HttpPost("add/{id?}")]
        public async Task<IActionResult> Add(string id, Node node)
        {
            node.Id = Guid.NewGuid().ToString();
            node.CreatedDate = DateTime.UtcNow.ToString();
            node.Module = Category.CATEGORY_MODULE;
            node.Type = Category.CATEGORY_TYPE;
            if (!string.IsNullOrEmpty(id))
            {
                node.ParentId = id;
            }
            await _nodeService.AddAsync(node);
            return Redirect($"/category/{node.Slug}");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditAsync(string id)
        {
            var node = await _nodeService.GetAsync(id);
            var category = node.ConvertTo<Category>();
            if (!string.IsNullOrEmpty(category.ParentId))
            {
                var parentNode = await _nodeService.GetAsync(category.ParentId);
                var parentCategory = parentNode.ConvertTo<Category>();
                category.Parent = $"category/{parentCategory.Slug}";
            }
            return View(category);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(string id, Node node)
        {
            var existingNode = await _nodeService.GetAsync(node.Id);
            existingNode.Title = node.Title;
            existingNode.Slug = node.Slug;
            existingNode.Content = node.Content;
            existingNode.LastUpdatedDate = DateTime.UtcNow.ToString();
            if (!string.IsNullOrEmpty(node.Parent))
            {
                var slug = node.Parent.Replace("category/", "");
                var parentNode = await _nodeService.GetBySlugAsync(Category.CATEGORY_MODULE, Category.CATEGORY_TYPE, slug);
                if (parentNode != null)
                {
                    existingNode.ParentId = parentNode.Id;
                }
            }
            await _nodeService.UpdateAsync(existingNode);
            return Redirect($"/category/{existingNode.Slug}");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _nodeService.DeleteAsync(id);
            return Ok();
        }
    }
}
