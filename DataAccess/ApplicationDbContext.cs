using Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>()
                .HasKey(pc => new { pc.StudentId, pc.ClassId, pc.SubjectId });

            modelBuilder.Entity<Result>()
                .HasOne(p => p.Student)
                .WithMany(p => p.Results)
                .HasForeignKey(fk => fk.StudentId)
                .OnDelete(DeleteBehavior.NoAction); ;

            modelBuilder.Entity<Result>()
                .HasOne(p => p.Class)
                .WithMany(p => p.Results)
                .HasForeignKey(fk => fk.ClassId)
                .OnDelete(DeleteBehavior.NoAction); ;

            modelBuilder.Entity<Result>()
                .HasOne(p => p.Subject)
                .WithMany(p => p.Results)
                .HasForeignKey(fk => fk.SubjectId)
                .OnDelete(DeleteBehavior.NoAction); ;

            new DbInitializer(modelBuilder).Seed();
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Student>().HasData(
                new Student { Id = Guid.Parse("20b8d57c-5163-4e42-9c88-efe17aa42e1e"), FullName = "John Doe", Gender = "Male", Address = "123 Main St", Email = "john@example.com", ClassId = Guid.Parse("50af162e-2f1b-4530-9c4b-41ffa63da5ba") },
                new Student { Id = Guid.Parse("4361d2ac-247f-4bad-9b51-694e74c5094b"), FullName = "Jane Smith", Gender = "Female", Address = "456 Elm St", Email = "jane@example.com", ClassId = Guid.Parse("815b5ef2-2c61-474d-8d1a-a83e1ed600ac"), },
                new Student { Id = Guid.Parse("d75dca51-edc2-4475-9406-23b5e499f04b"), FullName = "Mike Johnson", Gender = "Male", Address = "789 Oak St", Email = "mike@example.com", ClassId = Guid.Parse("368751ec-5f80-42cc-b697-6574dee4ae3a") },
                new Student { Id = Guid.Parse("dcf67f78-1eae-4616-b1f5-ae1a2b65c7ab"), FullName = "Emily Williams", Gender = "Female", Address = "321 Pine St", Email = "emily@example.com", ClassId = Guid.Parse("6ffe5580-db44-400e-b03e-7662bb88ebaf") },
                new Student { Id = Guid.Parse("47900bea-7cb9-4379-a3f2-2b65f987e62f"), FullName = "David Brown", Gender = "Male", Address = "654 Cedar St", Email = "david@example.com", ClassId = Guid.Parse("9f77ed66-aee1-499f-850b-eff51cd1d977") }
                );
            _modelBuilder.Entity<Class>().HasData(
                new Class { Id = Guid.Parse("50af162e-2f1b-4530-9c4b-41ffa63da5ba"), Name = "Mathematics", HomeroomTeacher = "Mr. Smith", FacultyId = Guid.Parse("19e2369e-93ac-4b48-af36-a8f304a063ca") },
                new Class { Id = Guid.Parse("815b5ef2-2c61-474d-8d1a-a83e1ed600ac"), Name = "Science", HomeroomTeacher = "Ms. Johnson", FacultyId = Guid.Parse("6c0751ac-5c34-4c00-91f7-868e9bc1b5a4") },
                new Class { Id = Guid.Parse("9f77ed66-aee1-499f-850b-eff51cd1d977"), Name = "English", HomeroomTeacher = "Mrs. Davis", FacultyId = Guid.Parse("ca12b74a-ce46-4a93-8da4-f738aab22590") },
                new Class { Id = Guid.Parse("6ffe5580-db44-400e-b03e-7662bb88ebaf"), Name = "History", HomeroomTeacher = "Mr. Thompson", FacultyId = Guid.Parse("ec0a691c-83c8-4635-a522-ae886862d05b") },
                new Class { Id = Guid.Parse("368751ec-5f80-42cc-b697-6574dee4ae3a"), Name = "Computer Science", HomeroomTeacher = "Mr. Wilson", FacultyId = Guid.Parse("5b8f3a90-2597-46ab-97bf-91ff547d70cd") }
                );
            _modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id = Guid.Parse("ca12b74a-ce46-4a93-8da4-f738aab22590"), Name = "Faculty of Engineering" },
                new Faculty { Id = Guid.Parse("6c0751ac-5c34-4c00-91f7-868e9bc1b5a4"), Name = "Faculty of Science" },
                new Faculty { Id = Guid.Parse("19e2369e-93ac-4b48-af36-a8f304a063ca"), Name = "Faculty of Arts" },
                new Faculty { Id = Guid.Parse("ec0a691c-83c8-4635-a522-ae886862d05b"), Name = "Faculty of Business" },
                new Faculty { Id = Guid.Parse("5b8f3a90-2597-46ab-97bf-91ff547d70cd"), Name = "Faculty of Medicine" }
                );
            _modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = Guid.Parse("58750c14-582a-4196-93f8-b35713d370d7"), Name = "Mathematics", NumberOfCredits = 4 },
                new Subject { Id = Guid.Parse("3db76a7b-6f01-4fc2-b703-12a05e8c83ac"), Name = "Science", NumberOfCredits = 3 },
                new Subject { Id = Guid.Parse("e30652d2-2386-41d6-bcd2-cf47c2a99d1a"), Name = "English", NumberOfCredits = 3 },
                new Subject { Id = Guid.Parse("de9bdd8f-2bed-4470-8ed7-4d3467c5ce57"), Name = "History", NumberOfCredits = 3 },
                new Subject { Id = Guid.Parse("5f171354-fe12-4114-aa27-e5ef9be2c917"), Name = "Computer Science", NumberOfCredits = 4 }
                );
            _modelBuilder.Entity<Result>().HasData(
                new Result { StudentId = Guid.Parse("47900bea-7cb9-4379-a3f2-2b65f987e62f"), ClassId = Guid.Parse("50af162e-2f1b-4530-9c4b-41ffa63da5ba"), SubjectId = Guid.Parse("e30652d2-2386-41d6-bcd2-cf47c2a99d1a"), Point = 85 },
                new Result { StudentId = Guid.Parse("dcf67f78-1eae-4616-b1f5-ae1a2b65c7ab"), ClassId = Guid.Parse("815b5ef2-2c61-474d-8d1a-a83e1ed600ac"), SubjectId = Guid.Parse("de9bdd8f-2bed-4470-8ed7-4d3467c5ce57"), Point = 78 },
                new Result { StudentId = Guid.Parse("d75dca51-edc2-4475-9406-23b5e499f04b"), ClassId = Guid.Parse("9f77ed66-aee1-499f-850b-eff51cd1d977"), SubjectId = Guid.Parse("5f171354-fe12-4114-aa27-e5ef9be2c917"), Point = 92 },
                new Result { StudentId = Guid.Parse("4361d2ac-247f-4bad-9b51-694e74c5094b"), ClassId = Guid.Parse("6ffe5580-db44-400e-b03e-7662bb88ebaf"), SubjectId = Guid.Parse("3db76a7b-6f01-4fc2-b703-12a05e8c83ac"), Point = 80 },
                new Result { StudentId = Guid.Parse("20b8d57c-5163-4e42-9c88-efe17aa42e1e"), ClassId = Guid.Parse("368751ec-5f80-42cc-b697-6574dee4ae3a"), SubjectId = Guid.Parse("58750c14-582a-4196-93f8-b35713d370d7"), Point = 88 }
                );
        }
    }
}