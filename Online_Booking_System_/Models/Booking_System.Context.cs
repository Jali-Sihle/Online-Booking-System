﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Booking_System_.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineBooking_SystemEntities : DbContext
    {
        public OnlineBooking_SystemEntities()
            : base("name=OnlineBooking_SystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BOOKING> BOOKINGS { get; set; }
        public virtual DbSet<CLIENT> CLIENTS { get; set; }
    }
}
