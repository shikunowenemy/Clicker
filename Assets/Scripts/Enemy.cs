using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI nameAndLevelText, healthText;
    [SerializeField] private Sprite[] icons;
    [SerializeField] private Image iconContainer;
    [SerializeField] private Animator animator;

    private string _name;
    private int _level;
    private int _health, _maxHealth;
    private int _reward;

    private void Die()
    {
        EconomicSystem.instance.TotalMoney += _reward;
        Destroy(gameObject);
    }

    private void UpdateHealth()
    {
        healthText.text = $"{_health} HP";
    }

    public void SetParameters()
    {
        iconContainer.sprite = icons[Random.Range(0, icons.Length)];
        _name = NameRandomizer.GetRandomName();
        _level = LevelLoader.instance.CurrentLevel + 1;
        _health = 10 * _level;
        _maxHealth = _health;
        _reward = _level * 2;

        nameAndLevelText.text = $"{_name}, Lvl {_level}";
        UpdateHealth();
    }

    public void GetClickDamage()
    {
        _health -= DamageSystem.instance.ClickDamage;
        animator.Play("Get Damage");
        healthBar.value = _health * 100 / _maxHealth;
        UpdateHealth();
        if (_health <= 0)
        {
            Die();
            EnemySpawn.instance.Spawn();
        }
    }
}
