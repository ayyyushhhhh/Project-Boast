using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;
using System.Diagnostics;


public class AdmobScript : MonoBehaviour
{  
  	private BannerView adBanner;

	private string idApp, idBanner;


	void Start ()
	{
		idApp = "ca-app-pub-7011716635953939~8004933863";
		idBanner = "ca-app-pub-7011716635953939/2070080909";

		MobileAds.Initialize (idApp);

		RequestBannerAd ();
	}



	#region Banner Methods --------------------------------------------------

	public void RequestBannerAd ()
	{
		adBanner = new BannerView (idBanner, AdSize.Banner, AdPosition.Bottom);
		AdRequest request = AdRequestBuild ();
		adBanner.LoadAd (request);
	}

	public void DestroyBannerAd ()
	{
		if (adBanner != null)
			adBanner.Destroy ();
			
	}

	#endregion

	
	//------------------------------------------------------------------------
	AdRequest AdRequestBuild ()
	{
		return new AdRequest.Builder ().Build ();
	}

	void OnDestroy ()
	{
		DestroyBannerAd ();
	}
}
