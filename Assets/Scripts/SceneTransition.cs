using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 0.45f;
    // called first
    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transition = GetComponentInChildren<Animator>();
        transition.SetTrigger("EndTransition");

        //StartCoroutine(Wait(0.35f));
    }

    IEnumerator Wait(float time)
    {

        yield return new WaitForSeconds(time);
        transition.SetTrigger("EndTransition");

    }



    // Update is called once per frame
    public void LoadScene(int index)
    {
        StartCoroutine(WaitAndLoad(index));

    }

    IEnumerator WaitAndLoad(int index) // i think we need to load after the yield. otherwise the Fade_Start is being terminated early as the code proceeds to load the next scene.
    {
        transition.SetTrigger("StartTransition");
        yield return (new WaitForSeconds(transitionTime));
        SceneManager.LoadScene(index);
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Resources.UnloadUnusedAssets();

    }

    public void LoadScene(string name)
    {
        StartCoroutine(WaitAndLoad(name));
    }

    IEnumerator WaitAndLoad(string name) // i think we need to load after the yield. otherwise the Fade_Start is being terminated early as the code proceeds to load the next scene.
    {
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(name);
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Resources.UnloadUnusedAssets();

    }
    //TODO: MAybe try removing transition screen
    //TODO: Maybe try using this instead.
    //! CONFIRMED THAT LOADING ASYNC WILL SOLVE THE SLOW LOADING PROBLEM, BUT MUST FIND A BETTER WAY TO MAKE IT HAPPEN
    //! ASYNC Loading works but it is not allowing me to start the trainsiton (closing the two halves).
    IEnumerator LoadSceneAsync(int index)
    {
        transition.SetTrigger("StartTransition");

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
        SceneManager.sceneLoaded -= OnSceneLoaded;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        StartCoroutine(WaitAndLoad(index));


    }


}
