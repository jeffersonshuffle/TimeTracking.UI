namespace TimeTracking.DAL.Options
{
    internal class MySqlConnectionOptions
    {
        public static string Section = nameof(MySqlConnectionOptions);
        public string ConnectionStringName { get; set; }
    }
}
