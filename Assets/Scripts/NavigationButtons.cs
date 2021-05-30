using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationButtons : MonoBehaviour
{
    int currentScene;
    MusicPlayer musicPlayer;

    SceneTransition sceneTransition;

    PersistBetweenScenes persistBetweenScenes;


    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        sceneTransition = FindObjectOfType<SceneTransition>();
        persistBetweenScenes = FindObjectOfType<PersistBetweenScenes>();

    }
    public void Play()
    {
        sceneTransition.LoadScene(Save.current.level);

        //SceneManager.LoadScene(Save.current.level);
        //musicPlayer.PlayMode();
    }
    public void Shop() // TODO: state of the menu should be preserved, i.e if win already then when returning to the scene should have the next level button.
    {
        persistBetweenScenes.SetPrevSceneIndex(SceneManager.GetActiveScene().buildIndex);
        sceneTransition.LoadScene("Shop");
    }
    public IEnumerator SetActive(Scene scene)
    {
        int i = 0;
        while (i == 0)
        {
            i++;
            yield return null;
        }
        SceneManager.SetActiveScene(scene);
        yield break;
    }

    public void Home()
    {
        sceneTransition.LoadScene(0);
        //SceneManager.LoadScene(0);
    }

    public void LevelSelect()
    {

        persistBetweenScenes.SetPrevSceneIndex(SceneManager.GetActiveScene().buildIndex);
        sceneTransition.LoadScene("LevelSelect");

    }

    public void Back()
    {
        //sceneTransition.LoadScene();
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        sceneTransition.LoadScene(persistBetweenScenes.GetPrevSceneIndex());
    }

}