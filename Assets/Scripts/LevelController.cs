using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // REMOVE THIS WHEN DONE 

public class LevelController : MonoBehaviour
{
    int flux = 0;
    [SerializeField]int currentLevel;
    [SerializeField] Color levelColor;
    // Start is called before the first frame update
    SceneTransition sceneTransition;
    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
    }


    public void Reset(){
        sceneTransition.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex+1 < SceneManager.sceneCountInBuildSettings){
            sceneTransition.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void AddFlux(int toAdd){
        flux += toAdd;
    }
    public int GetFlux(){
        return flux;
    }
    public int GetCurrentLevel(){
        return currentLevel;
    }
    public Color GetLevelColor(float alpha = 1){
        return new Color(levelColor.r,levelColor.g,levelColor.b,alpha);
    }
    public void UpdateCurrentLevel(int num){
        currentLevel += 1;
    }
}
