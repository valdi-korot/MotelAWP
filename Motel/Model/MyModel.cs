namespace Motel.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyModel : DbContext
    {
        public MyModel()
            : base("name=MyModel5")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Comforts> Comforts { get; set; }
        public virtual DbSet<Numbers> Numbers { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<ViewClient> ViewClient { get; set; }
        public virtual DbSet<ViewClientSumCost> ViewClientSumCost { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .Property(e => e.LName)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.FName)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.MName)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.PassNumber)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Clients)
                .HasForeignKey(e => e.Id_Client);

            modelBuilder.Entity<Comforts>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Numbers>()
                .Property(e => e.Type_number)
                .IsFixedLength();

            modelBuilder.Entity<Numbers>()
                .HasMany(e => e.Comforts)
                .WithRequired(e => e.Numbers)
                .HasForeignKey(e => e.Id_Number);

            modelBuilder.Entity<Numbers>()
                .HasMany(e => e.Registrations)
                .WithOptional(e => e.Numbers)
                .HasForeignKey(e => e.Id_Number)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ViewClient>()
                .Property(e => e.LName)
                .IsFixedLength();

            modelBuilder.Entity<ViewClient>()
                .Property(e => e.FName)
                .IsFixedLength();

            modelBuilder.Entity<ViewClient>()
                .Property(e => e.MName)
                .IsFixedLength();

            modelBuilder.Entity<ViewClient>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<ViewClient>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<ViewClient>()
                .Property(e => e.PassNumber)
                .IsFixedLength();
        }
    }
}
