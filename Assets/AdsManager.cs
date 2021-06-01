using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private InterstitialAd interstitial;

    // Start is called before the first frame update
    void Start()
    {

    }

    public InterstitialAd GetInterstitial()
    {
        return interstitial;
    }

    // Update is called once per frame
    public void RequestInterstitial()
    {
#if UNITY_ANDROID

        string adUnitId = "ca-app-pub-7927435182506699/2279787944";
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712"; //? This is for testing purposes


#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-7927435182506699/7795838508";
                //string adUnitId = "ca-app-pub-3940256099942544/4411468910"; //? This is for testing purposes

#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        Debug.Log(" InterstitialAd Loaded");
    }

    public bool ShowInterstitial()
    {
        Debug.Log(" InterstitialAd Show");

        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            return true;
        }
        return false;
    }
}
