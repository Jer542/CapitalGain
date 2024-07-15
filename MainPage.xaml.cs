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
                LemonadeStandCountLabel));

            businesses.Add(new Business(
                "Newspapers",
                5,
                50,
                1,
                NewspaperButton,
                UpgradeNewspaperButton,
                NewspaperCountLabel));

            businesses.Add(new Business(
                "Car Washes",
                10,
                100,
                1,
                CarWashButton,
                UpgradeCarWashButton,
                CarWashCountLabel));

            businesses.Add(new Business(
                "Pizza Shops",
                20,
                200,
                1,
                PizzaShopButton,
                UpgradePizzaShopButton,
                PizzaShopCountLabel));

            businesses.Add(new Business(
                "Donut Shops",
                50,
                500,
                1,
                DonutShopButton,
                UpgradeDonutShopButton,
                DonutShopCountLabel));

            businesses.Add(new Business(
                "Shrimp Boats",
                100,
                1000,
                1,
                ShrimpBoatButton,
                UpgradeShrimpBoatButton,
                ShrimpBoatCountLabel));

            businesses.Add(new Business(
                "Hockey Teams",
                500,
                5000,
                1,
                HockeyTeamButton,
                UpgradeHockeyTeamButton,
                HockeyTeamCountLabel));

            businesses.Add(new Business(
                "Movie Theaters",
                1000,
                10000,
                1,
                MovieTheaterButton,
                UpgradeMovieTheaterButton,
                MovieTheaterCountLabel));

            businesses.Add(new Business(
                "Banks",
                5000,
                50000,
                1,
                BankButton,
                UpgradeBankButton,
                BankCountLabel));

            businesses.Add(new Business(
                "Oil Refineries",
                10000,
                100000,
                1,
                OilRefineryButton,
                UpgradeOilRefineryButton,
                OilRefineryCountLabel));

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
            if (business.Upgrade(ref totalMoney))
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
