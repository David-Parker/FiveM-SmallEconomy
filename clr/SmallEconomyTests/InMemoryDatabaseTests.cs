using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallEconomy.Server;
using SmallEconomy.Shared;

namespace SmallEconomyTests
{
    [TestClass]
    public class InMemoryDatabaseTests
    {
        [TestMethod]
        public void InMemoryDatabaseTests_GetEconomyDataForPlayer_NewPlayerNoMoney()
        {
            IDatabase database = new InMemoryDatabase();

            EconomyData data = database.GetEconomyDataForPlayer("mock1");

            Assert.AreEqual(0ul, data.Money);
        }

        [TestMethod]
        public void InMemoryDatabaseTests_GetEconomyDataForPlayer_Payday()
        {
            IDatabase database = new InMemoryDatabase();

            EconomyData data = database.GetEconomyDataForPlayer("mock1");

            Assert.AreEqual(0ul, data.Money);

            database.UpdateMoneyForAllPlayers(5);

            data = database.GetEconomyDataForPlayer("mock1");

            Assert.AreEqual(5ul, data.Money);
        }

        [TestMethod]
        public void InMemoryDatabaseTests_GetEconomyDataForPlayer_Payday_SecondPlayer()
        {
            IDatabase database = new InMemoryDatabase();

            EconomyData data = database.GetEconomyDataForPlayer("mock2");

            Assert.AreEqual(0ul, data.Money);

            database.UpdateMoneyForAllPlayers(5);

            data = database.GetEconomyDataForPlayer("mock2");

            Assert.AreEqual(5ul, data.Money);

            EconomyData data2 = database.GetEconomyDataForPlayer("mock3");

            Assert.AreEqual(0ul, data2.Money);
        }
    }
}
