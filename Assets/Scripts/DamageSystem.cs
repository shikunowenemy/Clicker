using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem instance;

    [SerializeField] private TextMeshProUGUI clickDamageText;

    private int _clickDamage;

    public int ClickDamage
    {
        get => _clickDamage;
        set
        {
            _clickDamage = value;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        clickDamageText.text = _clickDamage.ToString();
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
        _clickDamage = PlayerPrefs.GetInt("clickDamage", 1);
        UpdateUI();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("clickDamage", _clickDamage);
    }
}
