using FoccoEmFrente.Kanban.Application.Entities.Atividade2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoccoEmFrente.Kanban.Application.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Age).IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

        }

    }
}
