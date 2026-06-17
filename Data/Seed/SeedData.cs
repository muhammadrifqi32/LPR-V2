using Microsoft.EntityFrameworkCore;
using PurchaseRequestSystem.Models;

namespace PurchaseRequestSystem.Data.Seed;

/// <summary>
/// Seed data adjusted to the latest ERD documentation.
/// Master IDs are stable 26-character ULID strings for deterministic migrations.
/// Runtime transaction IDs are generated with UlidHelper.NewUlid().
/// </summary>
public static class SeedData
{
    private static readonly DateTime Seeded = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    // ROLES
    public const string ROLE_REQUESTER = "01KV9YAJTH0SKHS01HFYHV2YCX";
    public const string ROLE_PROCURE = "01KV9YAJTJ7TRMCT2JAYYXCG7V";
    public const string ROLE_GM = "01KV9YAJTKQJ4J7E61X4WJ8NPY";
    public const string ROLE_CHAIRMAN = "01KV9YAJTMQPEATF1DDMD3T7X7";
    public const string ROLE_PROJECT_ADMIN = "01KV9YAJTN2S0RQ7946KJ6BRAG";
    public const string ROLE_ADMIN = "01KV9YAJTP10H6R0RHK6BJN139";

    // ACCOUNTS
    public const string ACCOUNT_REQUESTER = "01KV9YAJTQ6ZW1FZ39B83T1JKE";
    public const string ACCOUNT_PROCURE = "01KV9YAJTRK8ER2QQPT4XRZAGR";
    public const string ACCOUNT_GM = "01KV9YAJTS6BKRZBE1MR3CP3XK";
    public const string ACCOUNT_ADMIN = "01KV9YAJTTPE5ACQPKH6VMT3XH";

    // USER DETAILS
    public const string USER_REQUESTER = "01KV9YAJTV71Q6PSD6MJ5R2J7P";
    public const string USER_PROCURE = "01KV9YAJTW8WVSDPGXNHSFYQ9A";
    public const string USER_GM = "01KV9YAJTX06MXX2KQ9F7KDNCB";
    public const string USER_ADMIN = "01KV9YAJTY53FWWJHBQQ142CRB";

    // REQUEST TYPES
    public const string REQ_PROJECT = "01KV9YAJTZAWD6RC3N26SBJGVT";
    public const string REQ_NON_PROJECT = "01KV9YAJV06WF2FKC1613J54W9";

    // APPROVAL STAGES
    public const string STAGE_PROCURE = "01KV9YAJV1ARNW6X2SXVTGQTK3";
    public const string STAGE_GM = "01KV9YAJV2C511FFHH24D2MWZD";
    public const string STAGE_CHAIRMAN = "01KV9YAJV3V3TNQSGJHRCC4SWQ";

    // MODULE TYPES
    public const string MODULE_PROPOSAL = "01KV9YAJV48EVSN3EA0DC0TYVH";
    public const string MODULE_PROCUREMENT_REQUEST = "01KV9YAJV5QB7GP7WHCF79ZXBZ";
    public const string MODULE_PURCHASE_REQUEST = "01KV9YAJV63ZT8JHHYGNTSSQK6";
    public const string MODULE_PURCHASE_ORDER = "01KV9YAJV7C3KYR6WCM7WHW7AC";
    public const string MODULE_GOODS_RECEIPT = "01KV9YAJV89C6RTMM8Y4A2RFZ8";
    public const string MODULE_INVOICE = "01KV9YAJV9KSBT1VM9NVA57Q9J";
    public const string MODULE_PAYMENT = "01KV9YAJVABJADS66JR7HASXSF";

