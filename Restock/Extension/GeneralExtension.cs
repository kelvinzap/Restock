namespace Restock.Extension;

public static class GeneralExtension
{
    public static string GetUserId(this HttpContext context)
    {
        return context.User is null ? string.Empty : context.Request.HttpContext.User.Claims.Single(x => x.Type == "id").Value;
    }
}