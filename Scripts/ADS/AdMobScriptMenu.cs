using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScriptMenu : MonoBehaviour
{
    public GameObject meteorButton;
    public GameObject speedButton;
    public GameObject archerButton;
    public GameObject knight3Button;
    public GameObject elfButton;
    public GameObject mageButton;

    public GameObject diamondsButton;

    public GameObject meteorAds;
    public GameObject speedAds;
    public GameObject knight3Ads;
    public GameObject archerAds;
    public GameObject elfAds;
    public GameObject mageAds;

    public static int adsInteger;

    string App_Id = "ca-app-pub-9689922636687354~8096488078";
    string Interstitial_Ad_Id = "ca-app-pub-9689922636687354/6429017334";
    string Rewarded_Video_Id = "ca-app-pub-9689922636687354/9574071339";

    private InterstitialAd interstitial;
    private RewardBasedVideoAd adReward;

    private bool adLoaded = false;

    void Start()
    {
        MobileAds.Initialize(App_Id);
        HideAdsButtons();
        RequestRewardBasedVideo();
    }
    private void HideAdsButtons()
    {
        diamondsButton.SetActive(false);
        meteorAds.SetActive(false);
        speedAds.SetActive(false);
        knight3Ads.SetActive(false);
        archerAds.SetActive(false);
        elfAds.SetActive(false);
        mageAds.SetActive(false);
    }
    public void RequestRewardBasedVideo()
    {
        adLoaded = false;
        adReward = RewardBasedVideoAd.Instance;

        AdRequest request = new AdRequest.Builder().Build();

        this.adReward.LoadAd(request, Rewarded_Video_Id);

        //adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
        //adReward.OnAdFailedToLoad += this.HandleRewardedAdFailedToLoad;
        //adReward.OnAdRewarded += this.HandleOnAdRewarded;
        //adReward.OnAdClosed += this.HandleOnRewardedAdClosed;

        // Called when an ad request has successfully loaded.
        adReward.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        adReward.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        adReward.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        adReward.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        adReward.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        adReward.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        adReward.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }
    void Update()
    {
        LevelsData data = SaveSystem.LoadLevel();
        if (data != null)
        {
            if (adLoaded == false)
            {
                if (this.adReward.IsLoaded())
                {
                    
                    adLoaded = true;
                    if (data.unlockedPlayers[2] == 0)
                    {
                        knight3Ads.SetActive(true);
                    }
                    if (data.unlockedPlayers[3] == 0)
                    {
                        archerAds.SetActive(true);
                    }
                    if (data.UnlockedAbilities[0] == 0)
                    {
                        meteorAds.SetActive(true);
                    }
                    if (data.UnlockedAbilities[1] == 0)
                    {
                        speedAds.SetActive(true);
                    }
                    if(data.unlockedPlayers[5]==0 && data.level>=10)
                    {
                        elfAds.SetActive(true);
                    }
                    if(data.unlockedPlayers[4]==0 && data.level>=9)
                    {
                        mageAds.SetActive(true);
                    }
                    diamondsButton.SetActive(true);
                }
                else
                {
                    knight3Ads.SetActive(false);
                    archerAds.SetActive(false);
                    meteorAds.SetActive(false);
                    speedAds.SetActive(false);
                    elfAds.SetActive(false);
                    diamondsButton.SetActive(false);
                    mageAds.SetActive(false);
                }
            }
        }
    }
    public void ShowVideoRewardAd()//called from the levels
    {
        if (this.adReward.IsLoaded())
        {
            this.adReward.Show();
        }
    }
    public void HandleRewardBasedVideoOpened(object sender,EventArgs args)
    {

    }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {

    }
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
    }
    public void HandleRewardBasedVideoRewarded(object sender, EventArgs args)
    {
        if (adsInteger == 0)
        {
            meteorReward();
        }
        else if (adsInteger == 1)
        {
            speedReward();
        }
        else if (adsInteger == 2)
        {
            knight3Reward();
        }
        else if(adsInteger==3)
        {
            archerReward();
        }
        else if(adsInteger==4)
        {
            elfReward();
        }
        else if(adsInteger==5)
        {
            diamondsReward();
        }
        else if(adsInteger==6)
        {
            mageReward();
        }
        onDestroy();
        RequestRewardBasedVideo();
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        StartCoroutine(rewardedAdClosed());
        Debug.Log("Reward Ad is closed : " );
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, EventArgs args)
    {
        Debug.Log("Reward Ad is not loaded : ");
    }
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
    }
    private IEnumerator rewardedAdClosed()
    {
        yield return new WaitForSeconds(0.3f);
        onDestroy();
        RequestRewardBasedVideo();
    }
    public void mageReward()
    {
        mageButton.SetActive(false);
        LevelsData data = SaveSystem.LoadLevel();
        data.unlockedPlayers[4] = 1;
        SaveSystem.SaveLevel(data.level, data.Diamonds, data.Gold, data.unlockedPlayers, data.UnlockedAbilities,
            data.PlayerCastleLevel, data.CastleUpgradStatus);
        SoundManager.PlaySound("continuesound");
    }
    public void diamondsReward()
    {
        diamondsButton.SetActive(false);
        LevelsData data = SaveSystem.LoadLevel();
        DiamondScript.diamondValue += 15;
        data.Diamonds += 15;
        SoundManager.PlaySound("continuesound");
        SaveSystem.SaveLevel(data.level, data.Diamonds, data.Gold, data.unlockedPlayers, data.UnlockedAbilities,
                    data.PlayerCastleLevel, data.CastleUpgradStatus);
    }
    public void elfReward()
    {
        elfButton.SetActive(false);
        LevelsData data = SaveSystem.LoadLevel();
        data.unlockedPlayers[5] = 1;
        SaveSystem.SaveLevel(data.level, data.Diamonds, data.Gold, data.unlockedPlayers, data.UnlockedAbilities,
            data.PlayerCastleLevel, data.CastleUpgradStatus);
        SoundManager.PlaySound("continuesound");
    }
    public void archerReward()
    {
        archerButton.SetActive(false);
        LevelsData data = SaveSystem.LoadLevel();
        data.unlockedPlayers[3] = 1;
        SaveSystem.SaveLevel(data.level, data.Diamonds, data.Gold, data.unlockedPlayers, data.UnlockedAbilities,
            data.PlayerCastleLevel, data.CastleUpgradStatus);
        SoundManager.PlaySound("continuesound");
    }
    public void knight3Reward()
    {
        knight3Button.SetActive(false);
        LevelsData data = SaveSystem.LoadLevel();
        data.unlockedPlayers[2] = 1;
        SaveSystem.SaveLevel(data.level, data.Diamonds, data.Gold, data.unlockedPlayers, data.UnlockedAbilities,
            data.PlayerCastleLevel, data.CastleUpgradStatus);
        SoundManager.PlaySound("continuesound");
    }
    public void meteorReward()
    {
        meteorButton.SetActive(false);
        LevelsData data = SaveSystem.LoadLevel();
        data.UnlockedAbilities[0] = 1;
        SaveSystem.SaveLevel(data.level, data.Diamonds, data.Gold, data.unlockedPlayers, data.UnlockedAbilities,
            data.PlayerCastleLevel, data.CastleUpgradStatus);
        SoundManager.PlaySound("continuesound");
    }
    public void speedReward()
    {
        speedButton.SetActive(false);
        LevelsData data = SaveSystem.LoadLevel();
        data.UnlockedAbilities[1] = 1;
        SaveSystem.SaveLevel(data.level, data.Diamonds, data.Gold, data.unlockedPlayers, data.UnlockedAbilities,
            data.PlayerCastleLevel, data.CastleUpgradStatus);
        SoundManager.PlaySound("continuesound");
    }
    public void onDestroy()
    {
        adReward.OnAdLoaded -= HandleRewardBasedVideoLoaded;
        adReward.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
        adReward.OnAdOpening -= HandleRewardBasedVideoOpened;
        adReward.OnAdStarted -= HandleRewardBasedVideoStarted;
        adReward.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        adReward.OnAdClosed -= HandleRewardBasedVideoClosed;
        adReward.OnAdLeavingApplication -= HandleRewardBasedVideoLeftApplication;

    }
    public void SetAdsRewardNumber(int n)
    {
        adsInteger = n;
    }
}
