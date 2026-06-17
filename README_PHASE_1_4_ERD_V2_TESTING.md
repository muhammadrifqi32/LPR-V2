# Purchase Request System — ERD V2 / ULID Baseline Testing Guide

This project version is a breaking schema baseline aligned with the latest ERD references and seed data direction.

## What Changed

### ID Strategy

- Runtime transaction IDs are now generated as ULID string values through `UlidHelper.NewUlid()`.
- DTO route/body IDs are string-based instead of `Guid`.
- Seed IDs are deterministic string IDs to keep EF Core `HasData()` stable.

### New Master Tables Added

- `tbl_module_type`
- `tbl_status_detail`
- `tbl_tax`
- `tbl_refresh_token`

### New Future Transaction Tables Added

- `tbl_invoice`
- `tbl_payment`

`tbl_purchase_order_payment` is still kept for backward compatibility with the previous code, but the ERD V2 direction is invoice/payment split.

### Purchase Order Adjustment

The ERD V2 direction allows one Purchase Request to generate multiple Purchase Orders. This means:

- `purchase_request_id` is no longer unique in `tbl_purchase_order`.
- PO lines now include `purchase_request_detail_id`.
- `orderQuantity` is supported in generate/update PO DTOs.
- Duplicate PO blocking has been replaced by per-line quantity validation.

## Important Migration Recommendation

Because this version changes IDs from GUID to string/ULID-style IDs, do not apply this as a small patch over an existing test database unless you are ready to manually migrate old data.

Recommended local reset flow:

```bash
dotnet restore
dotnet build
```

Then drop the old test database or create a new database name in the existing connection string.

Create a fresh migration:

```bash
dotnet ef migrations add InitialCreate_ErdV2_Ulid
dotnet ef database update
dotnet run
```

## Seed Data Included

### Roles

- REQUESTER
- PROCURE
- GM
- CHAIRMAN
- PROJECT_ADMIN
- ADMIN

### Accounts

Use these IDs for Swagger testing:

```text
Requester: ACCOUNT_REQUESTER
Procure:   ACCOUNT_PROCURE
GM:        ACCOUNT_GM
Admin:     ACCOUNT_SUPER_ADMIN
```

### Request Types

```text
REQ_PROJECT
REQ_NON_PROJECT
```

### Approval Stages

```text
STAGE_PROCURE
STAGE_GM
STAGE_CHAIRMAN
```

### Sample Master Data

```text
UoM:      UOM_PCS
Material: MAT_CEMENT
Vendor:   VENDOR_TEST
Company:  COMPANY_TEST
Tax:      TAX_PPN11
```

## API Test Flow Summary

### Phase 1 — Master Data CRUD

Test:

```text
GET /api/companies
GET /api/vendors
GET /api/uoms
GET /api/materials
GET /api/statuses
GET /api/request-types
GET /api/roles
```

Expected: `200 OK` with `ApiResponse<T>`.

Create/update/delete still follows the same pattern, but IDs are now string values.

### Phase 2 — Proposal, Procurement Request, Purchase Request

Project flow:

1. `POST /api/proposals`
2. `POST /api/proposals/{proposalId}/submit`
3. `POST /api/proposals/{proposalId}/review`
4. `POST /api/procurement-requests/project`

Non-project flow:

1. `POST /api/procurement-requests/non-project`

Use seeded requester:

```json
{
  "requesterId": "ACCOUNT_REQUESTER"
}
```

Use seeded material/uom:

```json
{
  "materialId": "MAT_CEMENT",
  "uomId": "UOM_PCS"
}
```

### Phase 3 — GM and Chairman Approval

Submit PR:

```json
{
  "submittedBy": "ACCOUNT_REQUESTER",
  "notes": "Submit PR to GM"
}
```

GM approve:

```json
{
  "actionBy": "ACCOUNT_GM",
  "notes": "Approved by GM"
}
```

Chairman approval recorded by GM:

```json
{
  "recordedBy": "ACCOUNT_GM",
  "notes": "Chairman approved offline"
}
```

### Phase 4 — Purchase Order

Generate PO from approved PR:

```json
{
  "vendorId": "VENDOR_TEST",
  "companyId": "COMPANY_TEST",
  "poDate": "2026-06-15",
  "taxRate": 0.11,
  "notes": "PO generated from approved PR",
  "purchaseOrderAttachmentPath": "optional/path/po.pdf",
  "createdBy": "ACCOUNT_REQUESTER",
  "details": [
    {
      "purchaseRequestDetailId": "replace-with-purchase-request-detail-id",
      "orderQuantity": 10,
      "unitPrice": 15000,
      "notes": "Unit price for material"
    }
  ]
}
```

Important: since ERD V2 allows one PR to have many POs, PO generation now validates total ordered quantity per `purchaseRequestDetailId`, not only duplicate PO by `purchaseRequestId`.

## Type Data Recommendation

Recommended SQL Server types:

| Logical Data | Recommended Type |
|---|---|
| ULID ID | `varchar(26)` or `nvarchar(26)` |
| Code | `varchar(50)` |
| Name | `nvarchar(150)` |
| Description / notes | `nvarchar(500)` or `nvarchar(max)` if long |
| Date only | `date` |
| Timestamp | `datetime2(7)` |
| Quantity | `decimal(18,4)` |
| Unit price / amount | `decimal(18,2)` |
| Tax rate | `decimal(9,4)` |
| Boolean | `bit` |
| Email | `nvarchar(256)` |
| Password hash / token hash | `nvarchar(500)` |
| Attachment path | `nvarchar(500)` |

## Known Compatibility Notes

- Existing APIs still expose some response names like `statusId` for compatibility, but new seed/schema also includes `tbl_status_detail` for module-based status mapping.
- Existing `tbl_purchase_order_payment` is kept to prevent old code from breaking, while ERD V2 adds `tbl_invoice` and `tbl_payment` for the new direction.
- For clean testing, use a fresh database because GUID-to-ULID/string ID change is a breaking change.
