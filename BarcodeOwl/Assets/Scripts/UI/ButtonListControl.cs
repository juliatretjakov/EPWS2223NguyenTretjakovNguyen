using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenFoodFactsProduct;

public class ButtonListControl : MonoBehaviour
{   
    public ScanListControl ScanController;
    [SerializeField]
    private GameObject buttonTemplate;

    void Start(){
        ScanController.readScanList();
        for (int i=0; i<ScanController.GetLength(); i++){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            
            button.GetComponent<ButtonListButton>().SetText(ScanController.GetProduct(i).product.product_name);
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }
}
