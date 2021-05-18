using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;


    // Update is called once per frame
    public void LoadScene(int index)
    {
        StartCoroutine(WaitAndLoad(index));
    }

    IEnumerator WaitAndLoad(int index) // i think we need to load after the yield. otherwise the Fade_Start is being terminated early as the code proceeds to load the next scene.
    {
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
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
    }



}