    // STATUS
    public const string STATUS_DRAFT = "01KV9YAJVBPHF32EEK5J9WTPDZ";
    public const string STATUS_PENDING = "01KV9YAJVCN540QES5K48WWQEJ";
    public const string STATUS_SUBMITTED = "01KV9YAJVD98AWBSYEH8X5F2ME";
    public const string STATUS_UNDER_REVIEW = "01KV9YAJVEVBV18V9Z67Y3EYJC";
    public const string STATUS_APPROVED = "01KV9YAJVF37DXVMEZP8XSGBQR";
    public const string STATUS_REJECTED = "01KV9YAJVGEG94EAA775GMZWYQ";
    public const string STATUS_REVISION_REQUIRED = "01KV9YAJVHBNJXB222VTHBRDSF";
    public const string STATUS_PARTIALLY_APPROVED = "01KV9YAJVJBBSNXH1E10MT7CQ9";
    public const string STATUS_PO_OPEN = "01KV9YAJVK8HCAQ44SMGTT4G5E";
    public const string STATUS_PARTIALLY_RECEIVED = "01KV9YAJVMNVYEZJ4R96STMZQY";
    public const string STATUS_FULLY_RECEIVED = "01KV9YAJVNKFR14HVFAYJYB9DB";
    public const string STATUS_UNPAID = "01KV9YAJVPH2YJQKXY06H8VVZ3";
    public const string STATUS_PARTIALLY_PAID = "01KV9YAJVQ57A3XAZDSEXAG3EM";
    public const string STATUS_PAID = "01KV9YAJVR8MDP28ZXYXV5DBVJ";
    public const string STATUS_PENDING_GM = "01KV9YAJVSMFBYSSKFMBYN2SQ6";
    public const string STATUS_GM_APPROVED = "01KV9YAJVT70W8X52276R2PRE4";
    public const string STATUS_PENDING_CHAIRMAN = "01KV9YAJVVTZ2N611HFYQM5R9F";
    public const string STATUS_CHAIRMAN_APPROVED = "01KV9YAJVW1S8WD9ZE772B0CPC";

    // MASTER SAMPLE DATA — all values are true 26-character ULID strings
    public const string UOM_KG = "01KV9ZC1WJSEG74KJFNCSTJSWH";
    public const string UOM_M = "01KV9ZC1WJG7GBH690RX0RH67R";
    public const string UOM_M2 = "01KV9ZC1WJ8BX6Q99MZS5TNDH7";
    public const string UOM_M3 = "01KV9ZC1WJM34T07T1YC4E9VAY";
    public const string UOM_PCS = "01KV9ZC1WJGCN3SJFCEBTS0ERE";
    public const string UOM_LTR = "01KV9ZC1WJV001FZH68FTT3AET";
    public const string UOM_TON = "01KV9ZC1WJFDW7J64746TB6J27";

    public const string MAT_CEMENT_PORTLAND = "01KV9ZC1WJWP04EDTX8C1H76E1";
    public const string MAT_CONCRETE_PILLAR = "01KV9ZC1WJEW363D09Z8A62NTW";
    public const string MAT_STEEL_BAR = "01KV9ZC1WJDZES734T9MPBZJZG";
    // Backward-readable alias for earlier docs/tests. Value remains true ULID.
    public const string MAT_CEMENT = MAT_CEMENT_PORTLAND;

    public const string VENDOR_TEST = "01KV9ZC1WJ0S5HY3S3AK6AS9X4";
    public const string COMPANY_TEST = "01KV9ZC1WJ31VKTX0HVDE9PAPA";
    public const string TAX_PPN11 = "01KV9ZC1WJNT4BXQDTMZJ6KS59";

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
            new RequestType { RequestTypeId = REQ_PROJECT, RequestTypeCode = "PROJECT", RequestTypeName = "Project Request", Description = "Requires prior Proposal approval before PR is created", CreatedAt = Seeded },
            new RequestType { RequestTypeId = REQ_NON_PROJECT, RequestTypeCode = "NON_PROJECT", RequestTypeName = "Non-Project Request", Description = "No Proposal needed; Procurement Request created directly", CreatedAt = Seeded }
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
            new Status { StatusId = STATUS_PO_OPEN, StatusName = "OPEN", CreatedAt = Seeded },
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


