using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private static MusicPlayer _instance;
    
    private void Awake(){
        if(_instance != null && _instance != this){
            Destroy(gameObject);
            return;
        }
        _instance = this;
        audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
        
    }

    public void PlayMusic(){
        if(audioSource.isPlaying){return;}
        else{audioSource.Play();}
    }

    public void StopMusic(){
        audioSource.Stop();
    }

    public void MainMenu(){
        audioSource.pitch = 0.7f;
    }
    public void PlayMode(){
        StartCoroutine(StartTransition(1.5f,0.25f,1.0f));
        //audioSource.pitch = 1.0f;
    }

  

    public IEnumerator StartTransition(float duration, float targetVolume, float targetPitch)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        float startPitch = audioSource.pitch;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            audioSource.pitch = Mathf.Lerp(startPitch, targetPitch, currentTime / (duration+3f));

            yield return null;
            StartCoroutine(StartFadeIn(start, targetPitch));
            

        }
                //audioSource.pitch = targetPitch;

        yield break;
    }
    public IEnumerator StartFadeIn(float targetVolume, float targetPitch){
        float currentTime = 0;
        float duration = 2f;
        float start = 0.20f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
