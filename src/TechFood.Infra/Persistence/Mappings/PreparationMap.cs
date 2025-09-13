using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechFood.Domain.Entities;

namespace TechFood.Infra.Persistence.Mappings;

public class PreparationMap : IEntityTypeConfiguration<Preparation>
{
    public void Configure(EntityTypeBuilder<Preparation> builder)
    {
        builder.ToTable("Preparation");
    }
}

