using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalMind.DAO.Entities;
using Microsoft.EntityFrameworkCore;


namespace GlobalMind.DAO.Context
{

    public class GlobalMindDbContext : DbContext
    {
        public GlobalMindDbContext(DbContextOptions<GlobalMindDbContext> options) : base(options)
        {

        }

        public DbSet<CourseDetailEntity> CourseDetail { get; set; }
        public DbSet<CourseEntity> Course { get; set; }
        public DbSet<LessonEntity> Lesson { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<PartEntity> Part { get; set; }
        public DbSet<ProfileConsultationEntity> ProfileConsultation { get; set; }
        public DbSet<ServiceDetailEntity> ServiceDetail { get; set; }
        public DbSet<ServiceEntity> Service { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserLessonStatusEntity> UserLessonStatus { get; set; }
        public DbSet<UserPartStatusEntity> UserPartStatus { get; set; }
        public DbSet<OtpEntity> Otp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            ConfigureModel(modelBuilder);
        }

        private void ConfigureModel(ModelBuilder modelBuilder)
        {


        }
    }
}
