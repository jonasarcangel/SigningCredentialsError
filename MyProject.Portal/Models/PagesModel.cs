using MyProject.Core.Helper;
using MyProject.Core.Repositories;
using MyProject.Services.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Portal.Models
{
    public class PagesModel
    {
        private readonly INodeService _nodeService;

        public PagesModel(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        public string ParentId { get; set; }
        public int CurrentPage { get; set; } = 0;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public bool ShowPrevious => CurrentPage > 0;
        public bool ShowNext => CurrentPage < (TotalPages - 1);
        public bool ShowFirst => CurrentPage != 0;
        public bool ShowLast => CurrentPage != (TotalPages - 1);

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public IEnumerable<Page> Data { get; set; }

        public async Task OnGetAsync()
        {
            var search = new NodeSearch()
            {
                ParentId = ParentId,
                Module = Page.PAGE_MODULE,
                Type = Page.PAGE_TYPE
            };
            var data = await _nodeService.GetPaginatedResultAsync(search, CurrentPage, PageSize);
            Data = data.ToArray().ConvertTo<Page>();
            Count = await _nodeService.GetCountAsync(search);
        }
    }
}
