//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace theFood.Domain.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscriber
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserSubscriberID { get; set; }
    
        public virtual User User { get; set; }
    }
}
