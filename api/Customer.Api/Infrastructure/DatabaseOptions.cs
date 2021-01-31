namespace CustomerService.Api.Infrastructure
{
    public class DatabaseOptions 
    {
        public static readonly string Key = "DatabaseOptions";

        public bool EnableSeedData { get; set; }
    }
}