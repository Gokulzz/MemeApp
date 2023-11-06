using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using memeApp.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace memeApp.DAL.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseSqlServer("Server=localhost;Database=MemeApp;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>()
                .HasKey(c => c.Id);
            model.Entity<UserRole>()
                .HasKey(c => c.RoleId);
            model.Entity<MemeTemplateUpload>()
                .HasKey(c => c.UploadID);
            model.Entity<User>()
                .HasOne(c => c.userRole).WithMany(c => c.users)
                .IsRequired();
            model.Entity<User>()
                .HasMany(c => c.memeTemplateDownloads)
                .WithMany(c => c.users);
            model.Entity<User>()
                .HasMany(c => c.memeTemplateUploads)
                .WithOne(c => c.Users);
            model.Entity<MemeTemplateDownload>()
                .HasOne(c => c.Uploads)
                .WithMany(c => c.Downloads);
            model.Entity<MemeTemplateDownload>()
                .HasKey(c => c.DownloadId);
            model.Entity<User>()
               .HasMany(c => c.memeTemplateDownloads)
               .WithMany(c => c.users)
               .UsingEntity<UserDownloadMeme>();


            //model.Entity<UserDownloadMeme>()
            //   .HasKey(c => new { c.usersId, c.memeTemplateDownloadsDownloadId });
            //model.Entity<UserDownloadMeme>()
            //    .HasOne(c => c.download)
            //     .WithMany()
            //      .HasForeignKey(c => c.memeTemplateDownloadsDownloadId)
            //      .OnDelete(DeleteBehavior.Cascade);
            //model.Entity<UserDownloadMeme>()
            //    .HasOne(c => c.user)
            //    .WithMany()
            //    .HasForeignKey(c => c.usersId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // Define the table name for the junction table
            //model.Entity<UserDownloadMeme>(entity =>
            //{
            //    entity.ToTable("MemeTemplateDownloadUser");
            //});9
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<MemeTemplateUpload> UploadMeme { get; set; }
        public DbSet<MemeTemplateDownload> DownloadMeme { get; set; }
        public DbSet<UserDownloadMeme> MemeTemplateDownloadUser { get; set; }   


    }
}
