using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    SceneTransition sceneTransition;

    void Start(){
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void LoadLevel(int val){
        sceneTransition.LoadScene(val);
    }

}
