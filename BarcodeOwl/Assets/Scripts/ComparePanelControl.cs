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
    // Start is called before the first frame update
    void Start()
    {
        ReloadUI();
    }

    public void LoadProduktkarteOben()
    {
        productNameTextOben.text=playerData.player.compare[0].product.product_name;
        barCodeTextOben.text=playerData.player.compare[0].code;
        SetTextureOben(playerData.player.compare[0].product.image_front_url);
        
        string ecoScore= playerData.player.compare[0].product.ecoscore_grade;
        string nutriScore= playerData.player.compare[0].product.nutriscore_grade;
        if(ecoScore!=null&&ecoScore!=""){
        	scoreImageLoader.LoadImage(ecoScore,ecoScoreImageOben);
        }
        if(nutriScore!=null&&nutriScore!=""){ 
            scoreImageLoader.LoadImage(nutriScore,nutriScoreImageOben);
        }
    }
    
    public void LoadProduktkarteUnten()
    {
        productNameTextUnten.text=playerData.player.compare[1].product.product_name;
        barCodeTextUnten.text=playerData.player.compare[1].code;
        SetTextureUnten(playerData.player.compare[1].product.image_front_url);
        productImageUnten.overrideSprite=tmpSprite;
        string ecoScore= playerData.player.compare[1].product.ecoscore_grade;
        string nutriScore= playerData.player.compare[1].product.nutriscore_grade;
        if(ecoScore!=null&&ecoScore!=""){
        	scoreImageLoader.LoadImage(ecoScore,ecoScoreImageUnten);
        }
        if(nutriScore!=null&&nutriScore!=""){ 
            scoreImageLoader.LoadImage(nutriScore,nutriScoreImageUnten);
        }
    }


    public void ReloadUI(){
        playerData.ReadPlayerData();
        if(playerData.player.compare[0].code==null||playerData.player.compare[0].code==""){
            backgroundUIOben.SetActive(true);
            produktkarteOben.SetActive(false);
        }else{
            backgroundUIOben.SetActive(false);
            playerData.player.selectedScan=playerData.player.compare[0];
            LoadProduktkarteOben();
            produktkarteOben.SetActive(true);
        }
        if(playerData.player.compare[1].code==null||playerData.player.compare[1].code==""){
            backgroundUIUnten.SetActive(true);
            produktkarteUnten.SetActive(false);
        }else{
            backgroundUIUnten.SetActive(false);
            playerData.player.selectedScan=playerData.player.compare[1];
            LoadProduktkarteUnten();
            produktkarteUnten.SetActive(true);
        }
    }

    public void RemoveOben(){
        playerData.player.compare[0]=null;
        playerData.SavePlayerData();
        ReloadUI();    
    }
    public void RemoveUnten(){
        playerData.player.compare[1]=null;
        playerData.SavePlayerData();
        ReloadUI();   
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
