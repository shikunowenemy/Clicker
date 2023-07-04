using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem instance;

    [SerializeField] private TextMeshProUGUI clickDamageText, damagePerSecondText;

    private int _clickDamage = 1;
    private int _damagePerSecond = 0;

    public int ClickDamage
    {
        get => _clickDamage;
        set { _clickDamage = value; }
    }

    public int DamagePerSecond
    {
        get => _damagePerSecond;
        set { _damagePerSecond = value; }
    }

    private void UpdateUI()
    {
        clickDamageText.text = _clickDamage.ToString();
        damagePerSecondText.text = _damagePerSecond.ToString();
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        UpdateUI();
    }
}
