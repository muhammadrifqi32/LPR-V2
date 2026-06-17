# Purchase Request System — ERD V2 + ULID Testing Guide

This README is the consolidated guide for testing Phase 1–4 after the ERD V2 adjustment.

## Current baseline

- Backend: ASP.NET Core Web API v9
- Database: SQL Server / MSSQL
- ORM: Entity Framework Core Code First
- ID strategy: ULID string, stored as `varchar(26)`
- API response wrapper: `ApiResponse<T>`
- Existing phases included:
  - Phase 1: Master Data CRUD
  - Phase 2: Proposal, Procurement Request, Purchase Request
  - Phase 3: GM Approval and Chairman Confirmation
  - Phase 4: Purchase Order generation

## Important migration note

This version is a breaking schema baseline compared to the older GUID-based project.
Use a fresh database or reset a test database.

Do **not** run old GUID manual patch scripts from previous Phase 2/3/4 builds.

Recommended setup:

```bash
dotnet restore
dotnet build
dotnet ef migrations add InitialCreate_ErdV2_Final
dotnet ef database update
dotnet run
```

If the database still contains old IDs such as `UOM_PCS`, `MAT_CEMENT`, `STATUS_DRAFT`, or GUID IDs, create a new test database.

## Type data recommendation

| Field Type | Recommended SQL Type |
|---|---|
| ULID PK/FK/audit ID | `varchar(26)` |
| Document number | `varchar(50)` |
| Code fields | `varchar(50)` |
| Name fields | `varchar(150)` or `varchar(255)` |
| Long descriptions/notes/path | `varchar(max)` or `nvarchar(max)` if multilingual |
| Quantity | `decimal(18,4)` |
| Money amount | `decimal(18,2)` |
| Tax rate | `decimal(9,4)` |
| Date only | `date` |
| Audit timestamp | `datetime2` |
| Bool flag | `bit` |

## Seed data reference

All IDs below are true 26-character ULID strings.

### Accounts

| Purpose | AccountId | Email |
|---|---|---|
| Requester | `01KV9YAJTQ6ZW1FZ39B83T1JKE` | `requester@test.com` |
| Procure | `01KV9YAJTRK8ER2QQPT4XRZAGR` | `procure@test.com` |
| GM | `01KV9YAJTS6BKRZBE1MR3CP3XK` | `gm@test.com` |
| Admin | `01KV9YAJTTPE5ACQPKH6VMT3XH` | `superadmin@maser.com` |

### UoM

| UomId | Code | Name |
|---|---|---|
| `01KV9ZC1WJSEG74KJFNCSTJSWH` | `kg` | Kilogram |
| `01KV9ZC1WJG7GBH690RX0RH67R` | `m` | Meter |
| `01KV9ZC1WJ8BX6Q99MZS5TNDH7` | `m2` | Square Meter |
| `01KV9ZC1WJM34T07T1YC4E9VAY` | `m3` | Cubic Meter |
| `01KV9ZC1WJGCN3SJFCEBTS0ERE` | `pcs` | Pieces |
| `01KV9ZC1WJV001FZH68FTT3AET` | `ltr` | Liter |
| `01KV9ZC1WJFDW7J64746TB6J27` | `ton` | Ton |

### Material

| MaterialId | Code | Name | Default UoM |
|---|---|---|---|
| `01KV9ZC1WJWP04EDTX8C1H76E1` | `MAT-CEM-001` | Cement Portland | kg |
| `01KV9ZC1WJEW363D09Z8A62NTW` | `MAT-PLR-001` | Concrete Pillar | pcs |
| `01KV9ZC1WJDZES734T9MPBZJZG` | `MAT-STL-001` | Steel Bar | kg |

### Vendor, Company, Tax

| Data | ID | Code | Name |
|---|---|---|---|
| Vendor | `01KV9ZC1WJ0S5HY3S3AK6AS9X4` | `VND-CEMENT-01` | CV Sumber Material Bangunan |
| Company | `01KV9ZC1WJ31VKTX0HVDE9PAPA` | `PT-ABC` | PT ABC Construction Indonesia |
| Tax | `01KV9ZC1WJNT4BXQDTMZJ6KS59` | `PPN11` | PPN 11% |

### Request Type

| RequestTypeId | Code | Name |
|---|---|---|
| `01KV9YAJTZAWD6RC3N26SBJGVT` | `PROJECT` | Project Request |
| `01KV9YAJV06WF2FKC1613J54W9` | `NON_PROJECT` | Non-Project Request |

### Approval Stage

| ApprovalStageId | Stage Name |
|---|---|
| `01KV9YAJV1ARNW6X2SXVTGQTK3` | Procure |
| `01KV9YAJV2C511FFHH24D2MWZD` | GM |
| `01KV9YAJV3V3TNQSGJHRCC4SWQ` | Chairman |

## Final status decision

Use the status set below as the source of truth for Phase 1–4 and next phases:

