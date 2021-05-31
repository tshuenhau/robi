using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistBetweenScenes : MonoBehaviour
{

    private static GameObject persistBetweenScenesInstance;
    private int prevSceneIndex;

    private bool win;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (persistBetweenScenesInstance == null)
        {
            persistBetweenScenesInstance = this.gameObject;
        }
        else { Destroy(gameObject); }
    }


    public void SetWin(bool status)
    {
        win = status;
    }

    public bool GetWin()
    {
        return win;
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
