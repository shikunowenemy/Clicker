using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private RectTransform levelContainer;
    [SerializeField] private int levelsCount;

    private List<Level> _levels = new();
    private int _completedLevels;
    private int _currentLevel;

    public int CompletedLevels
    {
        get => _completedLevels;
        set { _completedLevels = value; }
    }

    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            if (_currentLevel != value)
            {
                _levels[_currentLevel].IsCurrent = false;
                _currentLevel = value;
                LevelProgress.instance.UpdateLevel(_currentLevel);
                EnemySpawn.instance.Spawn();
            }
        }
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
        for (int i = 0; i < levelsCount; i++)
        {
            Level newLevel = Instantiate(levelPrefab, levelContainer).GetComponent<Level>();
            newLevel.LevelNumber = i;
            _levels.Add(newLevel);
        }
    }

    private void Awake()
    {
        Singleton();
        AddLevels();
    }

    private void Start()
    {
        _levels[PlayerPrefs.GetInt("currentLevel", 0)].IsCurrent = true;
        LevelProgress.instance.UpdateLevel(_currentLevel);
    }
}
