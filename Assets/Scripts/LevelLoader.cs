using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private RectTransform levelContainer;
    private List<Level> _levels = new();
    private int _completedLevels;
    private int _currentLevel;
    private bool _isFirstLoad;

    public int CompletedLevels
    {
        get => _completedLevels;
        set { _completedLevels = value; }
    }

    public int CurrentLevel
    {
        get => _currentLevel;
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

    private void AddLevels()
    {
        _completedLevels = PlayerPrefs.GetInt("completedLevels", 0);
        for (int i = 0; i <= _completedLevels; i++)
        {
            Level newLevel = Instantiate(levelPrefab, levelContainer).GetComponent<Level>();
            newLevel.Number = i;
            _levels.Add(newLevel);
        }
    }

    public void CompleteLevel()
    {
        _completedLevels++;
        Level newLevel = Instantiate(levelPrefab, levelContainer).GetComponent<Level>();
        newLevel.Number = _completedLevels;
        _levels.Add(newLevel);
    }

    public void LoadLevel(int levelNumber)
    {
        if (_currentLevel != levelNumber)
        {
            _levels[_currentLevel].IsCurrent = false;
        }
        _currentLevel = levelNumber;
        LevelProgress.instance.LoadProgress();
        EnemySpawn.instance.Spawn();
    }

    private void Awake()
    {
        Singleton();
        AddLevels();
    }

    private void Start()
    {
        _levels[_completedLevels].IsCurrent = true;
    }
}
