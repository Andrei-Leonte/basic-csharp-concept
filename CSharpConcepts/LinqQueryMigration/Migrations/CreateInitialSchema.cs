using FluentMigrator;

namespace LinqQueries.Migrations
{
    [Migration(20231001)]
    public class CreateInitialSchema : Migration
    {
        public override void Up()
        {
            Create.Table("People")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(256)
                .WithColumn("Age").AsInt32();

            Create.Table("Authors")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Firstname").AsString(256)
                .WithColumn("Lastname").AsString(256);

            Create.Table("PublishingHouses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(256);

            Create.Table("Books")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("AuthorId").AsInt32().ForeignKey("Authors", "Id")
                .WithColumn("PublishingHouseId").AsInt32().ForeignKey("PublishingHouses", "Id")
                .WithColumn("Title").AsString(256)
                .WithColumn("IsForAdults").AsBoolean();
        }

        public override void Down()
        {
            Delete.Table("Books");
            Delete.Table("Authors");
            Delete.Table("PublishingHouses");
            Delete.Table("People");
        }
    }
}