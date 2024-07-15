using App.Models;
using System.Collections.Generic;
using System.Numerics;  // Add this namespace for BigInteger

namespace App
{
    public partial class MainPage : ContentPage
    {
        private BigInteger totalMoney = 0;
        private List<Business> businesses = new List<Business>();

        public MainPage()
        {
            InitializeComponent();
            InitializeBusinesses();
            UpdateTotalMoneyDisplay();
        }

        private void InitializeBusinesses()
        {
            businesses.Add(new Business(
                "Lemonade Stands",
                new BigInteger(10000000000000000000),
                new BigInteger(10),
                new BigInteger(1),
                LemonadeStandButton,
                UpgradeLemonadeStandButton,
                LemonadeStandCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Newspapers",
                new BigInteger(5),
                new BigInteger(50),
                new BigInteger(0),
                NewspaperButton,
                UpgradeNewspaperButton,
                NewspaperCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Car Washes",
                new BigInteger(10),
                new BigInteger(100),
                new BigInteger(0),
                CarWashButton,
                UpgradeCarWashButton,
                CarWashCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Pizza Shops",
                new BigInteger(20),
                new BigInteger(200),
                new BigInteger(0),
                PizzaShopButton,
                UpgradePizzaShopButton,
                PizzaShopCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Donut Shops",
                new BigInteger(50),
                new BigInteger(500),
                new BigInteger(0),
                DonutShopButton,
                UpgradeDonutShopButton,
                DonutShopCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Shrimp Boats",
                new BigInteger(100),
                new BigInteger(1000),
                new BigInteger(0),
                ShrimpBoatButton,
                UpgradeShrimpBoatButton,
                ShrimpBoatCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Hockey Teams",
                new BigInteger(500),
                new BigInteger(5000),
                new BigInteger(0),
                HockeyTeamButton,
                UpgradeHockeyTeamButton,
                HockeyTeamCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Movie Theaters",
                new BigInteger(1000),
                new BigInteger(10000),
                new BigInteger(0),
                MovieTheaterButton,
                UpgradeMovieTheaterButton,
                MovieTheaterCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Banks",
                new BigInteger(5000),
                new BigInteger(50000),
                new BigInteger(0),
                BankButton,
                UpgradeBankButton,
                BankCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Oil Refineries",
                new BigInteger(10000),
                new BigInteger(100000),
                new BigInteger(0),
                OilRefineryButton,
                UpgradeOilRefineryButton,
                OilRefineryCountLabel,
                isUnlocked: true));

            foreach (var business in businesses)
            {
                business.GenerateButton.Clicked += (sender, e) => OnGenerateClicked(business);
                business.UpgradeButton.Clicked += (sender, e) => OnUpgradeClicked(business);
                business.UpdateCountLabel();
            }
        }

        private void OnGenerateClicked(Business business)
        {
            business.GenerateIncome(ref totalMoney);
            UpdateTotalMoneyDisplay();
        }

        private void OnUpgradeClicked(Business business)
        {
            if (business.BuyMax(ref totalMoney))
            {
                business.UpdateCountLabel();
                UpdateTotalMoneyDisplay();
            }
        }

        private void UpdateTotalMoneyDisplay()
        {
            TotalMoneyLabel.Text = $"Total Money: ${totalMoney:N0}";
        }
    }
}
