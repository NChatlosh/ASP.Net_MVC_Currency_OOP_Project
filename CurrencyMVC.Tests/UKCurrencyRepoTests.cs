using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyLibrary.UKCurrency;
using CurrencyLibrary;

namespace CurrencyMVC.Tests
{
    [TestClass]
    public class UKCurrencyRepoTests
    {

        [TestMethod]
        public void UKCurrencyRepoMakeChangeTest()
        {
            //Arrange
            UKCurrencyRepo changeNinePoundsThirtyFivePence, changeThreePoundsThreePence, changeNintySevenPence, changeOnePound, changeFifteenPence;
            changeNinePoundsThirtyFivePence = new UKCurrencyRepo();
            changeThreePoundsThreePence = new UKCurrencyRepo();
            changeNintySevenPence = new UKCurrencyRepo();
            changeOnePound = new UKCurrencyRepo();
            changeFifteenPence = new UKCurrencyRepo();
            //Act
            changeNinePoundsThirtyFivePence = (UKCurrencyRepo)changeNinePoundsThirtyFivePence.MakeChange(9.35);
            changeThreePoundsThreePence = (UKCurrencyRepo)changeThreePoundsThreePence.MakeChange(3.03);
            changeNintySevenPence = (UKCurrencyRepo)changeNintySevenPence.MakeChange(0.97);
            changeOnePound = (UKCurrencyRepo)changeOnePound.MakeChange(1.00);
            changeFifteenPence = (UKCurrencyRepo)changeFifteenPence.MakeChange(0.15);
            //Assert
            Assert.AreEqual(changeNinePoundsThirtyFivePence.Coins.Count, 5);
            Assert.AreEqual(changeNinePoundsThirtyFivePence.Coins[0].GetType(), new FivePound().GetType());
            Assert.AreEqual(changeNinePoundsThirtyFivePence.Coins[1].GetType(), new TwoPound().GetType());
            Assert.AreEqual(changeNinePoundsThirtyFivePence.Coins[2].GetType(), new TwoPound().GetType());
            Assert.AreEqual(changeNinePoundsThirtyFivePence.Coins[3].GetType(), new TwentyFivePence().GetType());
            Assert.AreEqual(changeNinePoundsThirtyFivePence.Coins[4].GetType(), new TenPence().GetType());

            Assert.AreEqual(changeThreePoundsThreePence.Coins.Count, 4);
            Assert.AreEqual(changeThreePoundsThreePence.Coins[0].GetType(), new TwoPound().GetType());
            Assert.AreEqual(changeThreePoundsThreePence.Coins[1].GetType(), new OnePound().GetType());
            Assert.AreEqual(changeThreePoundsThreePence.Coins[2].GetType(), new TwoPence().GetType());
            Assert.AreEqual(changeThreePoundsThreePence.Coins[3].GetType(), new OnePenny().GetType());

            Assert.AreEqual(changeNintySevenPence.Coins.Count, 4);
            Assert.AreEqual(changeNintySevenPence.Coins[0].GetType(), new FiftyPence().GetType());
            Assert.AreEqual(changeNintySevenPence.Coins[1].GetType(), new TwentyFivePence().GetType());
            Assert.AreEqual(changeNintySevenPence.Coins[2].GetType(), new TwentyPence().GetType());
            Assert.AreEqual(changeNintySevenPence.Coins[3].GetType(), new TwoPence().GetType());

            Assert.AreEqual(changeOnePound.Coins.Count, 1);
            Assert.AreEqual(changeOnePound.Coins[0].GetType(), new OnePound().GetType());

            Assert.AreEqual(changeFifteenPence.Coins.Count, 2);
            Assert.AreEqual(changeFifteenPence.Coins[0].GetType(), new TenPence().GetType());
            Assert.AreEqual(changeFifteenPence.Coins[1].GetType(), new FivePence().GetType());
        }
    }
}
