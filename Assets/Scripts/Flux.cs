using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flux : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip fluxSFX;
    LevelController levelController;
    SpriteRenderer mySpriteRenderer;
    BoxCollider2D myBoxCollider;

    [SerializeField] int fluxToAdd;

    void OnTriggerEnter2D(Collider2D collider)
    {
        levelController.addCheckpoint(transform.position);
        StartCoroutine(sfxAndDestory());
        levelController.AddFlux(fluxToAdd);
        Save.current.flux += levelController.GetFlux();
        SaveLoad.SaveGame();
    }

    private IEnumerator sfxAndDestory()
    {
        audioSource.PlayOneShot(fluxSFX); // have to use a coroutine
        mySpriteRenderer.enabled = false;
        myBoxCollider.enabled = false;
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelController = FindObjectOfType<LevelController>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame

}
