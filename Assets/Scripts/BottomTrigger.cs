using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomTrigger : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Animator levelIndicatorAnimator;
    [SerializeField] Animator menuAnimator;


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

        //StartCoroutine(WaitAndLoadMenu());
        StartCoroutine(ShowAd());

        if (player != null)
        {
            Destroy(player.gameObject);
        }
    }

    IEnumerator WaitAndLoadMenu()
    {
        bool adShown = adsManager.ShowInterstitial();
        yield return new WaitForSeconds(0.01f);
        menu.SetActive(true);

        if (!adShown)
        {
            levelIndicatorAnimator.SetTrigger("ActivateMenu");

            menuAnimator.SetTrigger("FadeTransition");

        }
        else
        {
            menuAnimator.SetTrigger("NoTransition");

            levelIndicatorAnimator.SetTrigger("NoTransition");
        }
    }

    IEnumerator ShowAd()
    {
        menu.SetActive(true);

        levelIndicatorAnimator.SetTrigger("ActivateMenu");
        menuAnimator.SetTrigger("FadeTransition");

        yield return new WaitForSeconds(0.01f);
        bool adShown = adsManager.ShowInterstitial();
    }

}
