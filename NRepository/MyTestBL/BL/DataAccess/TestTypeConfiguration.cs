﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NRepository.MyTestBL.Models;

namespace NRepository.MyTestBL.BL.DataAccess
{
    public class TestTypeConfiguration : IEntityTypeConfiguration<Test>
    {        
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(p => p.Guid);
        }
    }
}
