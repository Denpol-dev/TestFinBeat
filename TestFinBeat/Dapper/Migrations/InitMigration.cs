using FluentMigrator;

namespace TestFinBeat.Dapper.Migrations
{
    [Migration(0)]
    public class InitMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Code")
                .WithColumn("Id").AsInt32().NotNullable()
                .WithColumn("Code").AsInt32().NotNullable()
                .WithColumn("Value").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Code");
        }
    }
}
