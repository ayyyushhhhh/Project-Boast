using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;
public class Immunity : MonoBehaviour
{
    
    string AppID = "ca-app-pub-7011716635953939~8004933863";
    string RewardedAdId ="ca-app-pub-7011716635953939/6197028179";
    private RewardBasedVideoAd adReward;
    Pause PauseUI;
public bool VideoAd=false;
[SerializeField]GameObject Panel;


    [Obsolete]
void Start ()
	{
	
PauseUI = FindObjectOfType<Pause>();
		adReward = RewardBasedVideoAd.Instance;

		MobileAds.Initialize (AppID);
	}


	#region Reward video methods ---------------------------------------------

	public void RequestRewardAd ()
	{
		AdRequest request = AdRequestBuild ();
		adReward.LoadAd (request, RewardedAdId);

		adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded += this.HandleOnAdRewarded;
		adReward.OnAdClosed += this.HandleOnRewardedAdClosed;
	}

	public void ShowRewardAd ()
	{
		if (adReward.IsLoaded ()){
			PauseUI.PauseGame();
			adReward.Show ();
            VideoAd = true;
            StartCoroutine(ReturnFalse());
            }
            else {
    Panel.SetActive(true);
            }
	}
IEnumerator ReturnFalse(){
    yield return new WaitForSeconds(5);
    VideoAd = false;
}
	public void HandleOnRewardedAdLoaded (object sender, EventArgs args)
	{//ad loaded
		ShowRewardAd ();

	}

	public void HandleOnAdRewarded (object sender, EventArgs args)
	{//user finished watching ad
		
	}

	public void HandleOnRewardedAdClosed (object sender, EventArgs args)
	{//ad closed (even if not finished watching)
		

		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
	}

	#endregion

	//other functions
	//btn (more points) clicked
	
	//------------------------------------------------------------------------
	AdRequest AdRequestBuild ()
	{
		return new AdRequest.Builder ().Build ();
	}

	void OnDestroy ()
	{
		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
	}

}

