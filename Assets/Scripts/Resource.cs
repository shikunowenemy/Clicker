using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] GameObject levelUpButton;
    [SerializeField] TextMeshProUGUI levelText, DamageText, installCostText, levelUpCostText;
    [SerializeField] int damage;
    [SerializeField] int cost;

    public void Install()
    {
        if (EconomicSystem.instance.TotalMoney >= cost)
        {
            EconomicSystem.instance.TotalMoney -= cost;
            levelUpButton.SetActive(true);
        }
    }

    private void IncreaseParameters()
    {
        damage *= 2;
        cost *= 2;
    }
}
