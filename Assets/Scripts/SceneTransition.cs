using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO maybe clean up the implementation of this transition. i.e we have 3 animations now, maybe we dont need 3.
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


}
