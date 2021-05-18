using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistBetweenScenes : MonoBehaviour
{

    private int prevSceneIndex;
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetPrevSceneIndex(int index) {
        prevSceneIndex = index;
    }

    public int GetPrevSceneIndex(){
        return prevSceneIndex;
    }
}
