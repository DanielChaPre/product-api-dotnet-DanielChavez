using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace product_api_dotnet_DanielChavez.Models.DB;

public partial class PruebaApiContext : DbContext
{
    //Variable que nos servira para guardar la cadena de conexion a la base de datos
    private string connectionString = "";
    public PruebaApiContext()
    {
        // Inicializar el builder de la aplicacion web y donde podremos tener acceso a la configuracion de la aplicacion
        var builder = WebApplication.CreateBuilder();

        // Obtener la cadena de conexion desde el archivo appsettings.json
        connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    }

    public PruebaApiContext(DbContextOptions<PruebaApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString); //Asignamos la cadena de conexion a la base de datos

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
