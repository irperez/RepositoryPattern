using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NRepository.UniversityBL.Domain;

namespace University.Data
{
    public class TopicTypeConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(p => p.Guid);

            
        }
    }
}
