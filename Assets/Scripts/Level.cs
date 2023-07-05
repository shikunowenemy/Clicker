using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private GameObject activeLevelMarker;
    
    private int _number;
    private bool _isCurrent;

    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            levelNumberText.text = (_number + 1).ToString();
        }
    }

    public bool IsCurrent
    {
        get => _isCurrent;
        set
        {
            _isCurrent = value;
            activeLevelMarker.SetActive(value);
            if (value)
            {
                LevelLoader.instance.LoadLevel(Number);
            }
        }
    }
}
