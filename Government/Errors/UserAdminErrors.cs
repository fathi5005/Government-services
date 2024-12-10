using Government.Abstractions;

namespace Government.Errors
{
    public class UserAdminErrors
    {
        public static readonly Error IvalidCredential = new("invalid user credential", "invalid Email or password");

    }
}
