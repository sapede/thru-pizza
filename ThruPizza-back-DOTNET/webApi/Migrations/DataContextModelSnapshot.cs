﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FuncionarioPedido", b =>
                {
                    b.Property<int>("FuncionariosFuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("PedidosPedidoId")
                        .HasColumnType("int");

                    b.HasKey("FuncionariosFuncionarioId", "PedidosPedidoId");

                    b.HasIndex("PedidosPedidoId");

                    b.ToTable("FuncionarioPedido");
                });

            modelBuilder.Entity("WebApi.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebApi.Entities.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionarioId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoFuncionario")
                        .HasColumnType("int");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("WebApi.Entities.Ingrediente", b =>
                {
                    b.Property<int>("IngredienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredienteId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoPorQuantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("QuantidadePadrao")
                        .HasColumnType("real");

                    b.HasKey("IngredienteId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("WebApi.Entities.IngredientesReceita", b =>
                {
                    b.Property<int>("IngredientesReceitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientesReceitaId"), 1L, 1);

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeIngrediente")
                        .HasColumnType("int");

                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.HasKey("IngredientesReceitaId");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("IngredientesReceita");
                });

            modelBuilder.Entity("WebApi.Entities.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"), 1L, 1);

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MetodoPagamento")
                        .HasColumnType("int");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValorPagamento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PedidoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebApi.Entities.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaId"), 1L, 1);

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int");

                    b.HasKey("PizzaId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("WebApi.Entities.Receita", b =>
                {
                    b.Property<int>("ReceitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceitaId"), 1L, 1);

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("ReceitaId");

                    b.HasIndex("PizzaId")
                        .IsUnique();

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("WebApi.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountClienteId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("FuncionarioPedido", b =>
                {
                    b.HasOne("WebApi.Entities.Funcionario", null)
                        .WithMany()
                        .HasForeignKey("FuncionariosFuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.Pedido", null)
                        .WithMany()
                        .HasForeignKey("PedidosPedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Entities.IngredientesReceita", b =>
                {
                    b.HasOne("WebApi.Entities.Ingrediente", "Ingrediente")
                        .WithMany("IngredientesReceitas")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.Receita", "Receita")
                        .WithMany("IngredientesReceita")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Receita");
                });

            modelBuilder.Entity("WebApi.Entities.Pizza", b =>
                {
                    b.HasOne("WebApi.Entities.Pedido", "Pedido")
                        .WithMany("Pizzas")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("WebApi.Entities.Receita", b =>
                {
                    b.HasOne("WebApi.Entities.Pizza", "Pizza")
                        .WithOne("Receita")
                        .HasForeignKey("WebApi.Entities.Receita", "PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("WebApi.Entities.RefreshToken", b =>
                {
                    b.HasOne("WebApi.Entities.Cliente", "Account")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("AccountClienteId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebApi.Entities.Cliente", b =>
                {
                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("WebApi.Entities.Ingrediente", b =>
                {
                    b.Navigation("IngredientesReceitas");
                });

            modelBuilder.Entity("WebApi.Entities.Pedido", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("WebApi.Entities.Pizza", b =>
                {
                    b.Navigation("Receita");
                });

            modelBuilder.Entity("WebApi.Entities.Receita", b =>
                {
                    b.Navigation("IngredientesReceita");
                });
#pragma warning restore 612, 618
        }
    }
}
