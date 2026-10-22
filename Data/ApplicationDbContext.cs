using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;
using DemoMVC.Migrations;
using System.ComponentModel.DataAnnotations;
namespace DemoMVC.Data;

public class ApplicationDbContext: DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

    public DbSet<Student>? Students { get; set; } = null;

    public DbSet<Faculty> Faculties { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Faculty>().HasData(
            new Faculty { FacultyId = "05", FacultyName = "Công nghệ thông tin"},
            new Faculty { FacultyId = "01", FacultyName = "Dầu khí" },
            new Faculty { FacultyId = "02", FacultyName = "Mỏ" },
            new Faculty { FacultyId = "03", FacultyName = "Địa chất & Khoa học Trái đất" },
            new Faculty { FacultyId = "04", FacultyName = "Kinh tế & Quản trị kinh doanh" },
            new Faculty { FacultyId = "06", FacultyName = "Trắc địa - Bản đồ và Quản lý đất đai" },
            new Faculty { FacultyId = "07", FacultyName = "Cơ - Điện" },
            new Faculty { FacultyId = "08", FacultyName = "Môi trường" }
        );
    }

}