    private static readonly Dictionary<(string ModuleId, string StatusId), string> StatusDetailIds = new()
    {
        [(MODULE_PROPOSAL, STATUS_DRAFT)] = "01KV9YAW9NB9KNKKMCZP70KCJC",
        [(MODULE_PROPOSAL, STATUS_PENDING)] = "01KV9YAW9PCY3FQAFJ20VKQWH1",
        [(MODULE_PROPOSAL, STATUS_SUBMITTED)] = "01KV9YAW9QH6K4GG7D48AG5PDB",
        [(MODULE_PROPOSAL, STATUS_UNDER_REVIEW)] = "01KV9YAW9RDDRNENFHDT4SG791",
        [(MODULE_PROPOSAL, STATUS_APPROVED)] = "01KV9YAW9SYPAKY3TECN08V6MW",
        [(MODULE_PROPOSAL, STATUS_REJECTED)] = "01KV9YAW9THV9N93VG2Z64VEBQ",
        [(MODULE_PROPOSAL, STATUS_REVISION_REQUIRED)] = "01KV9YAW9VW7DKTA6ZH35VZ170",
        [(MODULE_PROPOSAL, STATUS_PARTIALLY_APPROVED)] = "01KV9YAW9WATY1FB9TMDPVCX1A",
        [(MODULE_PROCUREMENT_REQUEST, STATUS_DRAFT)] = "01KV9YAW9X88QD863P1W6B5Q5R",
        [(MODULE_PROCUREMENT_REQUEST, STATUS_SUBMITTED)] = "01KV9YAW9YS0R65MPEXF1KQ71J",
        [(MODULE_PROCUREMENT_REQUEST, STATUS_PENDING)] = "01KV9YAW9ZWVV9JSYBBHXKF8GR",
        [(MODULE_PROCUREMENT_REQUEST, STATUS_APPROVED)] = "01KV9YAWA0RPDFH7Y33F2W2DTV",
        [(MODULE_PROCUREMENT_REQUEST, STATUS_REJECTED)] = "01KV9YAWA1EKVAACEJ8S0KE14Y",
        [(MODULE_PROCUREMENT_REQUEST, STATUS_REVISION_REQUIRED)] = "01KV9YAWA2H2KQPEQEK0XNSGQN",
        [(MODULE_PURCHASE_REQUEST, STATUS_DRAFT)] = "01KV9YAWA314XMC956Z7VBRTYG",
        [(MODULE_PURCHASE_REQUEST, STATUS_SUBMITTED)] = "01KV9YAWA4CWAJTDW78D56EERV",
        [(MODULE_PURCHASE_REQUEST, STATUS_PENDING_GM)] = "01KV9YAWA5MXFVMZNXHM91T511",
        [(MODULE_PURCHASE_REQUEST, STATUS_GM_APPROVED)] = "01KV9YAWA645YZKZ726WDMA8Y0",
        [(MODULE_PURCHASE_REQUEST, STATUS_PENDING_CHAIRMAN)] = "01KV9YAWA7ZSGDFBVJV82NWM7D",
        [(MODULE_PURCHASE_REQUEST, STATUS_CHAIRMAN_APPROVED)] = "01KV9YAWA845T4DF6PGW6MH9J7",
        [(MODULE_PURCHASE_REQUEST, STATUS_APPROVED)] = "01KV9YAWA9XD1PYW4PWJMH83DV",
        [(MODULE_PURCHASE_REQUEST, STATUS_REJECTED)] = "01KV9YAWAAAWEJEEJVCK5SNTZX",
        [(MODULE_PURCHASE_REQUEST, STATUS_REVISION_REQUIRED)] = "01KV9YAWAB7QV1H0PSR401ASMY",
        [(MODULE_PURCHASE_ORDER, STATUS_PO_OPEN)] = "01KV9YAWACKS85SJEWR5GBM8P8",
        [(MODULE_PURCHASE_ORDER, STATUS_PARTIALLY_RECEIVED)] = "01KV9YAWADBNVEYGABVNWFCW5S",
        [(MODULE_PURCHASE_ORDER, STATUS_FULLY_RECEIVED)] = "01KV9YAWAEX3RQ7RB4XKMEPNZT",
        [(MODULE_GOODS_RECEIPT, STATUS_PENDING)] = "01KV9YAWAFBRNP231AJC8KXXKR",
        [(MODULE_GOODS_RECEIPT, STATUS_PARTIALLY_RECEIVED)] = "01KV9YAWAGK5Y8PVV0MPB3S86T",
        [(MODULE_GOODS_RECEIPT, STATUS_FULLY_RECEIVED)] = "01KV9YAWAH241MTJV0SBRVSTJX",
        [(MODULE_GOODS_RECEIPT, STATUS_APPROVED)] = "01KV9YAWAJV6V0M7JTD0MSDSRH",
        [(MODULE_GOODS_RECEIPT, STATUS_REJECTED)] = "01KV9YAWAKT06G0N5T0FYQMQCS",
        [(MODULE_INVOICE, STATUS_UNPAID)] = "01KV9YAWAMBNJBZS5K7CK93Q4B",
        [(MODULE_INVOICE, STATUS_PARTIALLY_PAID)] = "01KV9YAWANZW6526JRCKSGBW89",
        [(MODULE_INVOICE, STATUS_PAID)] = "01KV9YAWAPQFR7VKJ6XTMM2X6D",
        [(MODULE_PAYMENT, STATUS_PENDING)] = "01KV9YAWAQ2PRCFS91EJ690VTH",
        [(MODULE_PAYMENT, STATUS_APPROVED)] = "01KV9YAWART12V7JA9F4ME18RC",
        [(MODULE_PAYMENT, STATUS_REJECTED)] = "01KV9YAWASJZMC0FMW5G31YYVD"
    };

