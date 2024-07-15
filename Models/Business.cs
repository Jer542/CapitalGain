namespace App.Models
{
    public class Business
    {
        public string Name { get; set; }
        public decimal IncomePerClick { get; set; }
        public decimal UpgradeCost { get; set; }
        public decimal Count { get; set; }
        public bool IsUnlocked { get; set; }
        public Button GenerateButton { get; set; }
        public Button UpgradeButton { get; set; }
        public Label CountLabel { get; set; }

        public Business(string name, decimal incomePerClick, decimal upgradeCost, decimal count, Button generateButton, Button upgradeButton, Label countLabel, bool isUnlocked = false)
        {
            Name = name;
            IncomePerClick = incomePerClick;
            UpgradeCost = upgradeCost;
            Count = Math.Ceiling(count);
            GenerateButton = generateButton;
            UpgradeButton = upgradeButton;
            CountLabel = countLabel;
            IsUnlocked = isUnlocked;

            UpdateUI();
        }

        public void GenerateIncome(ref decimal totalMoney)
        {
            if (IsUnlocked && Count > 0)
            {
                totalMoney += IncomePerClick * Count;
            }
        }

        public bool BuyMax(ref decimal totalMoney)
        {
            if (IsUnlocked)
            {
                decimal maxCanBuy = Math.Floor(totalMoney / UpgradeCost);
                if (maxCanBuy > 0)
                {
                    decimal cost = maxCanBuy * UpgradeCost;
                    if (totalMoney >= cost)
                    {
                        totalMoney -= cost;
                        Count += maxCanBuy;
                        Count = Math.Ceiling(Count);
                        UpdateCountLabel();
                        return true;
                    }
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
