using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NRepository.MyTestBL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRepository.MyTestBL.BL.DataAccess
{
    public class TestItemTypeConfiguration : IEntityTypeConfiguration<TestItem>
    {
        public void Configure(EntityTypeBuilder<TestItem> builder)
        {
            builder.HasKey(p => p.Guid);
        }
    }
}
