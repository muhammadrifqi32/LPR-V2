using Microsoft.EntityFrameworkCore;
using PurchaseRequestSystem.Data.Seed;
using PurchaseRequestSystem.Models;

namespace PurchaseRequestSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Master + RBAC
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<Tax> Taxes => Set<Tax>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<UserDetail> UserDetails => Set<UserDetail>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<RequestType> RequestTypes => Set<RequestType>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<ModuleType> ModuleTypes => Set<ModuleType>();
    public DbSet<StatusDetail> StatusDetails => Set<StatusDetail>();
    public DbSet<ApprovalStage> ApprovalStages => Set<ApprovalStage>();
    public DbSet<Uom> Uoms => Set<Uom>();
    public DbSet<Material> Materials => Set<Material>();

    // Transaction
    public DbSet<Proposal> Proposals => Set<Proposal>();
    public DbSet<ProposalDetail> ProposalDetails => Set<ProposalDetail>();
    public DbSet<ProcurementRequest> ProcurementRequests => Set<ProcurementRequest>();
    public DbSet<PurchaseRequest> PurchaseRequests => Set<PurchaseRequest>();
    public DbSet<PurchaseRequestDetail> PurchaseRequestDetails => Set<PurchaseRequestDetail>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderDetail> PurchaseOrderDetails => Set<PurchaseOrderDetail>();
    public DbSet<GoodsReceipt> GoodsReceipts => Set<GoodsReceipt>();
    public DbSet<GoodsReceiptDetail> GoodsReceiptDetails => Set<GoodsReceiptDetail>();
    public DbSet<PurchaseOrderPayment> PurchaseOrderPayments => Set<PurchaseOrderPayment>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<ApprovalRecord> ApprovalRecords => Set<ApprovalRecord>();
    public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 4);
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        ConfigureMaster(b);
        ConfigureRbac(b);
        ConfigureProposal(b);
        ConfigureRequests(b);
        ConfigurePurchaseOrder(b);
        ConfigureGoodsReceipt(b);
        ConfigurePayment(b);
        ConfigureInvoiceAndPaymentV2(b);
        ConfigureApprovalAndAudit(b);
        ConfigureAccountAuditForeignKeys(b);
        ConfigureUlidColumns(b);

        SeedData.Apply(b);

        foreach (var fk in b.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }


    private static void ConfigureUlidColumns(ModelBuilder b)
    {
        foreach (var entityType in b.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType != typeof(string))
                    continue;

                var isUlidColumn = property.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase)
                    || property.Name is "CreatedBy" or "UpdatedBy";

                if (!isUlidColumn)
                    continue;

                b.Entity(entityType.ClrType)
                    .Property(property.Name)
                    .HasMaxLength(26)
                    .IsUnicode(false);
            }
        }
    }

    private static void ConfigureMaster(ModelBuilder b)
    {
        b.Entity<Company>().HasIndex(x => x.CompanyCode).IsUnique();
        b.Entity<Vendor>().HasIndex(x => x.VendorCode).IsUnique();
        b.Entity<Tax>(e =>
        {
            e.HasIndex(x => x.TaxCode).IsUnique();
            e.Property(x => x.TaxRate).HasPrecision(9, 4);
        });

        b.Entity<RequestType>().HasIndex(x => x.RequestTypeCode).IsUnique();
        b.Entity<ModuleType>().HasIndex(x => x.ModuleTypeCode).IsUnique();
        b.Entity<Uom>().HasIndex(x => x.UomCode).IsUnique();

        b.Entity<StatusDetail>(e =>
        {
            e.HasIndex(x => new { x.ModuleTypeId, x.StatusId }).IsUnique();
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
            e.HasOne(x => x.ModuleType).WithMany(x => x.StatusDetails).HasForeignKey(x => x.ModuleTypeId);
        });

        b.Entity<Material>(e =>
        {
            e.HasIndex(x => x.MaterialCode).IsUnique();
            e.HasOne(x => x.Uom).WithMany(u => u.Materials).HasForeignKey(x => x.UomId);
        });
    }

    private static void ConfigureRbac(ModelBuilder b)
    {
        b.Entity<Role>().HasIndex(x => x.RoleCode).IsUnique();

        b.Entity<Account>(e =>
        {
            e.HasIndex(x => x.Email).IsUnique();
            e.HasOne(x => x.Role).WithMany(r => r.Accounts).HasForeignKey(x => x.RoleId);
        });

        b.Entity<UserDetail>(e =>
        {
            e.HasIndex(x => x.AccountId).IsUnique();
            e.HasOne(x => x.Account).WithOne(a => a.UserDetail).HasForeignKey<UserDetail>(x => x.AccountId);
        });

        b.Entity<RefreshToken>(e =>
        {
            e.HasIndex(x => x.TokenHash).IsUnique();
            e.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId);
        });
    }

    private static void ConfigureProposal(ModelBuilder b)
    {
        b.Entity<Proposal>(e =>
        {
            e.HasIndex(x => x.ProposalNo).IsUnique();
            e.Property(x => x.ProposalDate).HasColumnType("date");
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
        });

        b.Entity<ProposalDetail>(e =>
        {
            e.HasOne(x => x.Proposal).WithMany(p => p.Details).HasForeignKey(x => x.ProposalId);
            e.HasOne(x => x.Material).WithMany().HasForeignKey(x => x.MaterialId);
            e.HasOne(x => x.Uom).WithMany().HasForeignKey(x => x.UomId);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired(false);
        });
    }

    private static void ConfigureRequests(ModelBuilder b)
    {
        b.Entity<ProcurementRequest>(e =>
        {
            e.HasIndex(x => x.ProcurementRequestNo).IsUnique();
            e.Property(x => x.RequestDate).HasColumnType("date");
            e.HasOne(x => x.RequestType).WithMany(rt => rt.ProcurementRequests).HasForeignKey(x => x.RequestTypeId);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
            e.HasOne(x => x.Proposal).WithMany(p => p.ProcurementRequests).HasForeignKey(x => x.ProposalId).IsRequired(false);
        });

        b.Entity<PurchaseRequest>(e =>
        {
            e.HasIndex(x => x.PurchaseRequestNo).IsUnique().HasFilter("[PurchaseRequestNo] IS NOT NULL");
            e.HasIndex(x => x.ProcurementRequestId).IsUnique();
            e.HasOne(x => x.ProcurementRequest).WithOne(pr => pr.PurchaseRequest).HasForeignKey<PurchaseRequest>(x => x.ProcurementRequestId);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
        });

        b.Entity<PurchaseRequestDetail>(e =>
        {
            e.HasOne(x => x.PurchaseRequest).WithMany(pr => pr.Details).HasForeignKey(x => x.PurchaseRequestId);
            e.HasOne(x => x.ProposalDetail).WithMany().HasForeignKey(x => x.ProposalDetailId).IsRequired(false);
            e.HasOne(x => x.Material).WithMany().HasForeignKey(x => x.MaterialId);
            e.HasOne(x => x.Uom).WithMany().HasForeignKey(x => x.UomId);
        });
    }

    private static void ConfigurePurchaseOrder(ModelBuilder b)
    {
        b.Entity<PurchaseOrder>(e =>
        {
            e.HasIndex(x => x.PurchaseOrderNo).IsUnique();
            e.HasIndex(x => x.PurchaseRequestId); // ERD v2: one PR can generate multiple POs
            e.Property(x => x.PoDate).HasColumnType("date");
            e.Property(x => x.SubtotalAmount).HasPrecision(18, 2);
            e.Property(x => x.TaxRate).HasPrecision(9, 4);
            e.Property(x => x.TaxAmount).HasPrecision(18, 2);
            e.Property(x => x.GrandtotalAmount).HasPrecision(18, 2);
            e.HasOne(x => x.PurchaseRequest).WithMany(pr => pr.PurchaseOrders).HasForeignKey(x => x.PurchaseRequestId);
            e.HasOne(x => x.Vendor).WithMany(v => v.PurchaseOrders).HasForeignKey(x => x.VendorId).IsRequired(false);
            e.HasOne(x => x.Company).WithMany(c => c.PurchaseOrders).HasForeignKey(x => x.CompanyId).IsRequired(false);
            e.HasOne(x => x.Tax).WithMany(t => t.PurchaseOrders).HasForeignKey(x => x.TaxId).IsRequired(false);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
        });

        b.Entity<PurchaseOrderDetail>(e =>
        {
            e.Property(x => x.UnitPrice).HasPrecision(18, 2);
            e.Property(x => x.SubtotalAmount).HasPrecision(18, 2);
            e.HasOne(x => x.PurchaseOrder).WithMany(po => po.Details).HasForeignKey(x => x.PurchaseOrderId);
            e.HasOne(x => x.PurchaseRequestDetail).WithMany().HasForeignKey(x => x.PurchaseRequestDetailId).IsRequired(false);
            e.HasOne(x => x.Material).WithMany().HasForeignKey(x => x.MaterialId);
            e.HasOne(x => x.Uom).WithMany().HasForeignKey(x => x.UomId);
        });
    }

    private static void ConfigureGoodsReceipt(ModelBuilder b)
    {
        b.Entity<GoodsReceipt>(e =>
        {
            e.HasIndex(x => x.GoodsReceiptNo).IsUnique();
            e.Property(x => x.ReceivedDate).HasColumnType("date");
            e.HasOne(x => x.PurchaseOrder).WithMany(po => po.GoodsReceipts).HasForeignKey(x => x.PurchaseOrderId);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
        });

        b.Entity<GoodsReceiptDetail>(e =>
        {
            e.Property(x => x.DiscrepancyType).HasConversion<string>().HasMaxLength(20);
            e.HasOne(x => x.GoodsReceipt).WithMany(gr => gr.Details).HasForeignKey(x => x.GoodsReceiptId);
            e.HasOne(x => x.PurchaseOrderDetail).WithMany(pod => pod.GoodsReceiptDetails).HasForeignKey(x => x.PurchaseOrderDetailId);
            e.HasOne(x => x.Material).WithMany().HasForeignKey(x => x.MaterialId);
            e.HasOne(x => x.Uom).WithMany().HasForeignKey(x => x.UomId);
        });
    }

    private static void ConfigurePayment(ModelBuilder b)
    {
        b.Entity<PurchaseOrderPayment>(e =>
        {
            e.Property(x => x.PaidAmount).HasPrecision(18, 2);
            e.Property(x => x.InvoiceDate).HasColumnType("date");
            e.Property(x => x.DueDate).HasColumnType("date");
            e.Property(x => x.PaymentDate).HasColumnType("date");
            e.HasOne(x => x.PurchaseOrder).WithMany(po => po.Payments).HasForeignKey(x => x.PurchaseOrderId);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
            e.HasOne(x => x.GoodsReceipt).WithMany(gr => gr.Payments).HasForeignKey(x => x.GoodsReceiptId).IsRequired(false);
        });
    }

    private static void ConfigureInvoiceAndPaymentV2(ModelBuilder b)
    {
        b.Entity<Invoice>(e =>
        {
            e.HasIndex(x => x.InvoiceNo).IsUnique();
            e.HasIndex(x => x.GoodsReceiptId).IsUnique();
            e.Property(x => x.InvoiceDate).HasColumnType("date");
            e.Property(x => x.DueDate).HasColumnType("date");
            e.Property(x => x.SubtotalAmount).HasPrecision(18, 2);
            e.Property(x => x.TaxAmount).HasPrecision(18, 2);
            e.Property(x => x.TotalAmount).HasPrecision(18, 2);
            e.HasOne(x => x.PurchaseOrder).WithMany().HasForeignKey(x => x.PurchaseOrderId);
            e.HasOne(x => x.GoodsReceipt).WithOne().HasForeignKey<Invoice>(x => x.GoodsReceiptId);
            e.HasOne(x => x.StatusDetail).WithMany().HasForeignKey(x => x.StatusDetailId);
        });

        b.Entity<Payment>(e =>
        {
            e.Property(x => x.PaymentDate).HasColumnType("date");
            e.Property(x => x.PaidAmount).HasPrecision(18, 2);
            e.HasOne(x => x.Invoice).WithMany(x => x.Payments).HasForeignKey(x => x.InvoiceId);
            e.HasOne(x => x.StatusDetail).WithMany().HasForeignKey(x => x.StatusDetailId);
        });
    }

    private static void ConfigureApprovalAndAudit(ModelBuilder b)
    {
        b.Entity<ApprovalRecord>(e =>
        {
            e.HasIndex(x => new { x.ProcurementRequestId, x.ApprovalStageId }).IsUnique();
            e.HasOne(x => x.ProcurementRequest).WithMany(pr => pr.ApprovalRecords).HasForeignKey(x => x.ProcurementRequestId);
            e.HasOne(x => x.ApprovalStage).WithMany(s => s.ApprovalRecords).HasForeignKey(x => x.ApprovalStageId);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
        });

        b.Entity<ActivityLog>(e =>
        {
            e.Property(x => x.DocumentType).HasConversion<string>().HasMaxLength(40);
            e.HasIndex(x => new { x.DocumentType, x.DocumentId });
            e.HasOne<Account>().WithMany().HasForeignKey(x => x.AccountId);
        });
    }

    private static void ConfigureAccountAuditForeignKeys(ModelBuilder b)
    {
        b.Entity<Company>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<Vendor>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<Account>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<Account>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<Proposal>().HasOne<Account>().WithMany().HasForeignKey(x => x.RequesterId);
        b.Entity<Proposal>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<Proposal>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<ProcurementRequest>().HasOne<Account>().WithMany().HasForeignKey(x => x.RequesterId);
        b.Entity<ProcurementRequest>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<ProcurementRequest>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<PurchaseRequest>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<PurchaseRequest>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<PurchaseRequestDetail>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<PurchaseRequestDetail>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<PurchaseOrder>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<PurchaseOrder>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<GoodsReceipt>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<GoodsReceiptDetail>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<GoodsReceiptDetail>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<PurchaseOrderPayment>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<PurchaseOrderPayment>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
        b.Entity<ApprovalRecord>().HasOne<Account>().WithMany().HasForeignKey(x => x.CreatedBy).IsRequired(false);
        b.Entity<ApprovalRecord>().HasOne<Account>().WithMany().HasForeignKey(x => x.UpdatedBy).IsRequired(false);
    }
}
