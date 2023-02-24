using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenFoodFactsProduct;

public class SearchResultsButtonListControl : MonoBehaviour
{   
    public PlayerControl playerData;
    [SerializeField]
    private GameObject buttonTemplate;

    void Start(){
        playerData.ReadSearchResults();
        for (int i=0; i<playerData.searchResultsControl.GetLength(); i++){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            
            button.GetComponent<SearchResultButtonListButton>().SetText(playerData.searchResultsControl.GetProduct(i).product.product_name);
            button.GetComponent<SearchResultButtonListButton>().SetTexture(playerData.searchResultsControl.GetProduct(i).product.image_front_url);
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }
}