    private static void SeedStatusDetails(ModelBuilder modelBuilder)
    {
        var data = new List<StatusDetail>();
        void Add(string moduleId, params string[] statuses)
        {
            foreach (var statusId in statuses)
            {
                data.Add(new StatusDetail
                {
                    StatusDetailId = StatusDetailIds[(moduleId, statusId)],
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
            new UserDetail { UserId = USER_REQUESTER, AccountId = ACCOUNT_REQUESTER, FullName = "Test Requester", Phone = "081234567890", CreatedAt = Seeded },
            new UserDetail { UserId = USER_PROCURE, AccountId = ACCOUNT_PROCURE, FullName = "Test Procure", Phone = "081234567891", CreatedAt = Seeded },
            new UserDetail { UserId = USER_GM, AccountId = ACCOUNT_GM, FullName = "Test GM", Phone = "081234567892", CreatedAt = Seeded },
            new UserDetail { UserId = USER_ADMIN, AccountId = ACCOUNT_ADMIN, FullName = "Super Admin", Phone = "081234567893", CreatedAt = Seeded }
        );
    }

    private static void SeedMasterSamples(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Uom>().HasData(
            new Uom { UomId = UOM_KG, UomCode = "kg", UomName = "Kilogram", CreatedAt = Seeded, IsDeleted = false },
            new Uom { UomId = UOM_M, UomCode = "m", UomName = "Meter", CreatedAt = Seeded, IsDeleted = false },
            new Uom { UomId = UOM_M2, UomCode = "m2", UomName = "Square Meter", CreatedAt = Seeded, IsDeleted = false },
            new Uom { UomId = UOM_M3, UomCode = "m3", UomName = "Cubic Meter", CreatedAt = Seeded, IsDeleted = false },
            new Uom { UomId = UOM_PCS, UomCode = "pcs", UomName = "Pieces", CreatedAt = Seeded, IsDeleted = false },
            new Uom { UomId = UOM_LTR, UomCode = "ltr", UomName = "Liter", CreatedAt = Seeded, IsDeleted = false },
            new Uom { UomId = UOM_TON, UomCode = "ton", UomName = "Ton", CreatedAt = Seeded, IsDeleted = false }
        );

        modelBuilder.Entity<Material>().HasData(
            new Material
            {
                MaterialId = MAT_CEMENT_PORTLAND,
                UomId = UOM_KG,
                MaterialCode = "MAT-CEM-001",
                MaterialName = "Cement Portland",
                Description = "Standard grade Portland cement, 50kg bag",
                CreatedAt = Seeded
            },
            new Material
            {
                MaterialId = MAT_CONCRETE_PILLAR,
                UomId = UOM_PCS,
                MaterialCode = "MAT-PLR-001",
                MaterialName = "Concrete Pillar",
                Description = "Pre-cast concrete pillar, 3m length",
                CreatedAt = Seeded
            },
            new Material
            {
                MaterialId = MAT_STEEL_BAR,
                UomId = UOM_KG,
                MaterialCode = "MAT-STL-001",
                MaterialName = "Steel Bar",
                Description = "Deformed steel bar, 12mm diameter",
                CreatedAt = Seeded
            }
        );

        modelBuilder.Entity<Vendor>().HasData(new Vendor
        {
            VendorId = VENDOR_TEST,
            VendorCode = "VND-CEMENT-01",
            VendorName = "CV Sumber Material Bangunan",
            CreatedAt = Seeded,
            CreatedBy = ACCOUNT_ADMIN,
            IsDeleted = false
        });

        modelBuilder.Entity<Company>().HasData(new Company
        {
            CompanyId = COMPANY_TEST,
            CompanyCode = "PT-ABC",
            CompanyName = "PT ABC Construction Indonesia",
            CreatedAt = Seeded,
            CreatedBy = ACCOUNT_ADMIN,
            IsDeleted = false
        });

        modelBuilder.Entity<Tax>().HasData(new Tax
        {
            TaxId = TAX_PPN11,
            TaxCode = "PPN11",
            TaxName = "PPN 11%",
            TaxRate = 0.11m,
            TaxDescription = "Value added tax 11%",
            CreatedAt = Seeded
        });
    }
}
