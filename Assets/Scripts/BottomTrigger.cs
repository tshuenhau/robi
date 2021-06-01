using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomTrigger : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Animator levelIndicatorAnimator;

    AdsManager adsManager;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        if (!player.isDead())
        {
            menu.SetActive(false);
        }
        adsManager = FindObjectOfType<AdsManager>();
        adsManager.RequestInterstitial();
        //adsManager.ShowInterstitial();

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        adsManager.ShowInterstitial();
        StartCoroutine(WaitAndLoadMenu());

        levelIndicatorAnimator.SetTrigger("ActivateMenu");

        if (player != null)
        {
            Destroy(player.gameObject);
        }
    }

    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(0.01f);
        menu.SetActive(true);

    }

}
