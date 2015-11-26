using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Forum.Helpers
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
        TagBuilder builder = Build(image);
        MvcHtmlString link = helper.ActionLink("[replaceme]", result, ajaxOptions);

        return new MvcHtmlString(link.ToString().Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing)));
    }

        public static MvcHtmlString ImageActionLink(this HtmlHelper helper, Image image, ActionResult result)
        {
            TagBuilder builder = Build(image);
            MvcHtmlString link = helper.ActionLink("[replaceme]", result);

            return new MvcHtmlString(link.ToString().Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing)));
        }

        private static TagBuilder Build(Image image)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.MergeAttribute("src", image.imageUrl);
            builder.MergeAttribute("alt", image.altText);
            builder.MergeAttribute("height", image.height);
            builder.MergeAttribute("width", image.width);
            builder.MergeAttribute("title", image.title);

            return builder;
        }
}
}