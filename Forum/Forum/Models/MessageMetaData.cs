using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Models
{
    public class MessageMetaData
    {
        [AllowHtml]
        public string Subject { get; set; }

        [AllowHtml]
        public string Body { get; set; }
    }

    [MetadataType(typeof(MessageMetaData))]
    public partial class Message
    {

    }
}