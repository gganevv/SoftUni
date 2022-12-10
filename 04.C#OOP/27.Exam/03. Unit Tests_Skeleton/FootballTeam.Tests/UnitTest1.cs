using NUnit.Framework;
using System;
using System.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorInitializesName()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            Assert.AreEqual("CSKAnchester", footballTeam.Name);
        }

        [Test]
        public void ConstructorInitializesSize()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            Assert.AreEqual(22, footballTeam.Capacity);
        }

        [Test]
        public void ConstructorInitializesPlayers()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            Assert.AreEqual(0, footballTeam.Players.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NullOrEmptyNameThrowsException(string name)
        {
            FootballTeam footballTeam;
            Assert.Throws<ArgumentException>(() =>
            footballTeam = new FootballTeam(name, 22)
            );
        }

        [Test]
        public void LessThan15CapacityThrowsException()
        {
            FootballTeam footballTeam;
            Assert.Throws<ArgumentException>(() =>
            footballTeam = new FootballTeam("CSKAnchester", 14)
            );
        }

        [Test]
        public void PlayersReturnProperPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Goalkeeper");
            footballTeam.AddNewPlayer(player);
            Assert.AreEqual(player, footballTeam.Players.FirstOrDefault(x => x.PlayerNumber == 4));
        }

        [Test]
        public void PlayersAddsPlayerToCollection()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("DoniMakaroni", 4, "Midfielder");
            footballTeam.AddNewPlayer(player);
            footballTeam.AddNewPlayer(player2);
            Assert.AreEqual(2, footballTeam.Players.Count);
        }

        [Test]
        public void AddPlayerAddsPlayerToPlayers()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Goalkeeper");
            footballTeam.AddNewPlayer(player);
            Assert.AreEqual(player, footballTeam.Players.FirstOrDefault(x => x.PlayerNumber == 4));
        }

        [Test]
        public void AddPlayerReturnsProperMessage()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Goalkeeper");
            string message = footballTeam.AddNewPlayer(player);
            string expectedMessage = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void AddReturnsProperMessageIfTooManyPlayers()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 15);
            FootballPlayer player1 = new FootballPlayer("Yuri", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Nick", 2, "Midfielder");
            FootballPlayer player3 = new FootballPlayer("Michael", 3, "Goalkeeper");
            FootballPlayer player4 = new FootballPlayer("Steffan", 4, "Forward");
            FootballPlayer player5 = new FootballPlayer("Mario", 5, "Forward");
            FootballPlayer player6 = new FootballPlayer("Johnny", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("Deep", 7, "Forward");
            FootballPlayer player8 = new FootballPlayer("J. K. Rowling", 8, "Goalkeeper");
            FootballPlayer player9 = new FootballPlayer("Stanimir", 9, "Forward");
            FootballPlayer player10 = new FootballPlayer("Stanislav", 10, "Midfielder");
            FootballPlayer player11 = new FootballPlayer("Stanineslav", 11, "Goalkeeper");
            FootballPlayer player12 = new FootballPlayer("Bai Gergi", 12, "Midfielder");
            FootballPlayer player13 = new FootballPlayer("Emily", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Petranka", 14, "Midfielder");
            FootballPlayer player15 = new FootballPlayer("Pesho", 15, "Midfielder");
            FootballPlayer player16 = new FootballPlayer("Krasimira Krastavata", 16, "Goalkeeper");
            footballTeam.AddNewPlayer(player1);
            footballTeam.AddNewPlayer(player2);
            footballTeam.AddNewPlayer(player3);
            footballTeam.AddNewPlayer(player4);
            footballTeam.AddNewPlayer(player5);
            footballTeam.AddNewPlayer(player6);
            footballTeam.AddNewPlayer(player7);
            footballTeam.AddNewPlayer(player8);
            footballTeam.AddNewPlayer(player9);
            footballTeam.AddNewPlayer(player10);
            footballTeam.AddNewPlayer(player11);
            footballTeam.AddNewPlayer(player12);
            footballTeam.AddNewPlayer(player13);
            footballTeam.AddNewPlayer(player14);
            footballTeam.AddNewPlayer(player15);
            string message = footballTeam.AddNewPlayer(player16);
            string expectedMessage = "No more positions available!";
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void PickPlayerReturnsProperPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Goalkeeper");
            footballTeam.AddNewPlayer(player);
            Assert.AreEqual(player, footballTeam.PickPlayer("Nick"));
        }

        [Test]
        public void PickPlayerReturnsNullIfNoProperPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Forward");
            footballTeam.AddNewPlayer(player);
            Assert.AreEqual(null, footballTeam.PickPlayer("Mario"));
        }

        [Test]
        public void PlayerScoreAddsGoalsToPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Forward");
            footballTeam.AddNewPlayer(player);
            footballTeam.PlayerScore(4);
            Assert.AreEqual(1, player.ScoredGoals);
        }

        [Test]
        public void PlayerScoreReturnsProperMessage()
        {
            FootballTeam footballTeam = new FootballTeam("CSKAnchester", 22);
            FootballPlayer player = new FootballPlayer("Nick", 4, "Forward");
            footballTeam.AddNewPlayer(player);
            string actualMessage = footballTeam.PlayerScore(4);
            string expectedMessage = $"{player.Name} scored and now has {player.ScoredGoals} for this season!";
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}