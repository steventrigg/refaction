namespace refactor_me.DataModel
{
    using System.Data.Entity;

    public partial class RefactorMeContext : DbContext
    {
        public RefactorMeContext()
            : base("name=RefactorMeContext")
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductOptionEntity> ProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.deliveryprice)
                .HasPrecision(19, 4);
        }
    }
}
