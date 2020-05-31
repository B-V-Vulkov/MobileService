using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileService.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DeviceModels",
                columns: table => new
                {
                    DeviceModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceModelName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceModels", x => x.DeviceModelId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    EmployeePositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePositionName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.EmployeePositionId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RepairTypes",
                columns: table => new
                {
                    RepairTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTypes", x => x.RepairTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Password = table.Column<string>(maxLength: 80, nullable: false),
                    EmployeePositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeePositions_EmployeePositionId",
                        column: x => x.EmployeePositionId,
                        principalTable: "EmployeePositions",
                        principalColumn: "EmployeePositionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepairPrices",
                columns: table => new
                {
                    DeviceModelId = table.Column<int>(nullable: false),
                    RepairTypeId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairPrices", x => new { x.DeviceModelId, x.RepairTypeId });
                    table.ForeignKey(
                        name: "FK_RepairPrices_DeviceModels_DeviceModelId",
                        column: x => x.DeviceModelId,
                        principalTable: "DeviceModels",
                        principalColumn: "DeviceModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairPrices_RepairTypes_RepairTypeId",
                        column: x => x.RepairTypeId,
                        principalTable: "RepairTypes",
                        principalColumn: "RepairTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(maxLength: 8, nullable: false),
                    OrderPassword = table.Column<string>(maxLength: 8, nullable: false),
                    RepairDescription = table.Column<string>(nullable: true),
                    OrderedOn = table.Column<DateTime>(nullable: false),
                    RepairedOn = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    ReceptionistId = table.Column<int>(nullable: false),
                    ServiceWorkerId = table.Column<int>(nullable: true),
                    DeviceModelId = table.Column<int>(nullable: false),
                    RepairTypeId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_DeviceModels_DeviceModelId",
                        column: x => x.DeviceModelId,
                        principalTable: "DeviceModels",
                        principalColumn: "DeviceModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_RepairTypes_RepairTypeId",
                        column: x => x.RepairTypeId,
                        principalTable: "RepairTypes",
                        principalColumn: "RepairTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_ServiceWorkerId",
                        column: x => x.ServiceWorkerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeePositionId",
                table: "Employees",
                column: "EmployeePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Password",
                table: "Employees",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeviceModelId",
                table: "Orders",
                column: "DeviceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPassword",
                table: "Orders",
                column: "OrderPassword");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReceptionistId",
                table: "Orders",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RepairTypeId",
                table: "Orders",
                column: "RepairTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceWorkerId",
                table: "Orders",
                column: "ServiceWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairPrices_RepairTypeId",
                table: "RepairPrices",
                column: "RepairTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RepairPrices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "DeviceModels");

            migrationBuilder.DropTable(
                name: "RepairTypes");

            migrationBuilder.DropTable(
                name: "EmployeePositions");
        }
    }
}
