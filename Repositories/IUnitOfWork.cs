using System;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Contact> Contacts { get; }
        Task<int> CompleteAsync();
    }
}
