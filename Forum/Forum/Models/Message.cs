//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public System.DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
        public bool DeletedBySender { get; set; }
        public bool DeletedByRecipient { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}