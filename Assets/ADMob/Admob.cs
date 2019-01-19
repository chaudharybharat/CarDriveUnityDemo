using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class Admob : MonoBehaviour {
    BannerView bannerView;
    RewardBasedVideoAd rewardBasedVideoAd;
	// Use this for initialization
	void Start () {
        string appId = "ca-app-pub-8895289942625815~3183172823";
        MobileAds.Initialize(appId);
        this.rewardBasedVideoAd = RewardBasedVideoAd.Instance;
        requestInterval();

    }
    public void requestVideoAd()
    {
        string app_id = "";
        AdRequest adRequest = new AdRequest.Builder().Build();
        this.rewardBasedVideoAd.LoadAd(adRequest, app_id);
    }
    public void gameoverScreen()
    {
        if (this.rewardBasedVideoAd.IsLoaded())
        {
            this.rewardBasedVideoAd.Show();
        }
    }

    public void voidRequestBanner()
    {
        string appId = "";
        bannerView = new BannerView(appId, AdSize.Banner, AdPosition.Bottom);
    }
    public void requestInterval()
    {
        string appId = "ca-app-pub-8895289942625815/4419275014";
        InterstitialAd interstitialAd = new InterstitialAd(appId);
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
