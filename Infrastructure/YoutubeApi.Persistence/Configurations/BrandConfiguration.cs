using Bogus;
using YoutubeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YoutubeApi.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);

        Faker faker = new Faker("tr");


        Brand brand1 = new Brand()
        {
            Id = 1,
            Name = faker.Commerce.Department(),
            CreateDate = DateTime.Now,
            IsDeleted = false
        };
        Brand brand2 = new Brand()
        {
            Id = 2,
            Name = faker.Commerce.Department(),
            CreateDate = DateTime.Now,
            IsDeleted = false
        };
        Brand brand3 = new Brand()
        {
            Id = 3,
            Name = faker.Commerce.Department(),
            CreateDate = DateTime.Now,
            IsDeleted = true
        };
        builder.HasData(brand1, brand2, brand3);
    }
}