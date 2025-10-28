using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagementSystem.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AppointmentType",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                DefaultDurationMinutes = table.Column<int>(type: "int", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AppointmentType", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Facilities",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Facilities", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ServiceCatalog",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ServiceCatalog", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                Role = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Clinics",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Clinics", x => x.Id);
                table.ForeignKey(
                    name: "FK_Clinics_Facilities_FacilityId",
                    column: x => x.FacilityId,
                    principalTable: "Facilities",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PatientCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Gender = table.Column<int>(type: "int", nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                HasInsurance = table.Column<bool>(type: "bit", nullable: false),
                WalletBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.Id);
                table.ForeignKey(
                    name: "FK_Patients_Facilities_FacilityId",
                    column: x => x.FacilityId,
                    principalTable: "Facilities",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "AuditLogs",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                EntityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PerformedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                PerformedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuditLogs", x => x.Id);
                table.ForeignKey(
                    name: "FK_AuditLogs_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "InsurancePolicies",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Insurer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                PlanName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                MemberId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InsurancePolicies", x => x.Id);
                table.ForeignKey(
                    name: "FK_InsurancePolicies_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "PatientIdentities",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                IdentityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                IdentityNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                IsVerified = table.Column<bool>(type: "bit", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PatientIdentities", x => x.Id);
                table.ForeignKey(
                    name: "FK_PatientIdentities_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Wallets",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Wallets", x => x.Id);
                table.ForeignKey(
                    name: "FK_Wallets_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "WalletTransaction",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                TransactionType = table.Column<int>(type: "int", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                BalanceBefore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                BalanceAfter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WalletTransaction", x => x.Id);
                table.ForeignKey(
                    name: "FK_WalletTransaction_Wallets_WalletId",
                    column: x => x.WalletId,
                    principalTable: "Wallets",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Appointments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AppointmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                DurationMinutes = table.Column<int>(type: "int", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false),
                InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Appointments", x => x.Id);
                table.ForeignKey(
                    name: "FK_Appointments_AppointmentType_AppointmentTypeId",
                    column: x => x.AppointmentTypeId,
                    principalTable: "AppointmentType",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Appointments_Clinics_ClinicId",
                    column: x => x.ClinicId,
                    principalTable: "Clinics",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Appointments_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Invoices",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                InvoiceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                Status = table.Column<int>(type: "int", nullable: false),
                SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                DiscountTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Invoices", x => x.Id);
                table.ForeignKey(
                    name: "FK_Invoices_Appointments_AppointmentId",
                    column: x => x.AppointmentId,
                    principalTable: "Appointments",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Invoices_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "InvoiceItems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ServiceCatalogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                ServiceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                Quantity = table.Column<int>(type: "int", nullable: false),
                UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                RequiresPreauth = table.Column<bool>(type: "bit", nullable: false),
                LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_InvoiceItems_Invoices_InvoiceId",
                    column: x => x.InvoiceId,
                    principalTable: "Invoices",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_InvoiceItems_ServiceCatalog_ServiceCatalogId",
                    column: x => x.ServiceCatalogId,
                    principalTable: "ServiceCatalog",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Payments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                PaymentMethod = table.Column<int>(type: "int", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                PaymentStatus = table.Column<int>(type: "int", nullable: false),
                TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Payments", x => x.Id);
                table.ForeignKey(
                    name: "FK_Payments_Invoices_InvoiceId",
                    column: x => x.InvoiceId,
                    principalTable: "Invoices",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Payments_Wallets_WalletId",
                    column: x => x.WalletId,
                    principalTable: "Wallets",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_AppointmentTypeId",
            table: "Appointments",
            column: "AppointmentTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_ClinicId",
            table: "Appointments",
            column: "ClinicId");

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_InvoiceId",
            table: "Appointments",
            column: "InvoiceId");

        migrationBuilder.CreateIndex(
            name: "IX_Appointments_PatientId",
            table: "Appointments",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_UserId",
            table: "AuditLogs",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Clinics_FacilityId",
            table: "Clinics",
            column: "FacilityId");

        migrationBuilder.CreateIndex(
            name: "IX_InsurancePolicies_PatientId",
            table: "InsurancePolicies",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_InvoiceItems_InvoiceId",
            table: "InvoiceItems",
            column: "InvoiceId");

        migrationBuilder.CreateIndex(
            name: "IX_InvoiceItems_ServiceCatalogId",
            table: "InvoiceItems",
            column: "ServiceCatalogId");

        migrationBuilder.CreateIndex(
            name: "IX_Invoices_AppointmentId",
            table: "Invoices",
            column: "AppointmentId");

        migrationBuilder.CreateIndex(
            name: "IX_Invoices_PatientId",
            table: "Invoices",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_PatientIdentities_PatientId",
            table: "PatientIdentities",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_Patients_FacilityId",
            table: "Patients",
            column: "FacilityId");

        migrationBuilder.CreateIndex(
            name: "IX_Payments_InvoiceId",
            table: "Payments",
            column: "InvoiceId");

        migrationBuilder.CreateIndex(
            name: "IX_Payments_WalletId",
            table: "Payments",
            column: "WalletId");

        migrationBuilder.CreateIndex(
            name: "IX_Wallets_PatientId",
            table: "Wallets",
            column: "PatientId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_WalletTransaction_WalletId",
            table: "WalletTransaction",
            column: "WalletId");

        migrationBuilder.AddForeignKey(
            name: "FK_Appointments_Invoices_InvoiceId",
            table: "Appointments",
            column: "InvoiceId",
            principalTable: "Invoices",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Appointments_AppointmentType_AppointmentTypeId",
            table: "Appointments");

        migrationBuilder.DropForeignKey(
            name: "FK_Appointments_Clinics_ClinicId",
            table: "Appointments");

        migrationBuilder.DropForeignKey(
            name: "FK_Appointments_Invoices_InvoiceId",
            table: "Appointments");

        migrationBuilder.DropTable(
            name: "AuditLogs");

        migrationBuilder.DropTable(
            name: "InsurancePolicies");

        migrationBuilder.DropTable(
            name: "InvoiceItems");

        migrationBuilder.DropTable(
            name: "PatientIdentities");

        migrationBuilder.DropTable(
            name: "Payments");

        migrationBuilder.DropTable(
            name: "WalletTransaction");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "ServiceCatalog");

        migrationBuilder.DropTable(
            name: "Wallets");

        migrationBuilder.DropTable(
            name: "AppointmentType");

        migrationBuilder.DropTable(
            name: "Clinics");

        migrationBuilder.DropTable(
            name: "Invoices");

        migrationBuilder.DropTable(
            name: "Appointments");

        migrationBuilder.DropTable(
            name: "Patients");

        migrationBuilder.DropTable(
            name: "Facilities");
    }
}
