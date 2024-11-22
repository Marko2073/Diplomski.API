using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomski.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Category_CategoryId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersion_Models_ModelId",
                table: "ModelVersion");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecification_ModelVersion_ModelVersionId",
                table: "ModelVersionSpecification");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecification_Specification_SpecificationId",
                table: "ModelVersionSpecification");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Specification_ParentId",
                table: "Specification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specification",
                table: "Specification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelVersionSpecification",
                table: "ModelVersionSpecification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelVersion",
                table: "ModelVersion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Specification",
                newName: "Specifications");

            migrationBuilder.RenameTable(
                name: "ModelVersionSpecification",
                newName: "ModelVersionSpecifications");

            migrationBuilder.RenameTable(
                name: "ModelVersion",
                newName: "ModelVersions");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Specification_ParentId",
                table: "Specifications",
                newName: "IX_Specifications_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelVersionSpecification_SpecificationId",
                table: "ModelVersionSpecifications",
                newName: "IX_ModelVersionSpecifications_SpecificationId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelVersionSpecification_ModelVersionId",
                table: "ModelVersionSpecifications",
                newName: "IX_ModelVersionSpecifications_ModelVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelVersion_ModelId",
                table: "ModelVersions",
                newName: "IX_ModelVersions_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentId",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelVersionSpecifications",
                table: "ModelVersionSpecifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelVersions",
                table: "ModelVersions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_ModelVersions_ModelVersionId",
                        column: x => x.ModelVersionId,
                        principalTable: "ModelVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    PriceValue = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_ModelVersions_ModelVersionId",
                        column: x => x.ModelVersionId,
                        principalTable: "ModelVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    isProcessed = table.Column<bool>(type: "bit", nullable: false),
                    isConfiguration = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ModelVersionId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_ModelVersions_ModelVersionId",
                        column: x => x.ModelVersionId,
                        principalTable: "ModelVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ModelVersionId",
                table: "CartItem",
                column: "ModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ModelVersionId",
                table: "Picture",
                column: "ModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ModelVersionId",
                table: "Price",
                column: "ModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Categories_CategoryId",
                table: "Models",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersions_Models_ModelId",
                table: "ModelVersions",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications",
                column: "ModelVersionId",
                principalTable: "ModelVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Specifications_ParentId",
                table: "Specifications",
                column: "ParentId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Categories_CategoryId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersions_Models_ModelId",
                table: "ModelVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_ModelVersions_ModelVersionId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelVersionSpecifications_Specifications_SpecificationId",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Specifications_ParentId",
                table: "Specifications");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specifications",
                table: "Specifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelVersionSpecifications",
                table: "ModelVersionSpecifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelVersions",
                table: "ModelVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Specifications",
                newName: "Specification");

            migrationBuilder.RenameTable(
                name: "ModelVersionSpecifications",
                newName: "ModelVersionSpecification");

            migrationBuilder.RenameTable(
                name: "ModelVersions",
                newName: "ModelVersion");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Specifications_ParentId",
                table: "Specification",
                newName: "IX_Specification_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelVersionSpecifications_SpecificationId",
                table: "ModelVersionSpecification",
                newName: "IX_ModelVersionSpecification_SpecificationId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelVersionSpecifications_ModelVersionId",
                table: "ModelVersionSpecification",
                newName: "IX_ModelVersionSpecification_ModelVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelVersions_ModelId",
                table: "ModelVersion",
                newName: "IX_ModelVersion_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                table: "Category",
                newName: "IX_Category_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specification",
                table: "Specification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelVersionSpecification",
                table: "ModelVersionSpecification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelVersion",
                table: "ModelVersion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category",
                column: "ParentId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Category_CategoryId",
                table: "Models",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersion_Models_ModelId",
                table: "ModelVersion",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecification_ModelVersion_ModelVersionId",
                table: "ModelVersionSpecification",
                column: "ModelVersionId",
                principalTable: "ModelVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelVersionSpecification_Specification_SpecificationId",
                table: "ModelVersionSpecification",
                column: "SpecificationId",
                principalTable: "Specification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Specification_ParentId",
                table: "Specification",
                column: "ParentId",
                principalTable: "Specification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
