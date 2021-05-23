using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistBetweenScenes : MonoBehaviour
{

    private static GameObject persistBetweenScenesInstance;
    private int prevSceneIndex;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (persistBetweenScenesInstance == null)
        {
            persistBetweenScenesInstance = this.gameObject;
        }
        else { Destroy(gameObject); }
    }

    public void SetPrevSceneIndex(int index)
    {
        prevSceneIndex = index;
    }

    public int GetPrevSceneIndex()
    {
        return prevSceneIndex;
    }
}
