using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Configuration
{
    public class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {

            builder.HasOne(l => l.User)
                       .WithMany(l => l.Loans)
                       .HasForeignKey(l => l.UserId);


            builder.HasOne(l => l.Book)
                       .WithMany(l => l.Loans)
                       .HasForeignKey(l => l.BookId);

        }
    }
}
