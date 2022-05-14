using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessagesApp.Models;

namespace MessagesApp.Data
{
    public class MessagesAppContext : DbContext
    {
        public MessagesAppContext (DbContextOptions<MessagesAppContext> options)
            : base(options)
        {
        }

        public DbSet<MessagesApp.Models.Rate>? Rate { get; set; }
    }
}
