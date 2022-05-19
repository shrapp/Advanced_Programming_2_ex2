using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using MessagesApp.Models;

namespace MessagesApp.Data
{
    public class MessagesAppContext : DbContext
    {
        public MessagesAppContext(DbContextOptions<MessagesAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Rate>? Rate { get; set; }

        public DbSet<MessagesApp.Models.User>? User { get; set; }

        public DbSet<MessagesApp.Models.Message>? Message { get; set; }

        public DbSet<MessagesApp.Models.Chat>? Chat { get; set; }
    }
}
