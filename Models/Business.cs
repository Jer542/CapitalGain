namespace App.Models
{
    public class Business
    {
        public string Name { get; set; }
        public double IncomePerClick { get; set; }
        public double UpgradeCost { get; set; }
        public int Count { get; set; }
        public Button GenerateButton { get; set; }
        public Button UpgradeButton { get; set; }
        public Label CountLabel { get; set; }

        public Business(string name, double incomePerClick, double upgradeCost, int count, Button generateButton, Button upgradeButton, Label countLabel)
        {
            Name = name;
            IncomePerClick = incomePerClick;
            UpgradeCost = upgradeCost;
            Count = count;
            GenerateButton = generateButton;
            UpgradeButton = upgradeButton;
            CountLabel = countLabel;
        }

        public void GenerateIncome(ref double totalMoney)
        {
            totalMoney += IncomePerClick * Count;
        }

        public bool Upgrade(ref double totalMoney)
        {
            if (totalMoney >= UpgradeCost)
            {
                totalMoney -= UpgradeCost;
                Count++;
                return true;
            }
            return false;
        }

        public void UpdateCountLabel()
        {
            CountLabel.Text = $"{Name}: {Count}";
        }
    }
}
