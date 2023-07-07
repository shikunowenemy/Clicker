using TMPro;
using UnityEngine;

public class EconomicSystem : MonoBehaviour
{
    public static EconomicSystem instance;
    [SerializeField] ResourceSpawner resourceSpawner;
    [SerializeField] private TextMeshProUGUI totalMoneyText;
    private int _totalMoney;

    public int TotalMoney
    {
        get => _totalMoney;
        set
        {
            _totalMoney = value;
            UpdateUI();
            resourceSpawner.SpawnNext(_totalMoney);
        }
    }

    private void UpdateUI()
    {
        totalMoneyText.text = _totalMoney.ToString();
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
        _totalMoney = PlayerPrefs.GetInt("totalMoney", 0);
        UpdateUI();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("totalMoney", _totalMoney);
    }
}
