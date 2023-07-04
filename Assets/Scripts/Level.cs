using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private GameObject activeLevelMarker;
    [SerializeField] private int amountEnemies;

    private int _levelNumber;
    private bool _isCurrent;
    private int _killedEnemies = 0;

    public int LevelNumber
    {
        get => _levelNumber;
        set
        {
            _levelNumber = value;
            levelNumberText.text = (_levelNumber + 1).ToString();
        }
    }

    public bool IsCurrent
    {
        get => _isCurrent;
        set
        {
            _isCurrent = value;
            activeLevelMarker.SetActive(value);
            if (_isCurrent)
            {
                LevelLoader.instance.CurrentLevel = _levelNumber;
            }
        }
    }

    public int KilledEnemies
    {
        get => _killedEnemies;
        set
        {
            _killedEnemies = value;
        }
    }
}
