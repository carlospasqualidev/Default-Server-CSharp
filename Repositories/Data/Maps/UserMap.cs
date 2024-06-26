﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduzcaServer.DataContext.Maps
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Email).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            //builder.HasMany(user => user.Courses)
              //     .WithOne(course=> course.Owner) 
                //   .HasForeignKey(course => course.OwnerId); 
       
        
        
        }
    }
}
