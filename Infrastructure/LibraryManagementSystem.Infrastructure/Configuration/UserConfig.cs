﻿using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(u => u.FirstName)
                       .HasMaxLength(50)
                       .IsRequired();


            builder.Property(u => u.LastName)
                      .HasMaxLength(50)
                      .IsRequired();


            builder.Property(u => u.UserName)
                       .HasMaxLength(50)
                       .IsRequired();


            builder.Property(u => u.Password)
                      .HasMaxLength(50)
                      .IsRequired();

            builder.HasMany(u => u.Loans)
                       .WithOne(u => u.User)
                       .HasForeignKey(u => u.UserId);

        }
    }
}
