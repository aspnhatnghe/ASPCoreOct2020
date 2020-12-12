using Microsoft.EntityFrameworkCore;

namespace Day15_EFCore.Entities
{
    public class MyDbContext : DbContext
    {
        //Định nghĩa các table
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }

        public MyDbContext() { }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
