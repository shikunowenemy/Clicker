using TMPro;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public static LevelProgress instance;

    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI progressLevelText;
    [SerializeField] private int totalEnemies;

    private int _killedEnemies;

    public int KilledEnemies
    {
        get => _killedEnemies;
        set
        {
            _killedEnemies = value;
            progressLevelText.text = $"{_killedEnemies}/{totalEnemies}";
            if (_killedEnemies == totalEnemies)
            {
                LevelLoader.instance.CompleteLevel();
            }
        }
    }

    public void LoadProgress()
    {
        if (LevelLoader.instance.CurrentLevel == LevelLoader.instance.CompletedLevels)
        {
            _killedEnemies = PlayerPrefs.GetInt("killedEnemies", 0);
        }
        else
        {
            _killedEnemies = totalEnemies;
        }
        progressLevelText.text = $"{_killedEnemies}/{totalEnemies}";
        currentLevelText.text = $"Lvl {LevelLoader.instance.CurrentLevel + 1}";
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

    private void OnApplicationQuit()
    {
        if (_killedEnemies >= totalEnemies)
        {
            _killedEnemies = 0;
        }
        PlayerPrefs.SetInt("killedEnemies", _killedEnemies);
    }
}
