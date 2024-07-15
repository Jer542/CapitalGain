using System.Numerics;  // Add this namespace for BigInteger

namespace App.Models
{
    public class Business
    {
        public string Name { get; set; }
        public BigInteger IncomePerClick { get; set; }
        public BigInteger UpgradeCost { get; set; }
        public BigInteger Count { get; set; }
        public bool IsUnlocked { get; set; }
        public Button GenerateButton { get; set; }
        public Button UpgradeButton { get; set; }
        public Label CountLabel { get; set; }

        public Business(string name, BigInteger incomePerClick, BigInteger upgradeCost, BigInteger count, Button generateButton, Button upgradeButton, Label countLabel, bool isUnlocked = false)
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

        public void GenerateIncome(ref BigInteger totalMoney)
        {
            if (IsUnlocked && Count > 0)
            {
                totalMoney += IncomePerClick * Count;
            }
        }

        public bool BuyMax(ref BigInteger totalMoney)
        {
            if (IsUnlocked)
            {
                BigInteger maxCanBuy = totalMoney / UpgradeCost;
                if (maxCanBuy > 0)
                {
                    BigInteger cost = maxCanBuy * UpgradeCost;
                    if (totalMoney >= cost)
                    {
                        totalMoney -= cost;
                        Count += maxCanBuy;
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
