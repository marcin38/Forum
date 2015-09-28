using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModels
{
    public class ThreadAddThreadViewModel
    {
        public string PostContent { get; set; }
        public string ThreadTitle { get; set; }
        public int CategoryId { get; set; }
    }
}