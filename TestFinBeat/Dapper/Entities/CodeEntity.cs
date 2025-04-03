namespace TestFinBeat.Dapper.Entities
{
    public class CodeEntity
    {
        public CodeEntity()
        {

        }

        public CodeEntity(int id, string code, string value)
        {
            Id = id;
            Code = Convert.ToInt32(code);
            Value = value;
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Value { get; set; }
    }
}
