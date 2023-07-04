using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public static LevelProgress instance;

    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI progressLevelText;

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

    public void UpdateLevel(int currentLevel)
    {
        currentLevelText.text = $"Lvl {currentLevel+1}";
    }

    public void UpdateProgress(int killedEnemies, int totalEnemies)
    {
        progressLevelText.text = $"{killedEnemies/totalEnemies}";
    }
}
