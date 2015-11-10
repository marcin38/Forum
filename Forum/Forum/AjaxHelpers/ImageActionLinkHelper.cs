using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Forum.AjaxHelpers
{

    public class Image
    {
        public string imageUrl { get; set; }
        public string altText { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string title { get; set; }
    }

    public static class ImageActionLinkHelper
{

        public static MvcHtmlString ImageActionLink(this AjaxHelper helper, Image image, ActionResult result, AjaxOptions ajaxOptions)
    {
        var builder = new TagBuilder("img");
        builder.MergeAttribute("src", image.imageUrl);
        builder.MergeAttribute("alt", image.altText);
        builder.MergeAttribute("height", image.height);
        builder.MergeAttribute("width", image.width);
        builder.MergeAttribute("title", image.title);
        var link = helper.ActionLink("[replaceme]", result, ajaxOptions);
        return new MvcHtmlString(link.ToString().Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing)));
    }

}
}