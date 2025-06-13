using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.SqlServer.Types;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PublishDates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    VisitDates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredCategories = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    RatingHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Contact_Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Address_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_HomePhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_HomePhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    Contact_MobilePhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_MobilePhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    Contact_WorkPhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_WorkPhone_Number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathFromCEO = table.Column<SqlHierarchyId>(type: "hierarchyid", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WorkStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    WorkEndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    PerformanceReviewDates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Contact_Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Address_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_HomePhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_HomePhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    Contact_MobilePhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_MobilePhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    Contact_WorkPhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_WorkPhone_Number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedOn = table.Column<DateOnly>(type: "date", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SearchTerms = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PreferredDeliveryTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BillingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    ContactPhone_Number = table.Column<long>(type: "bigint", nullable: false),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
