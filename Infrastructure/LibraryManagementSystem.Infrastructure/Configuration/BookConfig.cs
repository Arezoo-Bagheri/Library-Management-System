using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Configuration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.Property(b => b.Title)
                       .HasMaxLength(100);


            builder.Property(b => b.Author)
                       .HasMaxLength(100);


            builder.Property(b => b.CopiesAvailable)
                       .HasMaxLength(50);


            builder.Property(b => b.IsAvailable)
                       .IsRequired();


            builder.HasMany(b => b.Loans)
               .WithOne(b => b.Book)
               .HasForeignKey(b => b.BookId);

        }
    }
}
