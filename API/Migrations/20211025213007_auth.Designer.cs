// <auto-generated />
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211025213007_auth")]
    partial class auth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 500,
                            Name = "Ajith"
                        },
                        new
                        {
                            CustomerID = 501,
                            Name = "Manasa"
                        },
                        new
                        {
                            CustomerID = 502,
                            Name = "Chandru"
                        },
                        new
                        {
                            CustomerID = 503,
                            Name = "Meeesha"
                        },
                        new
                        {
                            CustomerID = 504,
                            Name = "Aman"
                        },
                        new
                        {
                            CustomerID = 505,
                            Name = "Nikhil"
                        },
                        new
                        {
                            CustomerID = 506,
                            Name = "Bala"
                        },
                        new
                        {
                            CustomerID = 507,
                            Name = "Math"
                        });
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemID = 100,
                            Name = "A New Day",
                            Price = 3.50m
                        },
                        new
                        {
                            ItemID = 101,
                            Name = "The flower of love",
                            Price = 2.73m
                        },
                        new
                        {
                            ItemID = 102,
                            Name = "Passion",
                            Price = 4.33m
                        },
                        new
                        {
                            ItemID = 103,
                            Name = "I love you",
                            Price = 6.27m
                        },
                        new
                        {
                            ItemID = 104,
                            Name = "Evelyn",
                            Price = 3.73m
                        },
                        new
                        {
                            ItemID = 105,
                            Name = "You're beautiful",
                            Price = 4.53m
                        },
                        new
                        {
                            ItemID = 106,
                            Name = "Amour",
                            Price = 1.89m
                        });
                });

            modelBuilder.Entity("API.Models.Order", b =>
                {
                    b.Property<long>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<decimal>("GTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OrderNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Models.OrderItem", b =>
                {
                    b.Property<long>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<long>("OrderID")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemID");

                    b.HasIndex("ItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("API.Models.OrderItem", b =>
                {
                    b.HasOne("API.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Order", "Order")
                        .WithMany("OrdersItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("API.Models.Order", b =>
                {
                    b.Navigation("OrdersItems");
                });
#pragma warning restore 612, 618
        }
    }
}
