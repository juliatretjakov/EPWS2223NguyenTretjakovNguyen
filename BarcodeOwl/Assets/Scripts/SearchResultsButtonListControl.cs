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
        playerData.readSearchResults();
        for (int i=0; i<playerData.searchResultsControl.GetLength(); i++){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            
            button.GetComponent<ButtonListButton>().SetText(playerData.searchResultsControl.GetProduct(i).product.product_name);
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }
}
