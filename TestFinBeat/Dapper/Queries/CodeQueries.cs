namespace TestFinBeat.Dapper.Queries
{
    public static class CodeQueries
    {
        public static string DeleteAllCodes()
        {
            return $@"DELETE FROM public.""Code""";
        }

        public static string InsertCode()
        {
            return $@"INSERT INTO public.""Code""(
	                  ""Id"", ""Code"", ""Value"")
	                  VALUES (@Id, @Code, @Value)";
        }

        public static string SelectCodes()
        {
            return $@"SELECT ""Id"", ""Code"", ""Value""
                      FROM public.""Code""
                      WHERE 
                        (@Id IS NULL OR ""Id"" = @Id) AND 
                        (@Code IS NULL OR ""Code"" = @Code) AND 
                        (@Value IS NULL OR ""Value"" = @Value)";
        }
    }
}
