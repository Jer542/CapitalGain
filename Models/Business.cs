namespace App.Models
{
    public class Business
    {
        public string Name { get; set; }
        public double IncomePerClick { get; set; }
        public double UpgradeCost { get; set; }
        public int Count { get; set; }
        public bool IsUnlocked { get; set; }
        public Button GenerateButton { get; set; }
        public Button UpgradeButton { get; set; }
        public Label CountLabel { get; set; }

        public Business(string name, double incomePerClick, double upgradeCost, int count, Button generateButton, Button upgradeButton, Label countLabel, bool isUnlocked = false)
        {
            Name = name;
            IncomePerClick = incomePerClick;
            UpgradeCost = upgradeCost;
            Count = count;
            GenerateButton = generateButton;
            UpgradeButton = upgradeButton;
            CountLabel = countLabel;
            IsUnlocked = isUnlocked;

            UpdateUI();
        }

        public void GenerateIncome(ref double totalMoney)
        {
            if (IsUnlocked)
            {
                totalMoney += IncomePerClick * Count;
            }
        }

        public bool BuyMax(ref double totalMoney)
        {
            if (IsUnlocked)
            {
                int maxCanBuy = (int)(totalMoney / UpgradeCost);
                if (maxCanBuy > 0)
                {
                    totalMoney -= maxCanBuy * UpgradeCost;
                    Count += maxCanBuy;
                    UpdateCountLabel();
                    return true;
                }
            }
            return false;
        }

        public void Unlock()
        {
            IsUnlocked = true;
            UpdateUI();
        }

        public void UpdateCountLabel()
        {
            CountLabel.Text = $"{Name}: {Count}";
        }

        private void UpdateUI()
        {
            GenerateButton.IsEnabled = IsUnlocked;
            UpgradeButton.IsEnabled = IsUnlocked;
        }
    }
}
