using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class Interstitials : MonoBehaviour
{
    string App_Id = "ca-app-pub-9689922636687354~8096488078";
    string Interstitial_Ad_Id = "ca-app-pub-9689922636687354/6429017334";

    private InterstitialAd interstitial;
    void Start()
    {
        MobileAds.Initialize(App_Id);
        RequestInterstitial();
    }
    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_Ad_Id);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;

        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;

        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }
    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdOpened event received");
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //this.interstitial.OnAdClosed -= HandleOnAdClosed;
        onDestroy();
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    public void onDestroy()
    {
        this.interstitial.OnAdLoaded -= HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening -= HandleOnAdOpened;
        this.interstitial.OnAdClosed -= HandleOnAdClosed;
        this.interstitial.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
    }
}
