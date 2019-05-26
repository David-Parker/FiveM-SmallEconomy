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

            EconomyData data = database.GetEconomyDataForPlayer("mock");

            Assert.AreEqual(0ul, data.Money);
        }

        [TestMethod]
        public void InMemoryDatabaseTests_GetEconomyDataForPlayer_Payday()
        {
            IDatabase database = new InMemoryDatabase();

            EconomyData data = database.GetEconomyDataForPlayer("mock");

            Assert.AreEqual(0ul, data.Money);

            database.UpdateMoneyForAllPlayers(5);

            data = database.GetEconomyDataForPlayer("mock");

            Assert.AreEqual(5ul, data.Money);
        }
    }
}
