using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Networking;
using OpenFoodFactsProduct;
using UnityEngine.SceneManagement;

public class ShowProductScore : MonoBehaviour
{   
    public TMP_Text productNameText;
    public TMP_Text barCodeText;
    public Image productImage;
    public Image ecoScoreImage;
    public Image nutriScoreImage;
    //public TMP_Text nutrimentText;
    
    public LoadScoreImage scoreImageLoader;
    public PlayerControl playerData;
   // public OpenPanel openPanel;
    
    // Start is called before the first frame update
    void Start(){
        playerData.ReadHistory();
        playerData.ReadPlayerData();
        FillText();
        SetTexture();
        SetScoreImages();
    }

    public void ReloadUI(){
        playerData.ReadHistory();
        playerData.ReadPlayerData();
        FillText();
        SetTexture();
        SetScoreImages();
    }

    void FillText()
    {
       productNameText.text=playerData.player.selectedScan.product.product_name;
       barCodeText.text=playerData.player.selectedScan.code;
      // nutrimentText.text=myScanListControl.GetLatestScan().product.product_name;
       //openPanel.PanelOpener();
    }

    public void SetScoreImages(){
        string ecoScore= playerData.player.selectedScan.product.ecoscore_grade;
        string nutriScore= playerData.player.selectedScan.product.nutriscore_grade;
        if(ecoScore!=null&&ecoScore!=""){
        	scoreImageLoader.LoadImage(ecoScore,ecoScoreImage);
        }
        if(nutriScore!=null&&nutriScore!=""){ 
            scoreImageLoader.LoadImage(nutriScore,nutriScoreImage);
        }

    }

    public void FeedButtonClicked(){
        playerData.AddProductToFeedHistory(playerData.player.selectedScan);
        playerData.WriteFeedHistory();
    }

    public void AddToCompareClicked(){
        playerData.player.AddCompare(playerData.player.selectedScan);
        playerData.SavePlayerData();
        SceneManager.LoadScene(4);
    }

    public void SetTexture(){
        string url=playerData.player.selectedScan.product.image_front_url;
        if(url!=""&&url!=null){
            StartCoroutine(GetTexture(url));
        }

    }

    IEnumerator GetTexture(string url) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success){
            Debug.Log(request.error);
        }
        else {
            Texture2D myTexture=  ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite newSprite=Sprite.Create(myTexture,new Rect(0,0,myTexture.width,myTexture.height),new Vector2(0.5f,0.5f));
            productImage.overrideSprite=newSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
