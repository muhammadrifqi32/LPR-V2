using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PurchaseRequestSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial_create_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_approval_stage",
                columns: table => new
                {
                    ApprovalStageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_approval_stage", x => x.ApprovalStageId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_module_type",
                columns: table => new
                {
                    ModuleTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_module_type", x => x.ModuleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_request_type",
                columns: table => new
                {
                    RequestTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_request_type", x => x.RequestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_status",
                columns: table => new
                {
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tax",
                columns: table => new
                {
                    TaxId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaxName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: false),
                    TaxDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tax", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_uom",
                columns: table => new
                {
                    UomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UomCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_uom", x => x.UomId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_account",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_tbl_account_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_account_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_account_tbl_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_status_detail",
                columns: table => new
                {
                    StatusDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_status_detail", x => x.StatusDetailId);
                    table.ForeignKey(
                        name: "FK_tbl_status_detail_tbl_module_type_ModuleTypeId",
                        column: x => x.ModuleTypeId,
                        principalTable: "tbl_module_type",
                        principalColumn: "ModuleTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_status_detail_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_material",
                columns: table => new
                {
                    MaterialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_tbl_material_tbl_uom_UomId",
                        column: x => x.UomId,
                        principalTable: "tbl_uom",
                        principalColumn: "UomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_activity_log",
                columns: table => new
                {
                    ActivityLogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_activity_log", x => x.ActivityLogId);
                    table.ForeignKey(
                        name: "FK_tbl_activity_log_tbl_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_company",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_tbl_company_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_proposal",
                columns: table => new
                {
                    ProposalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequesterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalDate = table.Column<DateTime>(type: "date", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalAttachmentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_proposal", x => x.ProposalId);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_tbl_account_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_refresh_token",
                columns: table => new
                {
                    RefreshTokenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_refresh_token", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_tbl_refresh_token_tbl_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_detail",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_detail", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tbl_user_detail_tbl_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_vendor",
                columns: table => new
                {
                    VendorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_vendor", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_tbl_vendor_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_procurement_request",
                columns: table => new
                {
                    ProcurementRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProcurementRequestNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequesterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "date", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_procurement_request", x => x.ProcurementRequestId);
                    table.ForeignKey(
                        name: "FK_tbl_procurement_request_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_procurement_request_tbl_account_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_procurement_request_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_procurement_request_tbl_proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "tbl_proposal",
                        principalColumn: "ProposalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_procurement_request_tbl_request_type_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "tbl_request_type",
                        principalColumn: "RequestTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_procurement_request_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_proposal_detail",
                columns: table => new
                {
                    ProposalDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ApprovedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_proposal_detail", x => x.ProposalDetailId);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_detail_tbl_material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "tbl_material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_detail_tbl_proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "tbl_proposal",
                        principalColumn: "ProposalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_detail_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_proposal_detail_tbl_uom_UomId",
                        column: x => x.UomId,
                        principalTable: "tbl_uom",
                        principalColumn: "UomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_approval_record",
                columns: table => new
                {
                    ApprovalRecordId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProcurementRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprovalStageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_approval_record", x => x.ApprovalRecordId);
                    table.ForeignKey(
                        name: "FK_tbl_approval_record_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_approval_record_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_approval_record_tbl_approval_stage_ApprovalStageId",
                        column: x => x.ApprovalStageId,
                        principalTable: "tbl_approval_stage",
                        principalColumn: "ApprovalStageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_approval_record_tbl_procurement_request_ProcurementRequestId",
                        column: x => x.ProcurementRequestId,
                        principalTable: "tbl_procurement_request",
                        principalColumn: "ProcurementRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_approval_record_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_purchase_request",
                columns: table => new
                {
                    PurchaseRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseRequestNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProcurementRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_purchase_request", x => x.PurchaseRequestId);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_tbl_procurement_request_ProcurementRequestId",
                        column: x => x.ProcurementRequestId,
                        principalTable: "tbl_procurement_request",
                        principalColumn: "ProcurementRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_purchase_order",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VendorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PoDate = table.Column<DateTime>(type: "date", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GrandtotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PurchaseOrderAttachmentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_purchase_order", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_tbl_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tbl_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_tbl_purchase_request_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "tbl_purchase_request",
                        principalColumn: "PurchaseRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_tbl_tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "tbl_tax",
                        principalColumn: "TaxId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_tbl_vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "tbl_vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_purchase_request_detail",
                columns: table => new
                {
                    PurchaseRequestDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseRequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposalDetailId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaterialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_purchase_request_detail", x => x.PurchaseRequestDetailId);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_detail_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_detail_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_detail_tbl_material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "tbl_material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_detail_tbl_proposal_detail_ProposalDetailId",
                        column: x => x.ProposalDetailId,
                        principalTable: "tbl_proposal_detail",
                        principalColumn: "ProposalDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_detail_tbl_purchase_request_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "tbl_purchase_request",
                        principalColumn: "PurchaseRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_request_detail_tbl_uom_UomId",
                        column: x => x.UomId,
                        principalTable: "tbl_uom",
                        principalColumn: "UomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_goods_receipt",
                columns: table => new
                {
                    GoodsReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsReceiptNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HasDiscrepancy = table.Column<bool>(type: "bit", nullable: false),
                    DiscrepancyNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_goods_receipt", x => x.GoodsReceiptId);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_tbl_purchase_order_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "tbl_purchase_order",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_purchase_order_detail",
                columns: table => new
                {
                    PurchaseOrderDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseRequestDetailId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaterialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DetailNo = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubtotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_purchase_order_detail", x => x.PurchaseOrderDetailId);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_detail_tbl_material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "tbl_material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_detail_tbl_purchase_order_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "tbl_purchase_order",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_detail_tbl_purchase_request_detail_PurchaseRequestDetailId",
                        column: x => x.PurchaseRequestDetailId,
                        principalTable: "tbl_purchase_request_detail",
                        principalColumn: "PurchaseRequestDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_detail_tbl_uom_UomId",
                        column: x => x.UomId,
                        principalTable: "tbl_uom",
                        principalColumn: "UomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    SubtotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StatusDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceProofPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_tbl_invoice_tbl_goods_receipt_GoodsReceiptId",
                        column: x => x.GoodsReceiptId,
                        principalTable: "tbl_goods_receipt",
                        principalColumn: "GoodsReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_invoice_tbl_purchase_order_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "tbl_purchase_order",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_invoice_tbl_status_detail_StatusDetailId",
                        column: x => x.StatusDetailId,
                        principalTable: "tbl_status_detail",
                        principalColumn: "StatusDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_purchase_order_payment",
                columns: table => new
                {
                    PurchaseOrderPaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: true),
                    DueDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentProofPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_purchase_order_payment", x => x.PurchaseOrderPaymentId);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_payment_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_payment_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_payment_tbl_goods_receipt_GoodsReceiptId",
                        column: x => x.GoodsReceiptId,
                        principalTable: "tbl_goods_receipt",
                        principalColumn: "GoodsReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_payment_tbl_purchase_order_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "tbl_purchase_order",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_purchase_order_payment_tbl_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbl_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_goods_receipt_detail",
                columns: table => new
                {
                    GoodsReceiptDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DetailNo = table.Column<int>(type: "int", nullable: false),
                    ReceivedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    IsMatchPo = table.Column<bool>(type: "bit", nullable: false),
                    DiscrepancyType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsReceiptAttachmentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_goods_receipt_detail", x => x.GoodsReceiptDetailId);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_detail_tbl_account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_detail_tbl_account_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_detail_tbl_goods_receipt_GoodsReceiptId",
                        column: x => x.GoodsReceiptId,
                        principalTable: "tbl_goods_receipt",
                        principalColumn: "GoodsReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_detail_tbl_material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "tbl_material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_detail_tbl_purchase_order_detail_PurchaseOrderDetailId",
                        column: x => x.PurchaseOrderDetailId,
                        principalTable: "tbl_purchase_order_detail",
                        principalColumn: "PurchaseOrderDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_goods_receipt_detail_tbl_uom_UomId",
                        column: x => x.UomId,
                        principalTable: "tbl_uom",
                        principalColumn: "UomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_payment",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentProofPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_tbl_payment_tbl_invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "tbl_invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_payment_tbl_status_detail_StatusDetailId",
                        column: x => x.StatusDetailId,
                        principalTable: "tbl_status_detail",
                        principalColumn: "StatusDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tbl_approval_stage",
                columns: new[] { "ApprovalStageId", "CreatedAt", "IsDeleted", "StageName", "UpdatedAt" },
                values: new object[,]
                {
                    { "STAGE_CHAIRMAN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Chairman", null },
                    { "STAGE_GM", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "GM", null },
                    { "STAGE_PROCURE", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Procure", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_company",
                columns: new[] { "CompanyId", "CompanyCode", "CompanyName", "CreatedAt", "CreatedBy", "IsDeleted", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "COMPANY_TEST", "CMP001", "PT Test Company", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, null, null });

            migrationBuilder.InsertData(
                table: "tbl_module_type",
                columns: new[] { "ModuleTypeId", "CreatedAt", "ModuleTypeCode", "ModuleTypeDescription", "UpdatedAt" },
                values: new object[,]
                {
                    { "MODULE_GOODS_RECEIPT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "GOODS_RECEIPT", "Goods Receipt Workflow", null },
                    { "MODULE_INVOICE", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "INVOICE", "Invoice Workflow", null },
                    { "MODULE_PAYMENT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PAYMENT", "Payment Workflow", null },
                    { "MODULE_PROCUREMENT_REQUEST", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PROCUREMENT_REQUEST", "Procurement Request Workflow", null },
                    { "MODULE_PROPOSAL", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PROPOSAL", "Proposal Workflow", null },
                    { "MODULE_PURCHASE_ORDER", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PURCHASE_ORDER", "Purchase Order Workflow", null },
                    { "MODULE_PURCHASE_REQUEST", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PURCHASE_REQUEST", "Purchase Request Workflow", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_request_type",
                columns: new[] { "RequestTypeId", "CreatedAt", "Description", "RequestTypeCode", "RequestTypeName", "UpdatedAt" },
                values: new object[,]
                {
                    { "REQ_NON_PROJECT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Created directly by Procurement", "NON_PROJECT", "Non-Project", null },
                    { "REQ_PROJECT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Starts from an approved Proposal", "PROJECT", "Project", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_role",
                columns: new[] { "RoleId", "CreatedAt", "Description", "RoleCode", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { "ROLE_ADMIN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System administrator", "ADMIN", "Administrator", null },
                    { "ROLE_CHAIRMAN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Offline final approver", "CHAIRMAN", "Chairman", null },
                    { "ROLE_GM", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Approves purchase requests and records Chairman decisions", "GM", "General Manager", null },
                    { "ROLE_PROCURE", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Reviews proposals and creates non-project requests / POs", "PROCURE", "Procurement", null },
                    { "ROLE_PROJECT_ADMIN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Generates purchase orders", "PROJECT_ADMIN", "Project Admin", null },
                    { "ROLE_REQUESTER", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Creates proposals and project purchase requests", "REQUESTER", "Requester", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_status",
                columns: new[] { "StatusId", "CreatedAt", "IsDeleted", "StatusName", "UpdatedAt" },
                values: new object[,]
                {
                    { "STATUS_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "APPROVED", null },
                    { "STATUS_CHAIRMAN_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "CHAIRMAN_APPROVED", null },
                    { "STATUS_DRAFT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "DRAFT", null },
                    { "STATUS_FULLY_RECEIVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "FULLY_RECEIVED", null },
                    { "STATUS_GM_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "GM_APPROVED", null },
                    { "STATUS_PAID", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PAID", null },
                    { "STATUS_PARTIALLY_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PARTIALLY_APPROVED", null },
                    { "STATUS_PARTIALLY_PAID", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PARTIALLY_PAID", null },
                    { "STATUS_PARTIALLY_RECEIVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PARTIALLY_RECEIVED", null },
                    { "STATUS_PENDING", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PENDING", null },
                    { "STATUS_PENDING_CHAIRMAN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PENDING_CHAIRMAN_APPROVAL", null },
                    { "STATUS_PENDING_GM", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PENDING_GM_APPROVAL", null },
                    { "STATUS_PO_OPEN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PO_OPEN", null },
                    { "STATUS_REJECTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "REJECTED", null },
                    { "STATUS_REVISION_REQUIRED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "REVISION_REQUIRED", null },
                    { "STATUS_SUBMITTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "SUBMITTED", null },
                    { "STATUS_UNDER_REVIEW", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "UNDER_REVIEW", null },
                    { "STATUS_UNPAID", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "UNPAID", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_tax",
                columns: new[] { "TaxId", "CreatedAt", "TaxCode", "TaxDescription", "TaxName", "TaxRate", "UpdatedAt" },
                values: new object[] { "TAX_PPN11", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "PPN11", "Value added tax 11%", "PPN 11%", 0.11m, null });

            migrationBuilder.InsertData(
                table: "tbl_uom",
                columns: new[] { "UomId", "CreatedAt", "IsDeleted", "UomCode", "UomName", "UpdatedAt" },
                values: new object[] { "UOM_PCS", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "PCS", "Pieces", null });

            migrationBuilder.InsertData(
                table: "tbl_vendor",
                columns: new[] { "VendorId", "CreatedAt", "CreatedBy", "IsDeleted", "UpdatedAt", "UpdatedBy", "VendorCode", "VendorName" },
                values: new object[] { "VENDOR_TEST", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, null, null, "VND001", "PT Test Vendor" });

            migrationBuilder.InsertData(
                table: "tbl_account",
                columns: new[] { "AccountId", "CreatedAt", "CreatedBy", "Email", "IsDeleted", "LastLoginAt", "Password", "RoleId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ACCOUNT_GM", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "gm@test.com", false, null, "DUMMY_PASSWORD_NOT_USED_YET", "ROLE_GM", null, null },
                    { "ACCOUNT_PROCURE", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "procure@test.com", false, null, "DUMMY_PASSWORD_NOT_USED_YET", "ROLE_PROCURE", null, null },
                    { "ACCOUNT_REQUESTER", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "requester@test.com", false, null, "DUMMY_PASSWORD_NOT_USED_YET", "ROLE_REQUESTER", null, null },
                    { "ACCOUNT_SUPER_ADMIN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "superadmin@maser.com", false, null, "$2a$11$REPLACE_WITH_BCRYPT_HASH", "ROLE_ADMIN", null, null }
                });

            migrationBuilder.InsertData(
                table: "tbl_material",
                columns: new[] { "MaterialId", "CreatedAt", "Description", "MaterialCode", "MaterialName", "UomId", "UpdatedAt" },
                values: new object[] { "MAT_CEMENT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cement for construction work", "MAT001", "Cement", "UOM_PCS", null });

            migrationBuilder.InsertData(
                table: "tbl_status_detail",
                columns: new[] { "StatusDetailId", "CreatedAt", "ModuleTypeId", "StatusId", "UpdatedAt" },
                values: new object[,]
                {
                    { "MODULE_GOODS_RECEIPT_STATUS_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_GOODS_RECEIPT", "STATUS_APPROVED", null },
                    { "MODULE_GOODS_RECEIPT_STATUS_FULLY_RECEIVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_GOODS_RECEIPT", "STATUS_FULLY_RECEIVED", null },
                    { "MODULE_GOODS_RECEIPT_STATUS_PARTIALLY_RECEIVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_GOODS_RECEIPT", "STATUS_PARTIALLY_RECEIVED", null },
                    { "MODULE_GOODS_RECEIPT_STATUS_PENDING", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_GOODS_RECEIPT", "STATUS_PENDING", null },
                    { "MODULE_GOODS_RECEIPT_STATUS_REJECTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_GOODS_RECEIPT", "STATUS_REJECTED", null },
                    { "MODULE_INVOICE_STATUS_PAID", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_INVOICE", "STATUS_PAID", null },
                    { "MODULE_INVOICE_STATUS_PARTIALLY_PAID", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_INVOICE", "STATUS_PARTIALLY_PAID", null },
                    { "MODULE_INVOICE_STATUS_UNPAID", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_INVOICE", "STATUS_UNPAID", null },
                    { "MODULE_PAYMENT_STATUS_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PAYMENT", "STATUS_APPROVED", null },
                    { "MODULE_PAYMENT_STATUS_PENDING", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PAYMENT", "STATUS_PENDING", null },
                    { "MODULE_PAYMENT_STATUS_REJECTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PAYMENT", "STATUS_REJECTED", null },
                    { "MODULE_PROCUREMENT_REQUEST_STATUS_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROCUREMENT_REQUEST", "STATUS_APPROVED", null },
                    { "MODULE_PROCUREMENT_REQUEST_STATUS_DRAFT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROCUREMENT_REQUEST", "STATUS_DRAFT", null },
                    { "MODULE_PROCUREMENT_REQUEST_STATUS_PENDING", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROCUREMENT_REQUEST", "STATUS_PENDING", null },
                    { "MODULE_PROCUREMENT_REQUEST_STATUS_REJECTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROCUREMENT_REQUEST", "STATUS_REJECTED", null },
                    { "MODULE_PROCUREMENT_REQUEST_STATUS_REVISION_REQUIRED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROCUREMENT_REQUEST", "STATUS_REVISION_REQUIRED", null },
                    { "MODULE_PROCUREMENT_REQUEST_STATUS_SUBMITTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROCUREMENT_REQUEST", "STATUS_SUBMITTED", null },
                    { "MODULE_PROPOSAL_STATUS_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_APPROVED", null },
                    { "MODULE_PROPOSAL_STATUS_DRAFT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_DRAFT", null },
                    { "MODULE_PROPOSAL_STATUS_PARTIALLY_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_PARTIALLY_APPROVED", null },
                    { "MODULE_PROPOSAL_STATUS_PENDING", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_PENDING", null },
                    { "MODULE_PROPOSAL_STATUS_REJECTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_REJECTED", null },
                    { "MODULE_PROPOSAL_STATUS_REVISION_REQUIRED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_REVISION_REQUIRED", null },
                    { "MODULE_PROPOSAL_STATUS_SUBMITTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_SUBMITTED", null },
                    { "MODULE_PROPOSAL_STATUS_UNDER_REVIEW", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PROPOSAL", "STATUS_UNDER_REVIEW", null },
                    { "MODULE_PURCHASE_ORDER_STATUS_FULLY_RECEIVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_ORDER", "STATUS_FULLY_RECEIVED", null },
                    { "MODULE_PURCHASE_ORDER_STATUS_PARTIALLY_RECEIVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_ORDER", "STATUS_PARTIALLY_RECEIVED", null },
                    { "MODULE_PURCHASE_ORDER_STATUS_PO_OPEN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_ORDER", "STATUS_PO_OPEN", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_APPROVED", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_CHAIRMAN_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_CHAIRMAN_APPROVED", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_DRAFT", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_DRAFT", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_GM_APPROVED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_GM_APPROVED", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_PENDING_CHAIRMAN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_PENDING_CHAIRMAN", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_PENDING_GM", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_PENDING_GM", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_REJECTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_REJECTED", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_REVISION_REQUIRED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_REVISION_REQUIRED", null },
                    { "MODULE_PURCHASE_REQUEST_STATUS_SUBMITTED", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "MODULE_PURCHASE_REQUEST", "STATUS_SUBMITTED", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_user_detail",
                columns: new[] { "UserId", "AccountId", "CreatedAt", "FullName", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { "USER_ADMIN", "ACCOUNT_SUPER_ADMIN", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Super Admin", "081234567893", null },
                    { "USER_GM", "ACCOUNT_GM", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Test GM", "081234567892", null },
                    { "USER_PROCURE", "ACCOUNT_PROCURE", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Test Procure", "081234567891", null },
                    { "USER_REQUESTER", "ACCOUNT_REQUESTER", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Test Requester", "081234567890", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_account_CreatedBy",
                table: "tbl_account",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_account_Email",
                table: "tbl_account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_account_RoleId",
                table: "tbl_account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_account_UpdatedBy",
                table: "tbl_account",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_activity_log_AccountId",
                table: "tbl_activity_log",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_activity_log_DocumentType_DocumentId",
                table: "tbl_activity_log",
                columns: new[] { "DocumentType", "DocumentId" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_approval_record_ApprovalStageId",
                table: "tbl_approval_record",
                column: "ApprovalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_approval_record_CreatedBy",
                table: "tbl_approval_record",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_approval_record_ProcurementRequestId_ApprovalStageId",
                table: "tbl_approval_record",
                columns: new[] { "ProcurementRequestId", "ApprovalStageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_approval_record_StatusId",
                table: "tbl_approval_record",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_approval_record_UpdatedBy",
                table: "tbl_approval_record",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_company_CompanyCode",
                table: "tbl_company",
                column: "CompanyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_company_CreatedBy",
                table: "tbl_company",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_GoodsReceiptNo",
                table: "tbl_goods_receipt",
                column: "GoodsReceiptNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_PurchaseOrderId",
                table: "tbl_goods_receipt",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_StatusId",
                table: "tbl_goods_receipt",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_UpdatedBy",
                table: "tbl_goods_receipt",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_detail_CreatedBy",
                table: "tbl_goods_receipt_detail",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_detail_GoodsReceiptId",
                table: "tbl_goods_receipt_detail",
                column: "GoodsReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_detail_MaterialId",
                table: "tbl_goods_receipt_detail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_detail_PurchaseOrderDetailId",
                table: "tbl_goods_receipt_detail",
                column: "PurchaseOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_detail_UomId",
                table: "tbl_goods_receipt_detail",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_goods_receipt_detail_UpdatedBy",
                table: "tbl_goods_receipt_detail",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_invoice_GoodsReceiptId",
                table: "tbl_invoice",
                column: "GoodsReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_invoice_InvoiceNo",
                table: "tbl_invoice",
                column: "InvoiceNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_invoice_PurchaseOrderId",
                table: "tbl_invoice",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_invoice_StatusDetailId",
                table: "tbl_invoice",
                column: "StatusDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_material_MaterialCode",
                table: "tbl_material",
                column: "MaterialCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_material_UomId",
                table: "tbl_material",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_module_type_ModuleTypeCode",
                table: "tbl_module_type",
                column: "ModuleTypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_payment_InvoiceId",
                table: "tbl_payment",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_payment_StatusDetailId",
                table: "tbl_payment",
                column: "StatusDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_procurement_request_CreatedBy",
                table: "tbl_procurement_request",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_procurement_request_ProcurementRequestNo",
                table: "tbl_procurement_request",
                column: "ProcurementRequestNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_procurement_request_ProposalId",
                table: "tbl_procurement_request",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_procurement_request_RequesterId",
                table: "tbl_procurement_request",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_procurement_request_RequestTypeId",
                table: "tbl_procurement_request",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_procurement_request_StatusId",
                table: "tbl_procurement_request",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_procurement_request_UpdatedBy",
                table: "tbl_procurement_request",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_CreatedBy",
                table: "tbl_proposal",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_ProposalNo",
                table: "tbl_proposal",
                column: "ProposalNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_RequesterId",
                table: "tbl_proposal",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_StatusId",
                table: "tbl_proposal",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_UpdatedBy",
                table: "tbl_proposal",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_detail_MaterialId",
                table: "tbl_proposal_detail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_detail_ProposalId",
                table: "tbl_proposal_detail",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_detail_StatusId",
                table: "tbl_proposal_detail",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proposal_detail_UomId",
                table: "tbl_proposal_detail",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_CompanyId",
                table: "tbl_purchase_order",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_CreatedBy",
                table: "tbl_purchase_order",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_PurchaseOrderNo",
                table: "tbl_purchase_order",
                column: "PurchaseOrderNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_PurchaseRequestId",
                table: "tbl_purchase_order",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_StatusId",
                table: "tbl_purchase_order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_TaxId",
                table: "tbl_purchase_order",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_UpdatedBy",
                table: "tbl_purchase_order",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_VendorId",
                table: "tbl_purchase_order",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_detail_MaterialId",
                table: "tbl_purchase_order_detail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_detail_PurchaseOrderId",
                table: "tbl_purchase_order_detail",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_detail_PurchaseRequestDetailId",
                table: "tbl_purchase_order_detail",
                column: "PurchaseRequestDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_detail_UomId",
                table: "tbl_purchase_order_detail",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_payment_CreatedBy",
                table: "tbl_purchase_order_payment",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_payment_GoodsReceiptId",
                table: "tbl_purchase_order_payment",
                column: "GoodsReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_payment_PurchaseOrderId",
                table: "tbl_purchase_order_payment",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_payment_StatusId",
                table: "tbl_purchase_order_payment",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_order_payment_UpdatedBy",
                table: "tbl_purchase_order_payment",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_CreatedBy",
                table: "tbl_purchase_request",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_ProcurementRequestId",
                table: "tbl_purchase_request",
                column: "ProcurementRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_PurchaseRequestNo",
                table: "tbl_purchase_request",
                column: "PurchaseRequestNo",
                unique: true,
                filter: "[PurchaseRequestNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_StatusId",
                table: "tbl_purchase_request",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_UpdatedBy",
                table: "tbl_purchase_request",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_detail_CreatedBy",
                table: "tbl_purchase_request_detail",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_detail_MaterialId",
                table: "tbl_purchase_request_detail",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_detail_ProposalDetailId",
                table: "tbl_purchase_request_detail",
                column: "ProposalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_detail_PurchaseRequestId",
                table: "tbl_purchase_request_detail",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_detail_UomId",
                table: "tbl_purchase_request_detail",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_purchase_request_detail_UpdatedBy",
                table: "tbl_purchase_request_detail",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_refresh_token_AccountId",
                table: "tbl_refresh_token",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_refresh_token_TokenHash",
                table: "tbl_refresh_token",
                column: "TokenHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_request_type_RequestTypeCode",
                table: "tbl_request_type",
                column: "RequestTypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_RoleCode",
                table: "tbl_role",
                column: "RoleCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_status_detail_ModuleTypeId_StatusId",
                table: "tbl_status_detail",
                columns: new[] { "ModuleTypeId", "StatusId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_status_detail_StatusId",
                table: "tbl_status_detail",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_tax_TaxCode",
                table: "tbl_tax",
                column: "TaxCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_uom_UomCode",
                table: "tbl_uom",
                column: "UomCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_detail_AccountId",
                table: "tbl_user_detail",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_vendor_CreatedBy",
                table: "tbl_vendor",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_vendor_VendorCode",
                table: "tbl_vendor",
                column: "VendorCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_activity_log");

            migrationBuilder.DropTable(
                name: "tbl_approval_record");

            migrationBuilder.DropTable(
                name: "tbl_goods_receipt_detail");

            migrationBuilder.DropTable(
                name: "tbl_payment");

            migrationBuilder.DropTable(
                name: "tbl_purchase_order_payment");

            migrationBuilder.DropTable(
                name: "tbl_refresh_token");

            migrationBuilder.DropTable(
                name: "tbl_user_detail");

            migrationBuilder.DropTable(
                name: "tbl_approval_stage");

            migrationBuilder.DropTable(
                name: "tbl_purchase_order_detail");

            migrationBuilder.DropTable(
                name: "tbl_invoice");

            migrationBuilder.DropTable(
                name: "tbl_purchase_request_detail");

            migrationBuilder.DropTable(
                name: "tbl_goods_receipt");

            migrationBuilder.DropTable(
                name: "tbl_status_detail");

            migrationBuilder.DropTable(
                name: "tbl_proposal_detail");

            migrationBuilder.DropTable(
                name: "tbl_purchase_order");

            migrationBuilder.DropTable(
                name: "tbl_module_type");

            migrationBuilder.DropTable(
                name: "tbl_material");

            migrationBuilder.DropTable(
                name: "tbl_company");

            migrationBuilder.DropTable(
                name: "tbl_purchase_request");

            migrationBuilder.DropTable(
                name: "tbl_tax");

            migrationBuilder.DropTable(
                name: "tbl_vendor");

            migrationBuilder.DropTable(
                name: "tbl_uom");

            migrationBuilder.DropTable(
                name: "tbl_procurement_request");

            migrationBuilder.DropTable(
                name: "tbl_proposal");

            migrationBuilder.DropTable(
                name: "tbl_request_type");

            migrationBuilder.DropTable(
                name: "tbl_account");

            migrationBuilder.DropTable(
                name: "tbl_status");

            migrationBuilder.DropTable(
                name: "tbl_role");
        }
    }
}
