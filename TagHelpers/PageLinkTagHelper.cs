using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MvcEFApp.Models;

namespace MvcEFApp.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { set; get; } = null!;
        public PageViewModel? PageModel { set; get; }
        public string Action { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (PageModel is null)
                throw new Exception("Page Model not found");

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            TagBuilder pageList = new("ul");
            pageList.AddCssClass("pagination");

            TagBuilder pageCurr = TagCreate(urlHelper, PageModel.PageCurrent);

            if(PageModel.HasPrevPage)
            {
                TagBuilder pagePrev = TagCreate(urlHelper, PageModel.PageCurrent - 1);
                pageList.InnerHtml.AppendHtml(pagePrev);
            }
            pageList.InnerHtml.AppendHtml(pageCurr);
            if (PageModel.HasNextPage)
            {
                TagBuilder pageNext = TagCreate(urlHelper, PageModel.PageCurrent + 1);
                pageList.InnerHtml.AppendHtml(pageNext);
            }

            output.Content.AppendHtml(pageList);

        }
        TagBuilder TagCreate(IUrlHelper urlHelper, int page = 1)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");
            if (page == PageModel?.PageCurrent)
                item.AddCssClass("active");
            else
                link.Attributes["href"] = urlHelper.Action(Action, new { page = page });
            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(page.ToString());
            item.InnerHtml.AppendHtml(link);

            return item;
        }
    }
}
