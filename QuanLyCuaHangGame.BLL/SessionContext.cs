namespace QuanLyCuaHangGame.BLL
{
    public static class SessionContext
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentUserName { get; set; }
        public static string CurrentRole { get; set; }
        public static bool IsAdmin => CurrentRole == "Admin";
    }
}
