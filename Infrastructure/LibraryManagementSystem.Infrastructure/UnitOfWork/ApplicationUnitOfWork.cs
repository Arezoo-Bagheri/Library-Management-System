using LibraryManagementSystem.Application;
using LibraryManagementSystem.Application.IBaseRepository;
using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Infrastructure.UnitOfWork
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<Book> Books { get; }
        public IRepository<Loan> Loans { get; }
        public IRepository<User> Users { get; }

        public ApplicationUnitOfWork(ApplicationDbContext context,
                                                             IRepository<Book> books,
                                                             IRepository<Loan> loans,
                                                             IRepository<User> users)
        {
            _context = context;
            Books = books;
            Loans = loans;
            Users = users;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesResult(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
