using Microsoft.EntityFrameworkCore;
using PurchaseRequestSystem.Models;

namespace PurchaseRequestSystem.Data.Seed;

/// <summary>
/// Seed data adjusted to the latest ERD documentation.
/// Master IDs are stable string IDs for deterministic migrations.
/// Runtime transaction IDs are generated with UlidHelper.NewUlid().
/// </summary>
public static class SeedData
{
    private static readonly DateTime Seeded = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    // ROLES
    public const string ROLE_REQUESTER = "ROLE_REQUESTER";
    public const string ROLE_PROCURE = "ROLE_PROCURE";
    public const string ROLE_GM = "ROLE_GM";
    public const string ROLE_CHAIRMAN = "ROLE_CHAIRMAN";
    public const string ROLE_PROJECT_ADMIN = "ROLE_PROJECT_ADMIN";
    public const string ROLE_ADMIN = "ROLE_ADMIN";

    // ACCOUNTS
    public const string ACCOUNT_REQUESTER = "ACCOUNT_REQUESTER";
    public const string ACCOUNT_PROCURE = "ACCOUNT_PROCURE";
    public const string ACCOUNT_GM = "ACCOUNT_GM";
    public const string ACCOUNT_ADMIN = "ACCOUNT_SUPER_ADMIN";

    // REQUEST TYPES
    public const string REQ_PROJECT = "REQ_PROJECT";
    public const string REQ_NON_PROJECT = "REQ_NON_PROJECT";

    // APPROVAL STAGES
    public const string STAGE_PROCURE = "STAGE_PROCURE";
    public const string STAGE_GM = "STAGE_GM";
    public const string STAGE_CHAIRMAN = "STAGE_CHAIRMAN";

    // MODULE TYPES
    public const string MODULE_PROPOSAL = "MODULE_PROPOSAL";
    public const string MODULE_PROCUREMENT_REQUEST = "MODULE_PROCUREMENT_REQUEST";
    public const string MODULE_PURCHASE_REQUEST = "MODULE_PURCHASE_REQUEST";
    public const string MODULE_PURCHASE_ORDER = "MODULE_PURCHASE_ORDER";
    public const string MODULE_GOODS_RECEIPT = "MODULE_GOODS_RECEIPT";
    public const string MODULE_INVOICE = "MODULE_INVOICE";
    public const string MODULE_PAYMENT = "MODULE_PAYMENT";

    // STATUS
    public const string STATUS_DRAFT = "STATUS_DRAFT";
    public const string STATUS_PENDING = "STATUS_PENDING";
    public const string STATUS_SUBMITTED = "STATUS_SUBMITTED";
    public const string STATUS_UNDER_REVIEW = "STATUS_UNDER_REVIEW";
    public const string STATUS_APPROVED = "STATUS_APPROVED";
    public const string STATUS_REJECTED = "STATUS_REJECTED";
    public const string STATUS_REVISION_REQUIRED = "STATUS_REVISION_REQUIRED";
    public const string STATUS_PARTIALLY_APPROVED = "STATUS_PARTIALLY_APPROVED";
    public const string STATUS_PO_OPEN = "STATUS_PO_OPEN";
    public const string STATUS_PARTIALLY_RECEIVED = "STATUS_PARTIALLY_RECEIVED";
    public const string STATUS_FULLY_RECEIVED = "STATUS_FULLY_RECEIVED";
    public const string STATUS_UNPAID = "STATUS_UNPAID";
    public const string STATUS_PARTIALLY_PAID = "STATUS_PARTIALLY_PAID";
    public const string STATUS_PAID = "STATUS_PAID";
    public const string STATUS_PENDING_GM = "STATUS_PENDING_GM";
    public const string STATUS_GM_APPROVED = "STATUS_GM_APPROVED";
    public const string STATUS_PENDING_CHAIRMAN = "STATUS_PENDING_CHAIRMAN";
    public const string STATUS_CHAIRMAN_APPROVED = "STATUS_CHAIRMAN_APPROVED";

