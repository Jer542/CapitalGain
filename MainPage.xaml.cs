using App.Models;
using System.Collections.Generic;

namespace App
{
    public partial class MainPage : ContentPage
    {
        private double totalMoney = 0;
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
                1,
                10,
                1,
                LemonadeStandButton,
                UpgradeLemonadeStandButton,
                LemonadeStandCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Newspapers",
                5,
                50,
                0,
                NewspaperButton,
                UpgradeNewspaperButton,
                NewspaperCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Car Washes",
                10,
                100,
                0,
                CarWashButton,
                UpgradeCarWashButton,
                CarWashCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Pizza Shops",
                20,
                200,
                0,
                PizzaShopButton,
                UpgradePizzaShopButton,
                PizzaShopCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Donut Shops",
                50,
                500,
                0,
                DonutShopButton,
                UpgradeDonutShopButton,
                DonutShopCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Shrimp Boats",
                100,
                1000,
                0,
                ShrimpBoatButton,
                UpgradeShrimpBoatButton,
                ShrimpBoatCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Hockey Teams",
                500,
                5000,
                0,
                HockeyTeamButton,
                UpgradeHockeyTeamButton,
                HockeyTeamCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Movie Theaters",
                1000,
                10000,
                0,
                MovieTheaterButton,
                UpgradeMovieTheaterButton,
                MovieTheaterCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Banks",
                5000,
                50000,
                0,
                BankButton,
                UpgradeBankButton,
                BankCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Oil Refineries",
                10000,
                100000,
                0,
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
            TotalMoneyLabel.Text = $"Total Money: ${totalMoney}";
        }
    }
}
