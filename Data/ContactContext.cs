using ContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
