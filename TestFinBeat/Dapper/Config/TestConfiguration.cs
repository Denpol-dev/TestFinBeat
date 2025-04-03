namespace TestFinBeat.Dapper.Config
{
    public class TestConfiguration
    {
        public const string DefaultSectionName = "Postgres";

        public string ConnectionStringServer { get; set; } = null!;

        public string DbName { get; set; } = null!;

        public string ConnectionStringDefaultDatabase
        {
            get
            {
                return ConnectionStringServer + ";Database=postgres";
            }
        }

        public string ConnectionString
        {
            get
            {
                return ConnectionStringServer + ";Database=" + DbName;
            }
        }
    }
}
