namespace VideoWorld.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class PopulateGenres : DbMigration
	{
		public override void Up()
		{
			Sql("INSERT INTO Genres(Name) VALUES('Action')");
			Sql("INSERT INTO Genres(Name) VALUES('Comedy')");
			Sql("INSERT INTO Genres(Name) VALUES('Horror')");
			Sql("INSERT INTO Genres(Name) VALUES('Romantic')");
			Sql("INSERT INTO Genres(Name) VALUES('Science Fiction')");
		}
		
		public override void Down()
		{
		}
	}
}
