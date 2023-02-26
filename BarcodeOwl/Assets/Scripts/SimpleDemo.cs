using BarcodeScanner;
using BarcodeScanner.Scanner;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wizcorp.Utils.Logger;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using OpenFoodFactsProduct;

public class SimpleDemo : MonoBehaviour {

	private IScanner BarcodeScanner;
	public Text TextHeader;
	public RawImage Image;
	public AudioSource Audio;
	public PlayerControl playerData;
	public OpenPanel panelOpener;
	private string openFoodFacts ="https://world.openfoodfacts.org/api/v2/product/";


	// Disable Screen Rotation on that screen
	void Awake()
	{
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;

	}

	void Start () {
		// Create a basic scanner
		BarcodeScanner = new Scanner();
		BarcodeScanner.Camera.Play();

		playerData.ReadHistory();
		playerData.ReadPlayerData();
		// Display the camera texture through a RawImage
		BarcodeScanner.OnReady += (sender, arg) => {
			// Set Orientation & Texture
			Image.transform.localEulerAngles = BarcodeScanner.Camera.GetEulerAngles();
			Image.transform.localScale = BarcodeScanner.Camera.GetScale();
			Image.texture = BarcodeScanner.Camera.Texture;

			// Keep Image Aspect Ratio
			var rect = Image.GetComponent<RectTransform>();
			var newHeight = rect.sizeDelta.x * BarcodeScanner.Camera.Height / BarcodeScanner.Camera.Width;
			rect.sizeDelta = new Vector2(rect.sizeDelta.x, newHeight);
			ClickStart();
		};

		// Track status of the scanner
		BarcodeScanner.StatusChanged += (sender, arg) => {
			TextHeader.text = "Status: " + BarcodeScanner.Status;
		};
	}

	/// <summary>
	/// The Update method from unity need to be propagated to the scanner
	/// </summary>
	void Update()
	{
		if (BarcodeScanner == null)
		{
			return;
		}
		BarcodeScanner.Update();
	}

	#region UI Buttons

	public void ClickStart()
	{
		if (BarcodeScanner == null)
		{
			Log.Warning("No valid camera - Click Start");
			return;
		}

		// Start Scanning
		BarcodeScanner.Scan((barCodeType, barCodeValue) => {
			BarcodeScanner.Stop();
			TextHeader.text = "Found: " + barCodeType + " / " + barCodeValue;

			// Feedback
			Audio.Play();

			#if UNITY_ANDROID || UNITY_IOS
			Handheld.Vibrate();
			#endif

			GetScores(barCodeValue);
			
		});
	}

	public void GetScores(string barCodeValue){
		try {
			//webReq.url=string.Format= openfoodfacts+barCodeValue+"/?fields=product_name,nutriscore_grade,ecoscore_grade";
			HttpWebRequest request= (HttpWebRequest)WebRequest.Create(openFoodFacts+barCodeValue+"/?fields=product_name,nutriscore_grade,ecoscore_grade,image_front_url");
			HttpWebResponse response=(HttpWebResponse)request.GetResponse();
			if(response.StatusCode==HttpStatusCode.OK){
				StreamReader reader = new StreamReader(response.GetResponseStream());
				string jsonData=reader.ReadToEnd();
				Scan jsonObj = JsonUtility.FromJson<Scan>(jsonData);
				playerData.player.SetSelectedScan(jsonObj);
				playerData.AddProductToHistory();
				playerData.SavePlayerData();
			}

			response.Close();
		StartCoroutine(StopCamera(() => {
			SceneManager.LoadScene(5);
		}));
		}catch(WebException e){
            Debug.Log((int)((HttpWebResponse)e.Response).StatusCode);
			ClickStop();
			panelOpener.PanelOpener();
			ClickStart();
			//EcoScore.text= string.Format("{0}",(int)((HttpWebResponse)e.Response).StatusCode);
        }
	}

	public void ClickStop()
	{
		if (BarcodeScanner == null)
		{
			Log.Warning("No valid camera - Click Stop");
			return;
		}

		// Stop Scanning
		BarcodeScanner.Stop();
	}

	public void ClickBack()
	{
		// Try to stop the camera before loading another scene
		StartCoroutine(StopCamera(() => {
			SceneManager.LoadScene(1);
		}));
	}

	public void ClickHistory(){
				// Try to stop the camera before loading another scene
		StartCoroutine(StopCamera(() => {
			SceneManager.LoadScene(3);
		}));
	}

	public void ClickSearchBarCode(){
		// Try to stop the camera before loading another scene
		StartCoroutine(StopCamera(() => {
		SceneManager.LoadScene(5);
		}));
	}

	public void ClickSearchText(){
		// Try to stop the camera before loading another scene
		StartCoroutine(StopCamera(() => {
		SceneManager.LoadScene(4);
		}));
	}



	/// <summary>
	/// This coroutine is used because of a bug with unity (http://forum.unity3d.com/threads/closing-scene-with-active-webcamtexture-crashes-on-android-solved.363566/)
	/// Trying to stop the camera in OnDestroy provoke random crash on Android
	/// </summary>
	/// <param name="callback"></param>
	/// <returns></returns>
	public IEnumerator StopCamera(Action callback)
	{
		// Stop Scanning
		Image = null;
		BarcodeScanner.Destroy();
		BarcodeScanner = null;

		// Wait a bit
		yield return new WaitForSeconds(0.1f);

		callback.Invoke();
	}

	#endregion
}
