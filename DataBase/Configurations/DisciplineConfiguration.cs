using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DataBase.Helpers;
using Project.Models;

namespace Project.DataBase.Configurations
{
	public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
	{
		private const string TableName = "cd_discipline";
		public void Configure(EntityTypeBuilder<Discipline> builder)
		{	//Задаем первичный ключ
			builder
				.HasKey(p => p.DisciplineId)
				.HasName($"pk_{TableName}_discipline_id");

			//Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.DisciplineId).ValueGeneratedOnAdd();

			builder.Property(p => p.DisciplineId)
				.HasColumnName("discipline_id")
				.HasComment("Идентификатор записи дисциплины");

			builder.Property(p => p.DisciplineName)
				.HasColumnName("discipline_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название дисциплины");

			builder.ToTable(TableName);

		}
	}
}
