namespace ITLab2.MAUI.App
{
    public static class Constants
    {
        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "http";
        public static string Port = "5123";
        public static string DatabasesRestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/databases/{{0}}";
    }
}
