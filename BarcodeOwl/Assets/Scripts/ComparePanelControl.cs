using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
using OpenFoodFactsProduct;
using UnityEngine.SceneManagement;

public class ComparePanelControl : MonoBehaviour
{   
    public TMP_Text productNameTextOben;
    public TMP_Text barCodeTextOben;
    public Image productImageOben;
    public Image ecoScoreImageOben;
    public Image nutriScoreImageOben;
    [SerializeField] private GameObject backgroundUIOben;
    [SerializeField] private GameObject produktkarteOben;

    public TMP_Text productNameTextUnten;
    public TMP_Text barCodeTextUnten;
    public Image productImageUnten;
    public Image ecoScoreImageUnten;
    public Image nutriScoreImageUnten;
    [SerializeField] private GameObject backgroundUIUnten;
    [SerializeField] private GameObject produktkarteUnten;


    public PlayerControl playerData;
    public LoadScoreImage scoreImageLoader;
    private Sprite tmpSprite;
    private Scan tmpSelectedScan;
    // Start is called before the first frame update
    void Start()
    {
        playerData.ReadPlayerData();
        tmpSelectedScan=playerData.player.selectedScan;
        ReloadUI();
    }

    public void LoadProduktkarteOben()
    {
        productNameTextOben.text=playerData.player.compareScan1.product.product_name;
        barCodeTextOben.text=playerData.player.compareScan1.code;
        SetTextureOben(playerData.player.compareScan1.product.image_front_url);
        
        string ecoScore= playerData.player.compareScan1.product.ecoscore_grade;
        string nutriScore= playerData.player.compareScan1.product.nutriscore_grade;
        if(ecoScore!=null&&ecoScore!=""){
        	scoreImageLoader.LoadImage(ecoScore,ecoScoreImageOben);
        }
        if(nutriScore!=null&&nutriScore!=""){ 
            scoreImageLoader.LoadImage(nutriScore,nutriScoreImageOben);
        }
    }
    
    public void LoadProduktkarteUnten()
    {
        productNameTextUnten.text=playerData.player.compareScan2.product.product_name;
        barCodeTextUnten.text=playerData.player.compareScan2.code;
        SetTextureUnten(playerData.player.compareScan2.product.image_front_url);
        productImageUnten.overrideSprite=tmpSprite;
        string ecoScore= playerData.player.compareScan2.product.ecoscore_grade;
        string nutriScore= playerData.player.compareScan2.product.nutriscore_grade;
        if(ecoScore!=null&&ecoScore!=""){
        	scoreImageLoader.LoadImage(ecoScore,ecoScoreImageUnten);
        }
        if(nutriScore!=null&&nutriScore!=""){ 
            scoreImageLoader.LoadImage(nutriScore,nutriScoreImageUnten);
        }
    }


    public void ReloadUI(){
        playerData.ReadPlayerData();
        if(playerData.player.compareScan1.code==null||playerData.player.compareScan1.code.Equals("")){
            backgroundUIOben.SetActive(true);
            produktkarteOben.SetActive(false);
        }else{
            backgroundUIOben.SetActive(false);
            playerData.player.selectedScan=playerData.player.compareScan1;
            LoadProduktkarteOben();
            produktkarteOben.SetActive(true);
        }
        if(playerData.player.compareScan2.code==null||playerData.player.compareScan2.code.Equals("")){
            backgroundUIUnten.SetActive(true);
            produktkarteUnten.SetActive(false);
        }else{
            backgroundUIUnten.SetActive(false);
            playerData.player.selectedScan=playerData.player.compareScan2;
            LoadProduktkarteUnten();
            produktkarteUnten.SetActive(true);
        }
    }

    public void RemoveOben(){
        playerData.player.compareScan1=null;
        playerData.SavePlayerData();
        ReloadUI();    
    }

    public void ShowProductButtonOben(){
        playerData.player.selectedScan=playerData.player.compareScan1;
        playerData.SavePlayerData();
        SceneManager.LoadScene(5);
    }
    public void ShowProductButtonUnten(){
        playerData.player.selectedScan=playerData.player.compareScan2;
        playerData.SavePlayerData();
        SceneManager.LoadScene(5);
    }
    public void AddMerklisteButtonOben(){
        playerData.player.SetSelectedScan(playerData.player.compareScan1);
        playerData.AddProductToMerkliste();
        playerData.SavePlayerData();
    }
    public void AddMerklisteButtonUnten(){
        playerData.player.SetSelectedScan(playerData.player.compareScan2);
        playerData.AddProductToMerkliste();
        playerData.SavePlayerData();
    }

    public void RemoveUnten(){
        playerData.player.compareScan2=null;
        playerData.SavePlayerData();
        ReloadUI();   
    }

    public void fixSelectedScan(){
        playerData.player.selectedScan=tmpSelectedScan;
        playerData.SavePlayerData();
    }


    public void SetTextureOben(string url){
        if(url!=""&&url!=null){
            StartCoroutine(GetTexture(url,() => {
			    productImageOben.overrideSprite=tmpSprite;
		    }));
        }
    }

    public void SetTextureUnten(string url){
        if(url!=""&&url!=null){
            StartCoroutine(GetTexture(url,() => {
			    productImageUnten.overrideSprite=tmpSprite;
		    }));
        }
    }

    IEnumerator GetTexture(string url,Action callback) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success){
            Debug.Log(request.error);
        }
        else {
            Texture2D myTexture=  ((DownloadHandlerTexture)request.downloadHandler).texture;
            tmpSprite=Sprite.Create(myTexture,new Rect(0,0,myTexture.width,myTexture.height),new Vector2(0.5f,0.5f));
            callback.Invoke();
        }
    }

}
