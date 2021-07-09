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

    bool isAd = false;
    void Start()
    {
        player = FindObjectOfType<Player>();
        if (!player.isDead())
        {
            menu.SetActive(false);
        }
        if (adsManager = FindObjectOfType<AdsManager>())
        {
            isAd = true;
            adsManager.RequestInterstitial();
        }
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
        bool adShown = false;
        if (isAd)
        {
            adShown = adsManager.ShowInterstitial();
        }
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
        if (isAd)
        {
            bool adShown = adsManager.ShowInterstitial();
        }
    }

}
