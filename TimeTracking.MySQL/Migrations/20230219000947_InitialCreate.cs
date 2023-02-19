using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TimeTracking.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "time_tracking");

            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                schema: "time_tracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    street = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    house = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    appartment = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    postal_code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    fax = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "day_mark",
                schema: "time_tracking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    @short = table.Column<string>(name: "short", type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idx_pk_day_mark", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                schema: "time_tracking",
                columns: table => new
                {
                    ID = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idx_pk_department", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "position",
                schema: "time_tracking",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idx_pk_position", x => x.position_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "time_tracking",
                columns: table => new
                {
                    ID = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    personnel_number = table.Column<int>(type: "int", nullable: false),
                    birth_date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    photo = table.Column<byte[]>(type: "BLOB", maxLength: 1000000000, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idx_pk_employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_employee_address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "time_tracking",
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee_calendar_item",
                schema: "time_tracking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    day_mark_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idx_pk_employee_calendar_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_calendar_item_employee_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "time_tracking",
                        principalTable: "employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_item_day_mark",
                        column: x => x.day_mark_id,
                        principalSchema: "time_tracking",
                        principalTable: "day_mark",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "position_assignment",
                schema: "time_tracking",
                columns: table => new
                {
                    ID = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    department_ID = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    employee_ID = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    date_created = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    date_modified = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    position_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idx_pk_position_assignment", x => x.ID);
                    table.ForeignKey(
                        name: "fk_department_position_assignment",
                        column: x => x.department_ID,
                        principalSchema: "time_tracking",
                        principalTable: "department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employee_position_assignment",
                        column: x => x.employee_ID,
                        principalSchema: "time_tracking",
                        principalTable: "employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_position_position_assignment",
                        column: x => x.position_ID,
                        principalSchema: "time_tracking",
                        principalTable: "position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_employee_AddressId",
                schema: "time_tracking",
                table: "employee",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_personnel_number",
                schema: "time_tracking",
                table: "employee",
                column: "personnel_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_calendar_item_day_mark_id",
                schema: "time_tracking",
                table: "employee_calendar_item",
                column: "day_mark_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_calendar_item_employee_id",
                schema: "time_tracking",
                table: "employee_calendar_item",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_position_assignment_department_ID",
                schema: "time_tracking",
                table: "position_assignment",
                column: "department_ID");

            migrationBuilder.CreateIndex(
                name: "IX_position_assignment_employee_ID",
                schema: "time_tracking",
                table: "position_assignment",
                column: "employee_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_position_assignment_position_ID",
                schema: "time_tracking",
                table: "position_assignment",
                column: "position_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_calendar_item",
                schema: "time_tracking");

            migrationBuilder.DropTable(
                name: "position_assignment",
                schema: "time_tracking");

            migrationBuilder.DropTable(
                name: "day_mark",
                schema: "time_tracking");

            migrationBuilder.DropTable(
                name: "department",
                schema: "time_tracking");

            migrationBuilder.DropTable(
                name: "employee",
                schema: "time_tracking");

            migrationBuilder.DropTable(
                name: "position",
                schema: "time_tracking");

            migrationBuilder.DropTable(
                name: "address",
                schema: "time_tracking");
        }
    }
}
