# ERD V2 Database Notes

This project version is a breaking schema baseline:

- ID columns use `varchar(26)` ULID strings instead of `uniqueidentifier` GUIDs.
- Master seed data uses true 26-character ULID values.
- `tbl_module_type`, `tbl_status_detail`, and `tbl_tax` are included.
- Purchase Order follows ERD V2: one Purchase Request can generate many Purchase Orders.

Do not run old Phase 2/3/4 manual patch scripts from the GUID-based project.
For this ERD V2 version, use a fresh database or reset a test database and generate a new migration:

```bash
dotnet ef migrations add InitialCreate_ErdV2_Final
dotnet ef database update
```

If an old database already contains GUID or semantic IDs such as `UOM_PCS`, `MAT_CEMENT`, `STATUS_DRAFT`, or `COMPANY_TEST`, create a new test database instead of trying to patch it manually.
