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

    void Start(){
        playerData.ReadSearchResults();
        for (int i=0; i<playerData.myScanControl.GetLength(); i++){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            
            button.GetComponent<SearchResultButtonListButton>().SetText(playerData.myScanControl.GetProduct(i).product.product_name);
            button.GetComponent<SearchResultButtonListButton>().SetTexture(playerData.myScanControl.GetProduct(i).product.image_front_url);
            button.GetComponent<SearchResultButtonListButton>().SetScan(playerData.myScanControl.GetProduct(i));
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }

    public void ButtonClicked(Scan newScan){
        playerData.player.selectedScan=newScan;
        playerData.SavePlayerData();
        SceneManager.LoadScene(2);
    }
}
