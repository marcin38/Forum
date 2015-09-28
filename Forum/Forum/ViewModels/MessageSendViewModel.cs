using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace Forum.ViewModels
{
    public class MessageSendViewModel
    {
        public int To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public SelectList Users { get; set; }
    }
}