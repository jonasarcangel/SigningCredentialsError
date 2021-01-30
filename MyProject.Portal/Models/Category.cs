using MyProject.Core.Entities.Content;

namespace MyProject.Portal.Models
{
    public class Category : Node
    {
        public const string CATEGORY_MODULE = "MyProject.Pages";
        public const string CATEGORY_TYPE = "Category";

        public Category()
        {
            Module = CATEGORY_MODULE;
            Type = CATEGORY_TYPE;
        }
    }
}
