using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenFoodFactsProduct;

public class HistoryButtonListControl : MonoBehaviour
{   
    public PlayerControl playerData;
    [SerializeField]
    private GameObject buttonTemplate;

    void Start(){
        playerData.ReadHistory();
        for (int i=0; i<playerData.historyControl.GetLength(); i++){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            
            button.GetComponent<ButtonListButton>().SetText(playerData.historyControl.GetProduct(i).product.product_name);
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }
}
