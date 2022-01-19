using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{
    public GameObject ContinueButton;
    public GameObject LoseMenu;
    public Button PauseButton;
    public GameObject CastleHealthBar;

    string App_Id = "ca-app-pub-9689922636687354~8096488078";
    string Interstitial_Ad_Id = "ca-app-pub-9689922636687354/6429017334";
    string Rewarded_Video_Id = "ca-app-pub-9689922636687354/9574071339";

    private InterstitialAd interstitial;
    private RewardBasedVideoAd adReward;


    void Start()
    {
        MobileAds.Initialize(App_Id);
        RequestRewardBasedVideo();
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

    public void RequestRewardBasedVideo()
    {
        adReward = RewardBasedVideoAd.Instance;

        AdRequest request = new AdRequest.Builder().Build();

        this.adReward.LoadAd(request, Rewarded_Video_Id);

        adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
        adReward.OnAdRewarded += this.HandleOnAdRewarded;
        adReward.OnAdClosed += this.HandleOnRewardedAdClosed;
    }
    public void ShowVideoRewardAd()//called from the levels
    {
        if (this.adReward.IsLoaded())
        {
            this.adReward.Show();
            ContinueButton.SetActive(false);
        }
    }
    public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
    {
        ContinueButton.SetActive(true);
    }
    public void HandleOnAdRewarded(object sender, EventArgs args)
    {
        ContinueTheLevel();
        onDestroy();
    }
    public void HandleOnRewardedAdClosed(object sender, EventArgs args)
    {
    }
    public void ContinueTheLevel()
    {
        Time.timeScale = 1.0f;
        MoneyScript.moneyValue += 1000;
        BackGroundMusic.Continue = true;
        LoseSound.StopPlaying = true;
        GameManager.alreadyPlaying = false;
        PlayerCastle.CastleHealth = (int)CastleHealthBar.GetComponent<Slider>().maxValue;
        PlayerCastle.CastleHealth = (int)CastleHealthBar.GetComponent<Slider>().maxValue;
        SoundManager.PlaySound("continuesound");
        GameManager.Paused = false;
        GameManager.GameOver = false;
        PauseButton.interactable = true;
        LoseMenu.SetActive(false);
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
        this.interstitial.OnAdClosed -= HandleOnAdClosed;
        //MonoBehaviour.print("HandleAdClosed event received");
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    public void onDestroy()
    {
        adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        adReward.OnAdRewarded -= this.HandleOnAdRewarded;
        adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
    }

}
