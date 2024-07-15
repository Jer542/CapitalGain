using App.Models;
using System.Collections.Generic;

namespace App
{
    public partial class MainPage : ContentPage
    {
        private decimal totalMoney = 0;
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
                1m,
                10m,
                1m,
                LemonadeStandButton,
                UpgradeLemonadeStandButton,
                LemonadeStandCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Newspapers",
                5m,
                50m,
                0m,
                NewspaperButton,
                UpgradeNewspaperButton,
                NewspaperCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Car Washes",
                10m,
                100m,
                0m,
                CarWashButton,
                UpgradeCarWashButton,
                CarWashCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Pizza Shops",
                20m,
                200m,
                0m,
                PizzaShopButton,
                UpgradePizzaShopButton,
                PizzaShopCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Donut Shops",
                50m,
                500m,
                0m,
                DonutShopButton,
                UpgradeDonutShopButton,
                DonutShopCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Shrimp Boats",
                100m,
                1000m,
                0m,
                ShrimpBoatButton,
                UpgradeShrimpBoatButton,
                ShrimpBoatCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Hockey Teams",
                500m,
                5000m,
                0m,
                HockeyTeamButton,
                UpgradeHockeyTeamButton,
                HockeyTeamCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Movie Theaters",
                1000m,
                10000m,
                0m,
                MovieTheaterButton,
                UpgradeMovieTheaterButton,
                MovieTheaterCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Banks",
                5000m,
                50000m,
                0m,
                BankButton,
                UpgradeBankButton,
                BankCountLabel,
                isUnlocked: true));

            businesses.Add(new Business(
                "Oil Refineries",
                10000m,
                100000m,
                0m,
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
            TotalMoneyLabel.Text = $"Total Money: ${Math.Ceiling(totalMoney)}";
        }
    }
}
