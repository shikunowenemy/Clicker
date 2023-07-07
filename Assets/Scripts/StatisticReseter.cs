using UnityEngine;
using UnityEngine.SceneManagement;

public class StatisticReseter : MonoBehaviour
{
    public void ResetStatistic()
    {
        PlayerPrefs.DeleteAll();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
