using UnityEngine;
using System.Collections;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UnityAdsButton : MonoBehaviour
{
	void OnGUI ()
	{
#if UNITY_ADS
		Rect buttonRect = new Rect (10, 10, 150, 50);
		string buttonText = Advertisement.IsReady () ? "Show Ad" : "Waiting...";
		
		if (GUI.Button (buttonRect, buttonText)) {
			Advertisement.Show ();
		}
#endif
	}
}