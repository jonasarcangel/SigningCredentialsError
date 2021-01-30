using MyProject.Core.Entities.Content;

namespace MyProject.Portal.Models
{
    public class Page : Node
    {
        public const string PAGE_MODULE = "MyProject.Pages";
        public const string PAGE_TYPE = "Page";
        public const string PAGE_LINK = "Link";

        public Page()
        {
            Module = PAGE_MODULE;
            Type = PAGE_TYPE;
        }
    }
}