    // SIMPLE MASTER SAMPLE DATA
    public const string UOM_PCS = "UOM_PCS";
    public const string MAT_CEMENT = "MAT_CEMENT";
    public const string VENDOR_TEST = "VENDOR_TEST";
    public const string COMPANY_TEST = "COMPANY_TEST";
    public const string TAX_PPN11 = "TAX_PPN11";

    public static void Apply(ModelBuilder modelBuilder)
    {
        SeedRoles(modelBuilder);
        SeedRequestTypes(modelBuilder);
        SeedModuleTypes(modelBuilder);
        SeedApprovalStages(modelBuilder);
        SeedStatus(modelBuilder);
        SeedStatusDetails(modelBuilder);
        SeedAccounts(modelBuilder);
        SeedMasterSamples(modelBuilder);
    }

    private static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = ROLE_REQUESTER, RoleCode = "REQUESTER", RoleName = "Requester", Description = "Creates proposals and project purchase requests", CreatedAt = Seeded },
            new Role { RoleId = ROLE_PROCURE, RoleCode = "PROCURE", RoleName = "Procurement", Description = "Reviews proposals and creates non-project requests / POs", CreatedAt = Seeded },
            new Role { RoleId = ROLE_GM, RoleCode = "GM", RoleName = "General Manager", Description = "Approves purchase requests and records Chairman decisions", CreatedAt = Seeded },
            new Role { RoleId = ROLE_CHAIRMAN, RoleCode = "CHAIRMAN", RoleName = "Chairman", Description = "Offline final approver", CreatedAt = Seeded },
            new Role { RoleId = ROLE_PROJECT_ADMIN, RoleCode = "PROJECT_ADMIN", RoleName = "Project Admin", Description = "Generates purchase orders", CreatedAt = Seeded },
            new Role { RoleId = ROLE_ADMIN, RoleCode = "ADMIN", RoleName = "Administrator", Description = "System administrator", CreatedAt = Seeded }
        );
    }

    private static void SeedRequestTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestType>().HasData(
            new RequestType { RequestTypeId = REQ_PROJECT, RequestTypeCode = "PROJECT", RequestTypeName = "Project", Description = "Starts from an approved Proposal", CreatedAt = Seeded },
            new RequestType { RequestTypeId = REQ_NON_PROJECT, RequestTypeCode = "NON_PROJECT", RequestTypeName = "Non-Project", Description = "Created directly by Procurement", CreatedAt = Seeded }
        );
    }

    private static void SeedModuleTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModuleType>().HasData(
            new ModuleType { ModuleTypeId = MODULE_PROPOSAL, ModuleTypeCode = "PROPOSAL", ModuleTypeDescription = "Proposal Workflow", CreatedAt = Seeded },
            new ModuleType { ModuleTypeId = MODULE_PROCUREMENT_REQUEST, ModuleTypeCode = "PROCUREMENT_REQUEST", ModuleTypeDescription = "Procurement Request Workflow", CreatedAt = Seeded },
            new ModuleType { ModuleTypeId = MODULE_PURCHASE_REQUEST, ModuleTypeCode = "PURCHASE_REQUEST", ModuleTypeDescription = "Purchase Request Workflow", CreatedAt = Seeded },
            new ModuleType { ModuleTypeId = MODULE_PURCHASE_ORDER, ModuleTypeCode = "PURCHASE_ORDER", ModuleTypeDescription = "Purchase Order Workflow", CreatedAt = Seeded },
            new ModuleType { ModuleTypeId = MODULE_GOODS_RECEIPT, ModuleTypeCode = "GOODS_RECEIPT", ModuleTypeDescription = "Goods Receipt Workflow", CreatedAt = Seeded },
            new ModuleType { ModuleTypeId = MODULE_INVOICE, ModuleTypeCode = "INVOICE", ModuleTypeDescription = "Invoice Workflow", CreatedAt = Seeded },
            new ModuleType { ModuleTypeId = MODULE_PAYMENT, ModuleTypeCode = "PAYMENT", ModuleTypeDescription = "Payment Workflow", CreatedAt = Seeded }
        );
    }

    private static void SeedApprovalStages(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApprovalStage>().HasData(
            new ApprovalStage { ApprovalStageId = STAGE_PROCURE, StageName = "Procure", IsDeleted = false, CreatedAt = Seeded },
            new ApprovalStage { ApprovalStageId = STAGE_GM, StageName = "GM", IsDeleted = false, CreatedAt = Seeded },
            new ApprovalStage { ApprovalStageId = STAGE_CHAIRMAN, StageName = "Chairman", IsDeleted = false, CreatedAt = Seeded }
        );
    }

    private static void SeedStatus(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { StatusId = STATUS_DRAFT, StatusName = "DRAFT", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PENDING, StatusName = "PENDING", CreatedAt = Seeded },
            new Status { StatusId = STATUS_SUBMITTED, StatusName = "SUBMITTED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_UNDER_REVIEW, StatusName = "UNDER_REVIEW", CreatedAt = Seeded },
            new Status { StatusId = STATUS_APPROVED, StatusName = "APPROVED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_REJECTED, StatusName = "REJECTED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_REVISION_REQUIRED, StatusName = "REVISION_REQUIRED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PARTIALLY_APPROVED, StatusName = "PARTIALLY_APPROVED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PO_OPEN, StatusName = "PO_OPEN", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PARTIALLY_RECEIVED, StatusName = "PARTIALLY_RECEIVED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_FULLY_RECEIVED, StatusName = "FULLY_RECEIVED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_UNPAID, StatusName = "UNPAID", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PARTIALLY_PAID, StatusName = "PARTIALLY_PAID", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PAID, StatusName = "PAID", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PENDING_GM, StatusName = "PENDING_GM_APPROVAL", CreatedAt = Seeded },
            new Status { StatusId = STATUS_GM_APPROVED, StatusName = "GM_APPROVED", CreatedAt = Seeded },
            new Status { StatusId = STATUS_PENDING_CHAIRMAN, StatusName = "PENDING_CHAIRMAN_APPROVAL", CreatedAt = Seeded },
            new Status { StatusId = STATUS_CHAIRMAN_APPROVED, StatusName = "CHAIRMAN_APPROVED", CreatedAt = Seeded }
        );
    }

    private static void SeedStatusDetails(ModelBuilder modelBuilder)
    {
        var data = new List<StatusDetail>();
        void Add(string moduleId, params string[] statuses)
        {
            foreach (var statusId in statuses)
            {
                data.Add(new StatusDetail
                {
                    StatusDetailId = $"{moduleId}_{statusId}",
                    ModuleTypeId = moduleId,
                    StatusId = statusId,
                    CreatedAt = Seeded
                });
            }
        }

        Add(MODULE_PROPOSAL, STATUS_DRAFT, STATUS_PENDING, STATUS_SUBMITTED, STATUS_UNDER_REVIEW, STATUS_APPROVED, STATUS_REJECTED, STATUS_REVISION_REQUIRED, STATUS_PARTIALLY_APPROVED);
        Add(MODULE_PROCUREMENT_REQUEST, STATUS_DRAFT, STATUS_SUBMITTED, STATUS_PENDING, STATUS_APPROVED, STATUS_REJECTED, STATUS_REVISION_REQUIRED);
        Add(MODULE_PURCHASE_REQUEST, STATUS_DRAFT, STATUS_SUBMITTED, STATUS_PENDING_GM, STATUS_GM_APPROVED, STATUS_PENDING_CHAIRMAN, STATUS_CHAIRMAN_APPROVED, STATUS_APPROVED, STATUS_REJECTED, STATUS_REVISION_REQUIRED);
        Add(MODULE_PURCHASE_ORDER, STATUS_PO_OPEN, STATUS_PARTIALLY_RECEIVED, STATUS_FULLY_RECEIVED);
        Add(MODULE_GOODS_RECEIPT, STATUS_PENDING, STATUS_PARTIALLY_RECEIVED, STATUS_FULLY_RECEIVED, STATUS_APPROVED, STATUS_REJECTED);
        Add(MODULE_INVOICE, STATUS_UNPAID, STATUS_PARTIALLY_PAID, STATUS_PAID);
        Add(MODULE_PAYMENT, STATUS_PENDING, STATUS_APPROVED, STATUS_REJECTED);

        modelBuilder.Entity<StatusDetail>().HasData(data);
    }

    private static void SeedAccounts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new Account { AccountId = ACCOUNT_REQUESTER, RoleId = ROLE_REQUESTER, Email = "requester@test.com", Password = "DUMMY_PASSWORD_NOT_USED_YET", CreatedAt = Seeded, IsDeleted = false },
            new Account { AccountId = ACCOUNT_PROCURE, RoleId = ROLE_PROCURE, Email = "procure@test.com", Password = "DUMMY_PASSWORD_NOT_USED_YET", CreatedAt = Seeded, IsDeleted = false },
            new Account { AccountId = ACCOUNT_GM, RoleId = ROLE_GM, Email = "gm@test.com", Password = "DUMMY_PASSWORD_NOT_USED_YET", CreatedAt = Seeded, IsDeleted = false },
            new Account { AccountId = ACCOUNT_ADMIN, RoleId = ROLE_ADMIN, Email = "superadmin@maser.com", Password = "$2a$11$REPLACE_WITH_BCRYPT_HASH", CreatedAt = Seeded, IsDeleted = false }
        );

        modelBuilder.Entity<UserDetail>().HasData(
            new UserDetail { UserId = "USER_REQUESTER", AccountId = ACCOUNT_REQUESTER, FullName = "Test Requester", Phone = "081234567890", CreatedAt = Seeded },
            new UserDetail { UserId = "USER_PROCURE", AccountId = ACCOUNT_PROCURE, FullName = "Test Procure", Phone = "081234567891", CreatedAt = Seeded },
            new UserDetail { UserId = "USER_GM", AccountId = ACCOUNT_GM, FullName = "Test GM", Phone = "081234567892", CreatedAt = Seeded },
            new UserDetail { UserId = "USER_ADMIN", AccountId = ACCOUNT_ADMIN, FullName = "Super Admin", Phone = "081234567893", CreatedAt = Seeded }
        );
    }

    private static void SeedMasterSamples(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Uom>().HasData(new Uom { UomId = UOM_PCS, UomCode = "PCS", UomName = "Pieces", CreatedAt = Seeded, IsDeleted = false });
        modelBuilder.Entity<Material>().HasData(new Material { MaterialId = MAT_CEMENT, UomId = UOM_PCS, MaterialCode = "MAT001", MaterialName = "Cement", Description = "Cement for construction work", CreatedAt = Seeded });
        modelBuilder.Entity<Vendor>().HasData(new Vendor { VendorId = VENDOR_TEST, VendorCode = "VND001", VendorName = "PT Test Vendor", CreatedAt = Seeded, IsDeleted = false });
        modelBuilder.Entity<Company>().HasData(new Company { CompanyId = COMPANY_TEST, CompanyCode = "CMP001", CompanyName = "PT Test Company", CreatedAt = Seeded, IsDeleted = false });
        modelBuilder.Entity<Tax>().HasData(new Tax { TaxId = TAX_PPN11, TaxCode = "PPN11", TaxName = "PPN 11%", TaxRate = 0.11m, TaxDescription = "Value added tax 11%", CreatedAt = Seeded });
    }
}
