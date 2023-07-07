using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> resources = new List<GameObject>();

    private int _opendedResources;

    public void SpawnNext(int money)
    {
        if (_opendedResources == resources.Count)
        {
            return;
        }
        Resource actualResource = resources[_opendedResources].GetComponent<Resource>();
        if (money >= actualResource.Cost)
        {
            _opendedResources++;
            Spawn(_opendedResources);
        }
    }
    private void Spawn(int index)
    {
        resources[index].SetActive(true);
    }

    private void Start()
    {
        _opendedResources = PlayerPrefs.GetInt("openedResources", 0);
        for (int i = 0; i <= _opendedResources; i++)
        {
            Spawn(i);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("openedResources", _opendedResources);
    }
}
