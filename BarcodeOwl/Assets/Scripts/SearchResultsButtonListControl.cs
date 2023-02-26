using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenFoodFactsProduct;
using UnityEngine.SceneManagement;

public class SearchResultsButtonListControl : MonoBehaviour
{   
    public PlayerControl playerData;
    [SerializeField]
    private GameObject buttonTemplate;
    [SerializeField]
    private string path;
    [SerializeField]
    private bool reversed;
    [SerializeField]
    private bool top3;
    public OpenPanel panelOpener;

    void Start(){
        if(path.Equals("history")){
            path=playerData.player.historyPath;
        }
        if(path.Equals("comfort")){
            path=playerData.player.comfortFoodPath;
        }
        if(path.Equals("search")){
            path=playerData.player.searchResultPath;
        }
        if(path.Equals("feed")){
            path=playerData.player.feedHistoryPath;
        }


        if(top3==true){
            LoadTop3();
        }else{
            LoadEntireList();
        }
    }

    public void LoadEntireList(){
        playerData.myScanControl.ReadScanList(path);
        if(reversed==true){
            for (int i=playerData.myScanControl.GetLength()-1; i>=0; i--){
                GameObject button= Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<SearchResultButtonListButton>().SetText(playerData.myScanControl.GetProduct(i).product.product_name);
                button.GetComponent<SearchResultButtonListButton>().SetTexture(playerData.myScanControl.GetProduct(i).product.image_front_url);
                button.GetComponent<SearchResultButtonListButton>().SetScan(playerData.myScanControl.GetProduct(i));
                button.transform.SetParent(buttonTemplate.transform.parent,false);
            }
        }else{
            for (int i=0; i<playerData.myScanControl.GetLength(); i++){
                GameObject button= Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<SearchResultButtonListButton>().SetText(playerData.myScanControl.GetProduct(i).product.product_name);
                button.GetComponent<SearchResultButtonListButton>().SetTexture(playerData.myScanControl.GetProduct(i).product.image_front_url);
                button.GetComponent<SearchResultButtonListButton>().SetScan(playerData.myScanControl.GetProduct(i));
                button.transform.SetParent(buttonTemplate.transform.parent,false);
            }
        }
    }

    public void LoadTop3(){
        playerData.myScanControl.ReadScanList(path);
        playerData.SortListBestEcoFirst();
        if(reversed==true){
            int count= 1;
            Scan tmp= new Scan();
            for (int i=playerData.myScanControl.GetLength()-1; i>=0; i--){
                if(!tmp.code.Equals(playerData.myScanControl.GetProduct(i).code)){
                    Debug.Log("NotEqual");
                    tmp=playerData.myScanControl.GetProduct(i);
                    GameObject button= Instantiate(buttonTemplate) as GameObject;
                    button.SetActive(true);
                    button.GetComponent<SearchResultButtonListButton>().SetText(count+": "+playerData.myScanControl.GetProduct(i).product.product_name);
                    button.GetComponent<SearchResultButtonListButton>().SetTexture(playerData.myScanControl.GetProduct(i).product.image_front_url);
                    button.GetComponent<SearchResultButtonListButton>().SetScan(playerData.myScanControl.GetProduct(i));
                    button.transform.SetParent(buttonTemplate.transform.parent,false);
                    count++;
                }
            }
        }else{
            int count= 1;
            Scan tmp = new Scan();
            for (int i=0; i<playerData.myScanControl.GetLength(); i++){    
                if(!tmp.code.Equals(playerData.myScanControl.GetProduct(i).code)){
                    Debug.Log("NotEqual");
                    tmp=playerData.myScanControl.GetProduct(i);
                    GameObject button= Instantiate(buttonTemplate) as GameObject;
                    button.SetActive(true);
                    button.GetComponent<SearchResultButtonListButton>().SetText(count+": "+playerData.myScanControl.GetProduct(i).product.product_name);
                    button.GetComponent<SearchResultButtonListButton>().SetTexture(playerData.myScanControl.GetProduct(i).product.image_front_url);
                    button.GetComponent<SearchResultButtonListButton>().SetScan(playerData.myScanControl.GetProduct(i));
                    button.transform.SetParent(buttonTemplate.transform.parent,false);
                    count++;
                }
            }
        }
    }

    public void ButtonClicked(Scan newScan){
        playerData.ReadPlayerData();
        playerData.player.selectedScan=newScan;
        playerData.SavePlayerData();
        panelOpener.PanelOpener();
    }
}