```text
DRAFT
PENDING
SUBMITTED
UNDER_REVIEW
APPROVED
REJECTED
REVISION_REQUIRED
PARTIALLY_APPROVED
PENDING_GM_APPROVAL
GM_APPROVED
PENDING_CHAIRMAN_APPROVAL
CHAIRMAN_APPROVED
OPEN
PARTIALLY_RECEIVED
FULLY_RECEIVED
UNPAID
PARTIALLY_PAID
PAID
```

Do not use old ambiguous status names such as `WAITING_FOR_APPROVAL_1`, `WAITING_FOR_APPROVAL_2`, `RECEIVED`, or `COMPLETED` for the current flow. Use explicit GM/Chairman and receipt/payment statuses instead.

## Phase 1 — Master Data CRUD testing

Expected endpoints:

```text
GET/POST/PUT/DELETE /api/companies
GET/POST/PUT/DELETE /api/vendors
GET/POST/PUT/DELETE /api/uoms
GET/POST/PUT/DELETE /api/materials
GET/POST/PUT/DELETE /api/roles
GET/POST/PUT/DELETE /api/request-types
GET/POST/PUT/DELETE /api/statuses
GET/POST/PUT/DELETE /api/approval-stages
```

Minimum checks:

```text
GET /api/companies
GET /api/vendors
GET /api/uoms
GET /api/materials
GET /api/statuses
GET /api/request-types
GET /api/roles
GET /api/approval-stages
```

Expected: `statusCode = 200` and `data` contains seeded rows.

### Example create UoM

```json
{
  "uomCode": "box",
  "uomName": "Box"
}
```

Expected: `201 Created`.

### Example duplicate UoM

Create the same `uomCode` twice.

Expected: `400 Bad Request`.

### Example create Material

Use one of the seeded UoM IDs.

```json
{
  "uomId": "01KV9ZC1WJSEG74KJFNCSTJSWH",
  "materialCode": "MAT-SND-001",
  "materialName": "Sand",
  "description": "Construction sand"
}
```

Expected: `201 Created`.

## Phase 2 — Project flow testing

### 1. Create Proposal

Endpoint:

```text
POST /api/proposals
```

Body:

```json
{
  "requesterId": "01KV9YAJTQ6ZW1FZ39B83T1JKE",
  "proposalDate": "2026-06-15",
  "purpose": "Project material request",
  "proposalAttachmentPath": "optional/path/proposal.pdf",
  "details": [
    {
      "materialId": "01KV9ZC1WJWP04EDTX8C1H76E1",
      "uomId": "01KV9ZC1WJSEG74KJFNCSTJSWH",
      "description": "Cement Portland for project",
      "requestedQty": 500
    }
  ]
}
```

Save `proposalId` and `proposalDetailId` from response.

Expected: proposal status `DRAFT`.

### 2. Submit Proposal

```text
POST /api/proposals/{proposalId}/submit
```

Body:

```json
{}
```

Expected: proposal status `SUBMITTED` or `PENDING` based on configured fallback.

### 3. Review Proposal

```text
POST /api/proposals/{proposalId}/review
```

Body:

```json
{
  "status": "APPROVED",
  "notes": "Approved by Procure",
  "reviewedBy": "01KV9YAJTRK8ER2QQPT4XRZAGR",
  "details": [
    {
      "proposalDetailId": "replace-with-proposal-detail-id",
      "approvedQty": 400,
      "status": "APPROVED"
    }
  ]
}
```

Expected: proposal status `APPROVED`, detail approved quantity `400`.

### 4. Create Project Procurement Request

```text
POST /api/procurement-requests/project
```

Body:

```json
{
  "proposalId": "replace-with-approved-proposal-id",
  "requesterId": "01KV9YAJTQ6ZW1FZ39B83T1JKE",
  "requestDate": "2026-06-15",
  "notes": "Project request batch 1",
  "details": [
    {
      "proposalDetailId": "replace-with-approved-proposal-detail-id",
      "materialId": "01KV9ZC1WJWP04EDTX8C1H76E1",
      "uomId": "01KV9ZC1WJSEG74KJFNCSTJSWH",
      "description": "Cement request batch 1",
      "quantity": 200,
      "notes": "First batch"
    }
  ]
}
```

Expected: procurement request and purchase request are created.

### 5. Exceed approved quantity negative test

If approved quantity is 400 and you already created PR details totaling 400, creating another request with quantity 1 should return `400 Bad Request`.

## Phase 2 — Non-project flow testing

Endpoint:

```text
POST /api/procurement-requests/non-project
```

Body:

```json
{
  "requesterId": "01KV9YAJTQ6ZW1FZ39B83T1JKE",
  "requestDate": "2026-06-15",
  "notes": "Non-project material request",
  "details": [
    {
      "materialId": "01KV9ZC1WJEW363D09Z8A62NTW",
      "uomId": "01KV9ZC1WJGCN3SJFCEBTS0ERE",
      "description": "Concrete pillar for office maintenance",
      "quantity": 10,
      "notes": "Non-project test"
    }
  ]
}
```

