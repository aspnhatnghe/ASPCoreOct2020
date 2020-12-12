using Microsoft.EntityFrameworkCore;

namespace Day15_EFCore.Entities
{
    public class MyDbContext : DbContext
    {
        //Định nghĩa các table
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public MyDbContext() { }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>(entity => {
                entity.ToTable("Order");
                entity.HasKey(e => e.MaHd);
                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity => {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => new { e.MaHd, e.MaHh});
                entity.HasOne(e => e.HoaDon)
                .WithMany(hd => hd.ChiTietHoaDons)
                .HasForeignKey(e => e.MaHd)
                .HasConstraintName("FK_CTHD_HD");                    
            });
        }
    }
}
