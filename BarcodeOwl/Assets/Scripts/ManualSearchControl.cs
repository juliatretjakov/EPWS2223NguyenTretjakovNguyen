using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using OpenFoodFactsProduct;
using UnityEngine.SceneManagement;

public class ManualSearchControl : MonoBehaviour
{
   // string searchURL="https://world.openfoodfacts.org/cgi/search.pl?search_terms=coke&json=1&page=2&fields=product_name,nutriscore_grade,ecoscore_grade";
    private string searchURL="https://world.openfoodfacts.org/cgi/search.pl?search_terms=";
	private string barcodeSearch ="https://world.openfoodfacts.org/api/v2/product/";
	public PlayerControl playerData;
	//public OpenPanel panelOpener;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SendSearchRequest(string searchString, int page){
		if(searchString.All(char.IsDigit)){
			try {
				HttpWebRequest request= (HttpWebRequest)WebRequest.Create(barcodeSearch+searchString+"/?fields=product_name,nutriscore_grade,ecoscore_grade,image_front_url");
				HttpWebResponse response=(HttpWebResponse)request.GetResponse();
				if(response.StatusCode==HttpStatusCode.OK){
					StreamReader reader = new StreamReader(response.GetResponseStream());
					string jsonData=reader.ReadToEnd();
					Scan jsonObj = JsonUtility.FromJson<Scan>(jsonData);
					string jsonString= JsonUtility.ToJson(jsonObj);
					playerData.AddProductToHistory(jsonObj);
					playerData.WriteHistory();
					playerData.player.SetSelectedScan(jsonObj);
					playerData.SavePlayerData();
				}
				response.Close();
				SceneManager.LoadScene(2);
			}catch(WebException e){
				Debug.Log((int)((HttpWebResponse)e.Response).StatusCode);
			//	panelOpener.PanelOpener();
			}
		}else{
			try {
				HttpWebRequest request= (HttpWebRequest)WebRequest.Create(searchURL+searchString+"&json=1&page="+page+"&fields=code,product_name,nutriscore_grade,ecoscore_grade,image_front_url");
				HttpWebResponse response=(HttpWebResponse)request.GetResponse();
				if(response.StatusCode==HttpStatusCode.OK){
					StreamReader reader = new StreamReader(response.GetResponseStream());
					string jsonData=reader.ReadToEnd();
					SearchResult jsonObj = JsonUtility.FromJson<SearchResult>(jsonData);
					string jsonString= JsonUtility.ToJson(jsonObj);
					Debug.Log(jsonObj.ToString());
					playerData.SetSearchResults(jsonObj);
				Debug.Log("SimpleDemo"+playerData.player.selectedScan.ToString());
				}
				response.Close();
				SceneManager.LoadScene(3);
			}catch(WebException e){
				Debug.Log((int)((HttpWebResponse)e.Response).StatusCode);
			//	panelOpener.PanelOpener();
			}
		}
	}
	
	public void SendSearchRequest(string searchString){
		if(searchString.All(char.IsDigit)){
			try {
				Debug.Log("SearchControl"+searchString);
				HttpWebRequest request= (HttpWebRequest)WebRequest.Create(barcodeSearch+searchString+"/?fields=product_name,nutriscore_grade,ecoscore_grade,image_front_url");
				HttpWebResponse response=(HttpWebResponse)request.GetResponse();
				if(response.StatusCode==HttpStatusCode.OK){
					StreamReader reader = new StreamReader(response.GetResponseStream());
					string jsonData=reader.ReadToEnd();
					Scan jsonObj = JsonUtility.FromJson<Scan>(jsonData);
					string jsonString= JsonUtility.ToJson(jsonObj);
					
					playerData.AddProductToHistory(jsonObj);
					playerData.WriteHistory();
					playerData.player.SetSelectedScan(jsonObj);
					playerData.SavePlayerData();
				}
				response.Close();
				SceneManager.LoadScene(2);
			}catch(WebException e){
				Debug.Log((int)((HttpWebResponse)e.Response).StatusCode);
			//	panelOpener.PanelOpener();
			}
		}else{
			try {
				HttpWebRequest request= (HttpWebRequest)WebRequest.Create(searchURL+searchString+"&json=1&page=1&fields=code,product_name,nutriscore_grade,ecoscore_grade,image_front_url");
				HttpWebResponse response=(HttpWebResponse)request.GetResponse();
				if(response.StatusCode==HttpStatusCode.OK){
					StreamReader reader = new StreamReader(response.GetResponseStream());
					string jsonData=reader.ReadToEnd();
					SearchResult jsonObj = JsonUtility.FromJson<SearchResult>(jsonData);
					string jsonString= JsonUtility.ToJson(jsonObj);
					
					Debug.Log(jsonObj.ToString());
					playerData.SetSearchResults(jsonObj);
				}
				response.Close();
				SceneManager.LoadScene(3);
			}catch(WebException e){
				Debug.Log((int)((HttpWebResponse)e.Response).StatusCode);
			//	panelOpener.PanelOpener();
			}
		}
	}
}
