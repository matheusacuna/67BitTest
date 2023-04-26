using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public float moneyAmount;
    public float moneyAmountForLevel;
    public TextMeshProUGUI moneyAmountText;
    [SerializeField] private StackingManager stackingManager;

    private void Update()
    {
        moneyAmountText.text = $"${moneyAmount}";
    }

    public void BuyLevel()
    {
        if(moneyAmount >= moneyAmountForLevel)
        {
            DecrementMoney(moneyAmountForLevel);
            stackingManager.maxStackLimit++;
        }
    }
    public void IncrementMoney(float value)
    {
        moneyAmount += value;
    }

    public void DecrementMoney(float value)
    {
        moneyAmount -= value;
    }
}
