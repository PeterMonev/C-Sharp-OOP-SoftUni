using System;
using System.Linq;
using NUnit.Framework;

namespace Championship.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LeagueShouldBeInstantiatedCorrectly()
        {
            League league = new League();
            Assert.That(league.Capacity, Is.EqualTo(10));
            Assert.IsEmpty(league.Teams);
        }

        [Test]
        public void AddTeamSuccessfully()
        {
            League league = new League();

            for (int i = 0; i < 10; i++)
            {
                Team team = new Team($"Team #{i}");
                league.AddTeam(team);
                Assert.That(league.Teams, Has.Count.EqualTo(i + 1));
                Assert.That(league.Teams[^1], Is.SameAs(team));
            }
        }

        [Test]
        public void AddTeamShouldThrowExceptionWhenCapacityExceeded()
        {
            League league = new League();

            for (int i = 0; i < 10; i++)
                league.AddTeam(new Team($"Team #{i}"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                league.AddTeam(new Team("Team #10"));
            });
        }

        [Test]
        public void AddTeamShouldThrowExceptionWhenNameExists()
        {
            League league = new League();
            league.AddTeam(new Team("Team #1"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                league.AddTeam(new Team("Team #1"));
            });
        }

        [Test]
        public void RemoveTeamShouldWorkCorrectly()
        {
            League league = new League();
            league.AddTeam(new Team("Team #1"));
            league.AddTeam(new Team("Team #2"));

            bool result = league.RemoveTeam("Team #2");

            Assert.That(result, Is.True);
            Assert.That(league.Teams.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveTeamShouldReturnFalseWhenTeamDoesNotExist()
        {
            League league = new League();
            league.AddTeam(new Team("Team #1"));

            bool result = league.RemoveTeam("Team #2");

            Assert.That(result, Is.False);
            Assert.That(league.Teams.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetTeamInfoShouldReturnCorrectFormat()
        {
            League league = new League();
            Team team = new Team("Team #1");
            league.AddTeam(team);

            string info = league.GetTeamInfo("Team #1");
            Assert.That(info, Is.EqualTo("Team #1 - 0 points (0W 0D 0L)"));
        }

        [Test]
        public void GetTeamInfoShouldThrowIfTeamDoesNotExist()
        {
            League league = new League();
            league.AddTeam(new Team("Team #1"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                league.GetTeamInfo("Team #2");
            });
        }

        [Test]
        public void PlayMatchFirstTeamDoesNotExistShouldThrow()
        {
            League league = new League();
            league.AddTeam(new Team("Team #1"));
            league.AddTeam(new Team("Team #2"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                league.PlayMatch("Team #3", "Team #2", 0, 0);
            });
        }

        [Test]
        public void PlayMatchSecondTeamDoesNotExistShouldThrow()
        {
            League league = new League();
            league.AddTeam(new Team("Team #1"));
            league.AddTeam(new Team("Team #2"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                league.PlayMatch("Team #1", "Team #3", 0, 0);
            });
        }

        [Test]
        public void PlayMatchDraw_ShouldUpdatePoints()
        {
            League league = new League();
            Team t1 = new Team("Team #1");
            Team t2 = new Team("Team #2");

            league.AddTeam(t1);
            league.AddTeam(t2);

            league.PlayMatch("Team #1", "Team #2", 1, 1);

            Assert.That(t1.Draws, Is.EqualTo(1));
            Assert.That(t2.Draws, Is.EqualTo(1));
            Assert.That(t1.Points, Is.EqualTo(1));
            Assert.That(t2.Points, Is.EqualTo(1));
        }

        [Test]
        public void PlayMatchFirstTeamWin_ShouldUpdatePoints()
        {
            League league = new League();
            Team t1 = new Team("Team #1");
            Team t2 = new Team("Team #2");

            league.AddTeam(t1);
            league.AddTeam(t2);

            league.PlayMatch("Team #1", "Team #2", 2, 1);

            Assert.That(t1.Wins, Is.EqualTo(1));
            Assert.That(t2.Loses, Is.EqualTo(1));
            Assert.That(t1.Points, Is.EqualTo(3));
            Assert.That(t2.Points, Is.EqualTo(0));
        }

        [Test]
        public void PlayMatchSecondTeamWin_ShouldUpdatePoints()
        {
            League league = new League();
            Team t1 = new Team("Team #1");
            Team t2 = new Team("Team #2");

            league.AddTeam(t1);
            league.AddTeam(t2);

            league.PlayMatch("Team #1", "Team #2", 1, 2);

            Assert.That(t1.Loses, Is.EqualTo(1));
            Assert.That(t2.Wins, Is.EqualTo(1));
            Assert.That(t1.Points, Is.EqualTo(0));
            Assert.That(t2.Points, Is.EqualTo(3));
        }

        [Test]
        public void PointsCalculation_ShouldWorkCorrectly()
        {
            Team t = new Team("Team X");
            t.Win();   // +3
            t.Draw();  // +1

            Assert.That(t.Points, Is.EqualTo(4));
        }

        [Test]
        public void ToString_ShouldReturnCorrectFormat()
        {
            Team t = new Team("Lions");
            t.Win();
            t.Draw();

            string result = t.ToString();

            Assert.That(result, Is.EqualTo("Lions - 4 points (1W 1D 0L)"));
        }
    }
}