Expected: request type `NON_PROJECT`, `proposalId = null`, purchase request created.

Save `purchaseRequestId` and `purchaseRequestDetailId` for Phase 3/4.

## Phase 3 — Approval testing

### Submit PR to GM

```text
POST /api/purchase-requests/{purchaseRequestId}/submit
```

Body:

```json
{
  "submittedBy": "01KV9YAJTQ6ZW1FZ39B83T1JKE",
  "notes": "Submit to GM approval"
}
```

Expected: `PENDING_GM_APPROVAL`.

### GM approve

```text
POST /api/purchase-requests/{purchaseRequestId}/approve-gm
```

Body:

```json
{
  "actionBy": "01KV9YAJTS6BKRZBE1MR3CP3XK",
  "notes": "Approved by GM"
}
```

Expected: `PENDING_CHAIRMAN_APPROVAL` or `GM_APPROVED` depending fallback.

### GM reject

```text
POST /api/purchase-requests/{purchaseRequestId}/reject-gm
```

Body:

```json
{
  "actionBy": "01KV9YAJTS6BKRZBE1MR3CP3XK",
  "notes": "Rejected by GM"
}
```

Expected: `REJECTED`.

### Record Chairman approval

```text
POST /api/purchase-requests/{purchaseRequestId}/record-chairman-approval
```

Body:

```json
{
  "recordedBy": "01KV9YAJTS6BKRZBE1MR3CP3XK",
  "notes": "Chairman approved offline"
}
```

Expected: purchase request final status `APPROVED`.

### Approval history

```text
GET /api/purchase-requests/{purchaseRequestId}/approval-history
```

Expected: GM and Chairman records are returned in chronological order.

## Phase 4 — Purchase Order testing

Purchase Order can only be generated from a fully approved Purchase Request.

### Generate PO from approved PR

```text
POST /api/purchase-orders/from-purchase-request/{purchaseRequestId}
```

Body:

```json
{
  "vendorId": "01KV9ZC1WJ0S5HY3S3AK6AS9X4",
  "companyId": "01KV9ZC1WJ31VKTX0HVDE9PAPA",
  "taxId": "01KV9ZC1WJNT4BXQDTMZJ6KS59",
  "poDate": "2026-06-15",
  "taxRate": 0,
  "notes": "PO generated from approved PR",
  "purchaseOrderAttachmentPath": "optional/path/po.pdf",
  "createdBy": "01KV9YAJTQ6ZW1FZ39B83T1JKE",
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

Notes:

- If `taxId` is provided, the service uses the tax rate from master tax.
- If `taxId` is empty, the service uses `taxRate` from body.
- ERD V2 allows one Purchase Request to generate multiple Purchase Orders.
- Duplicate prevention is based on ordered quantity per Purchase Request Detail, not one-PO-per-PR.

Expected calculation:

```text
subtotal = orderQuantity x unitPrice
taxAmount = subtotal x taxRate
grandTotal = subtotal + taxAmount
```

### Get PO

```text
GET /api/purchase-orders
GET /api/purchase-orders/{purchaseOrderId}
GET /api/purchase-orders/by-purchase-request/{purchaseRequestId}
```

Expected: PO header and details are returned.

### Update PO

```text
PUT /api/purchase-orders/{purchaseOrderId}
```

Body:

```json
{
  "vendorId": "01KV9ZC1WJ0S5HY3S3AK6AS9X4",
  "companyId": "01KV9ZC1WJ31VKTX0HVDE9PAPA",
  "taxId": "01KV9ZC1WJNT4BXQDTMZJ6KS59",
  "poDate": "2026-06-15",
  "taxRate": 0,
  "notes": "Updated PO notes",
  "purchaseOrderAttachmentPath": "optional/path/po-updated.pdf",
  "updatedBy": "01KV9YAJTQ6ZW1FZ39B83T1JKE",
  "details": [
    {
      "purchaseOrderDetailId": "replace-with-purchase-order-detail-id",
      "orderQuantity": 10,
      "unitPrice": 16000,
      "notes": "Updated price"
    }
  ]
}
```

Expected: totals are recalculated.

### Delete PO

```text
DELETE /api/purchase-orders/{purchaseOrderId}
```

Expected: allowed only when PO status is `OPEN`.

## Minimum pass criteria

Phase 1–4 can be considered safe if:

```text
Build succeeds
Swagger opens
Master data returns true ULID IDs
UoM seed contains kg, m, m2, m3, pcs, ltr, ton
Material seed contains Cement Portland, Concrete Pillar, Steel Bar
Project proposal flow works
Non-project flow works
GM approval flow works
Chairman confirmation flow works
Approved PR can generate PO
PO supports partial/multiple PO generation by PR detail quantity
PO totals are calculated correctly
Invalid/duplicate/exceed scenarios return 400, not 500
```
