namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Genres (Id,Name) values(1,'Jazz')");
            Sql("Insert INTO Genres (Id,Name) values(2,'Blues')");
            Sql("Insert INTO Genres (Id,Name) values(3,'Rock')");
            Sql("Insert INTO Genres (Id,Name) values(4,'Country')");
        }
        
        public override void Down()
        {
            Sql("Delete from Genres whre Id in (1,2,3,4)");
        }
    }
}
