using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NRepository.MyTestBL.Models;

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
