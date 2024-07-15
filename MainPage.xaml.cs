namespace App
{
    public partial class MainPage : ContentPage
    {
        private double totalMoney = 0;
        private int lemonadeStandCount = 1;
        private double moneyPerClick = 1;

        public MainPage()
        {
            InitializeComponent();
            UpdateLemonadeStandCountDisplay();
        }

        private void OnBusinessButtonClicked(object sender, EventArgs e)
        {
            totalMoney += moneyPerClick * lemonadeStandCount;
            UpdateTotalMoneyDisplay();
        }

        private void OnUpgradeButtonClicked(object sender, EventArgs e)
        {
            const double upgradeCost = 10;
            if (totalMoney >= upgradeCost)
            {
                totalMoney -= upgradeCost;
                lemonadeStandCount++;
                UpdateTotalMoneyDisplay();
                UpdateLemonadeStandCountDisplay();
            }
        }

        private void OnBuyMaxButtonClicked(object sender, EventArgs e)
        {
            const double upgradeCost = 10;
            int maxAffordable = (int)(totalMoney / upgradeCost);
            if (maxAffordable > 0)
            {
                lemonadeStandCount += maxAffordable;
                totalMoney -= maxAffordable * upgradeCost;
                UpdateTotalMoneyDisplay();
                UpdateLemonadeStandCountDisplay();
            }
        }

        private void UpdateTotalMoneyDisplay()
        {
            TotalMoneyLabel.Text = $"Total Money: ${totalMoney}";
        }

        private void UpdateLemonadeStandCountDisplay()
        {
            LemonadeStandCountLabel.Text = $"Lemonade Stands: {lemonadeStandCount}";
        }
    }
}
