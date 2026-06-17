namespace PurchaseRequestSystem.Helpers;

public static class IdHelper
{
    public static bool IsMissing(this string? value) => string.IsNullOrWhiteSpace(value);
    public static bool IsPresent(this string? value) => !string.IsNullOrWhiteSpace(value);
}
