using Anbar.Domain.Commodities;
using Anbar.Domain.Commodities.Categories;
using Anbar.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anbar.Infrastructure.Domain.Commodities
{
    internal sealed class CommodityEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public CommodityEntityTypeConfiguration():base()
        {

        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {



            builder.ToTable("Categories", SchemaNames.Commodity);
            builder.HasKey(b => b.Id);
            builder.OwnsMany(p => p.ChildCategories, x =>
            {
                x.WithOwner().HasForeignKey(c => c.ParentCategoryId);
            });
            builder.OwnsMany<Commodity>(p => p.Commodities, x => {

                x.WithOwner().HasForeignKey(c=>c.CategoryId);

                x.ToTable("Commodities", SchemaNames.Commodity);

                x.HasKey(b => b.Id);
                x.OwnsOne(p => p.Inventory);
                x.OwnsOne(p => p.Location);
                x.OwnsOne(p => p.Barcode);
            });
           
            

        }
    }
}
