using UnityEngine;
using System.Collections;
#if UNITY_ADS
using UnityEngine.Advertisements; // Declare the Unity Ads namespace.
#endif

public class UnityAdsExample : MonoBehaviour
{
	// Define gameId as a public field
	//  so it can be set from the Inspector.
	public string gameId;
	
	void Start ()
	{
#if UNITY_ADS
		if (Advertisement.isSupported) { // If the platform is supported,
			Advertisement.Initialize(gameId); // initialize Unity Ads.
		}
#endif
	}
}