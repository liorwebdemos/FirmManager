//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using WebApi.Models;

//namespace WebApi.DAL.Implementation.Contexts
//{
//    public class TrackedModelConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : TrackedModel
//    {
//        // configure entities derived from an abstract class (https://stackoverflow.com/a/49997115)
//        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
//        {
//            builder.Property(t => t.CreatedDate)
//                .ValueGeneratedOnAddOrUpdate();
//            builder.Property(t => t.CreatedUserIp)
//                .ValueGeneratedOnAddOrUpdate();
//            builder.Property(t => t.UpdatedDate)
//                .ValueGeneratedOnAddOrUpdate();
//            builder.Property(t => t.UpdatedUserIp)
//                .ValueGeneratedOnAddOrUpdate();
//        }
//    }
//}
