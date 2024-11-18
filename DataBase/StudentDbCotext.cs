using Microsoft.EntityFrameworkCore;
using Project.DataBase.Configurations;
using Project.Models;

namespace Project.DataBase
{
	public class StudentDbCotext : DbContext
	{
		public DbSet<Student> students {  get; set; }
		public DbSet<Group> groups {  get; set; }
		public DbSet<Discipline> disciplines { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new StudentCofiguration());
			modelBuilder.ApplyConfiguration(new GroupConfiguration());
			modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
			//многие ко многим
			modelBuilder.Entity<Discipline>()
				.HasMany(p => p.Groups)
				.WithMany(c => c.Disciplines);
		}
		public StudentDbCotext(DbContextOptions<StudentDbCotext> options) : base(options) 
		{ 

		}
	}
}
