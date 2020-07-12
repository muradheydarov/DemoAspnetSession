namespace DemoAspnetSession.Context
{
    using DemoAspnetSession.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HostCloudContext : DbContext
    {
        
        public HostCloudContext()
            : base("name=HostCloudContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}