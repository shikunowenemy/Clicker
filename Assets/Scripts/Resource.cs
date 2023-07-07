using TMPro;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText, damageText, costText;
    [SerializeField] int damage;
    [SerializeField] int cost;
    [SerializeField] Animator animator;

    public int Cost => cost;

    private int _level;

    public void LevelUp()
    {
        if (EconomicSystem.instance.TotalMoney >= cost)
        {
            EconomicSystem.instance.TotalMoney -= cost;
            _level++;
            CheckInstall();
            SetParameters();
            DamageSystem.instance.ClickDamage += damage;
            animator.Play("Level Up");
        }
    }

    private void CheckInstall()
    {
        if (_level == 0)
        {
            buttonText.text = "Install";
            levelText.enabled = false;
            damageText.enabled = false;
        }
        else
        {
            buttonText.text = "Lvl Up";
            levelText.enabled = true;
            damageText.enabled = true;
        }
    }

    private void SetParameters()
    {
        cost *= _level * 2;
        damage *= Mathf.CeilToInt(_level * 0.5f);
        UpdateUI();
    }
    private void UpdateUI()
    {
        costText.text = cost.ToString();
        damageText.text = $"Damage {damage}";
        levelText.text = $"Lvl {_level}";
    }


    private void Start()
    {
        name = nameText.text;
        _level = PlayerPrefs.GetInt($"{name}Level", 0);
        CheckInstall();
        UpdateUI();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt($"{name}Level", _level);
    }
}
