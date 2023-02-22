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
	public SimpleDemo barCodeScannerControl;
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
			HttpWebRequest request= (HttpWebRequest)WebRequest.Create(barcodeSearch+searchString+"/?fields=product_name,nutriscore_grade,ecoscore_grade");
			HttpWebResponse response=(HttpWebResponse)request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream());
			string jsonData=reader.ReadToEnd();
			Scan jsonObj = JsonUtility.FromJson<Scan>(jsonData);
							string jsonString= JsonUtility.ToJson(jsonObj);
            	File.WriteAllText("Assets\\Resources\\testDump.txt", jsonString);
			playerData.addProductToHistory(jsonObj);
            playerData.writeHistory();
            response.Close();
            StartCoroutine(barCodeScannerControl.StopCamera(() => {
			SceneManager.LoadScene(2);
		}));
		
        }catch(WebException e){
            Debug.Log((int)((HttpWebResponse)e.Response).StatusCode);
			//EcoScore.text= string.Format("{0}",(int)((HttpWebResponse)e.Response).StatusCode);
    	    }
		}else{
			try {
				HttpWebRequest request= (HttpWebRequest)WebRequest.Create(searchURL+searchString+"&json=1&page="+page+"&fields=code,product_name,nutriscore_grade,ecoscore_grade");
				HttpWebResponse response=(HttpWebResponse)request.GetResponse();
				StreamReader reader = new StreamReader(response.GetResponseStream());
				string jsonData=reader.ReadToEnd();
				SearchResult jsonObj = JsonUtility.FromJson<SearchResult>(jsonData);
				string jsonString= JsonUtility.ToJson(jsonObj);
            	File.WriteAllText("Assets\\Resources\\testDump.txt", jsonString);
				Debug.Log(jsonObj.ToString());
                playerData.writeSearchResults(jsonObj);
                StartCoroutine(barCodeScannerControl.StopCamera(() => {
			    SceneManager.LoadScene(3);
            	}));

			}catch(WebException e){
				Debug.Log((int)((HttpWebResponse)e.Response).StatusCode);
				//EcoScore.text= string.Format("{0}",(int)((HttpWebResponse)e.Response).StatusCode);
				}
		}
	}
}
