using LibraryManagementSystem.Application.IBaseRepository;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application
{
    public interface IApplicationUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Loan> Loans { get; }
        IRepository<User> Users { get; }

        Task<int> SaveChangesResult(CancellationToken cancellationToken = default);

    }
}
