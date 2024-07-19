using System;
using System.Threading.Tasks;
using ContactApp.Data;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactContext _context;

        public UnitOfWork(ContactContext context)
        {
            _context = context;
            Contacts = new Repository<Contact>(_context);
        }

        public IRepository<Contact> Contacts { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
