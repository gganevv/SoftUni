namespace _02.VillainNames
{
    public static class SqlQueries
    {
        public const string GetAllVillians =
            @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                  FROM Villains AS v 
                  JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                 GROUP BY v.Id, v.Name 
                HAVING COUNT(mv.VillainId) > 3 
              ORDER BY COUNT(mv.VillainId)";

        public const string GetVillainById =
            @"SELECT Name 
                FROM Villains 
               WHERE Id = @Id";

        public const string GetMinionsByVillainId =
            @"SELECT ROW_NUMBER() 
                OVER (ORDER BY m.Name) AS RowNum,
                     m.Name, 
                     m.Age
                FROM MinionsVillains AS mv
                JOIN Minions As m ON mv.MinionId = m.Id
               WHERE mv.VillainId = @Id
               ORDER BY m.Name";

        public const string GetTownByName =
            @"SELECT Id 
                FROM Towns 
               WHERE Name = @townName";

        public const string GetVillainByNane =
            @"SELECT Id 
                FROM Villains 
               WHERE Name = @Name";

        public const string InsertVillian =
            @"INSERT INTO Villains (Name, EvilnessFactorId)  
                            VALUES (@villainName, 4)";

        public const string GetTownById =
            @"SELECT Id 
                FROM Towns 
               WHERE Name = @townName";

        public const string InsertTown =
            @"INSERT INTO Towns (Name) 
              VALUES (@townName)";

        public const string InsertMinion =
            @"INSERT INTO Minions (Name, Age, TownId) 
              VALUES (@name, @age, @townId)";

        public const string GetMinionId =
            @"SELECT Id FROM Minions 
               WHERE Name = @Name";

        public const string InsertMinionVillian =
            @"INSERT INTO MinionsVillains (MinionId, VillainId) 
              VALUES (@minionId, @villainId)";

        public const string UpdateTownNames =
            @"UPDATE Towns
                 SET Name = UPPER(Name)
               WHERE CountryCode = 
             (SELECT c.Id FROM Countries AS c 
               WHERE c.Name = @countryName)";

        public const string SelectTownsFromCounty =
            @"SELECT t.Name 
                FROM Towns as t
                JOIN Countries AS c     
                  ON c.Id = t.CountryCode
               WHERE c.Name = @countryName";

        public const string DeleteMinions =
            @"DELETE FROM MinionsVillains 
                    WHERE VillainId = @villainId";

        public const string DeleteVillian =
            @"DELETE FROM Villains
                    WHERE Id = @villainId";
    }
}
