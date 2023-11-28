namespace ITLab2.MAUI.App
{
    public static class Constants
    {
        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "http";
        public static string Port = "5123";
        public static string DatabasesRestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/database/{{0}}";
        public static string TablesRestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/database/{{0}}/tables/{{1}}";
        public static string ColumnsRestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/database/{{0}}/tables/{{1}}/columns/{{2}}";
        public static readonly List<string> DatabaseTypes = ["String", "Integer", "Decimal", "DateTime"];
    }
}