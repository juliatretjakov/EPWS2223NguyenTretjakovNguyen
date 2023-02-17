using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JSON;

public class ButtonListControl : MonoBehaviour
{   
    public JSONReader reader;
    [SerializeField]
    private GameObject buttonTemplate;

    void Start(){
        for (int i=0; i<reader.getLength(); i++){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            
            button.GetComponent<ButtonListButton>().SetText(reader.getProduct(i).toString());
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }
}
