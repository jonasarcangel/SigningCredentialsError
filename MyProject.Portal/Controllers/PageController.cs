using MyProject.Core.Entities.Content;
using MyProject.Core.Helper;
using MyProject.Portal.Models;
using MyProject.Services.Content;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Portal.Controllers
{
    [Route("[controller]")]
    public class PageController : Controller
    {
        private readonly INodeService _nodeService;
        public PageController(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> IndexAsync(string slug)
        {
            var node = await _nodeService.GetBySlugAsync(Page.PAGE_MODULE, Page.PAGE_TYPE, slug);
            var page = node.ConvertTo<Page>();
            if (node.Links.Count() > 0)
            {
                var parentNode = await _nodeService.GetAsync(node.Links.First().Id);
                switch (parentNode.Type)
                {
                    case Category.CATEGORY_TYPE:
                        ViewBag.Category = parentNode.ConvertTo<Category>();
                        break;
                    case Page.PAGE_TYPE:
                        ViewBag.Page = parentNode.ConvertTo<Page>();
                        break;
                }
            }
            var pagesModel = new PagesModel(_nodeService)
            {
                ParentId = page.Id
            };
            await pagesModel.OnGetAsync();
            ViewBag.Pages = pagesModel.Data;
            return View(page);
        }

        [HttpGet("add/{id}")]
        public IActionResult Add(string id)
        {
            return View();
        }

        [HttpPost("add/{id}")]
        public async Task<IActionResult> Add(string id, Node node)
        {
            node.Id = Guid.NewGuid().ToString();
            node.LinksString = $"{Page.PAGE_LINK}:{id}";
            node.CreatedDate = DateTime.UtcNow.ToString();
            node.Module = Page.PAGE_MODULE;
            node.Type = Page.PAGE_TYPE;
            await _nodeService.AddAsync(node);
            return Redirect($"/page/{node.Slug}");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditAsync(string id)
        {
            var node = await _nodeService.GetAsync(id);
            node.LinksString = node.LinksString.Replace(Page.PAGE_LINK, string.Empty);
            var page = node.ConvertTo<Page>();
            return View(page);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(string id, Node node)
        {
            var existingNode = await _nodeService.GetAsync(node.Id);
            existingNode.Title = node.Title;
            existingNode.Slug = node.Slug;
            existingNode.Content = node.Content;
            existingNode.LinksString = $"{Page.PAGE_LINK}:{node.Links}";
            existingNode.LastUpdatedDate = DateTime.UtcNow.ToString();
            await _nodeService.UpdateAsync(existingNode);
            return Redirect($"/page/{existingNode.Slug}");
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
