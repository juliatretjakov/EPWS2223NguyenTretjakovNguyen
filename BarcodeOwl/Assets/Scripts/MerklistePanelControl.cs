using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerklistePanelControl : MonoBehaviour
{
    public PlayerControl playerData;
    public ManualSearchControl mySearchControl;
    public TMP_InputField inputField;

    [SerializeField]
    private GameObject buttonTemplate;

    private List<GameObject> buttons;

    void Start(){
        buttons=new List<GameObject>();

        playerData.ReadPlayerData();
        playerData.ReadMerkliste();
        UpdateMerkliste();
    }
    
    public void UpdateMerkliste(){

        if(buttons.Count>0){
            foreach(GameObject button in buttons){
                button.SetActive(false);
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }
        if(inputField.text==""){
            if (!playerData.myMerkliste.isEmpty()){
                for (int i=0; i<playerData.myMerkliste.GetLength();i++){
                    GameObject button= Instantiate(buttonTemplate) as GameObject;
                    buttons.Add(button);
                    button.SetActive(true);
                    button.GetComponent<MerklisteButton>().SetText(playerData.myMerkliste.GetProduct(i).myScan.product.product_name);
                    button.GetComponent<MerklisteButton>().SetToggle(playerData.myMerkliste.GetProduct(i).toggle);
                    button.GetComponent<MerklisteButton>().SetBarCode(playerData.myMerkliste.GetProduct(i).myScan.code);
                    button.transform.SetParent(buttonTemplate.transform.parent,false);
                }
            }
        }else{
            if (!playerData.myMerkliste.isEmpty()){
                for (int i=0; i<playerData.myMerkliste.GetLength();i++){
                    if(playerData.myMerkliste.GetProduct(i).myScan.product.product_name.ToUpper().Contains(inputField.text.ToUpper())){
                        GameObject button= Instantiate(buttonTemplate) as GameObject;
                        buttons.Add(button);
                        button.SetActive(true);
                        button.GetComponent<MerklisteButton>().SetText(playerData.myMerkliste.GetProduct(i).myScan.product.product_name);
                        button.GetComponent<MerklisteButton>().SetToggle(playerData.myMerkliste.GetProduct(i).toggle);
                        button.GetComponent<MerklisteButton>().SetBarCode(playerData.myMerkliste.GetProduct(i).myScan.code);
                        button.transform.SetParent(buttonTemplate.transform.parent,false);
                    }
                }
            }
        }

    }

    public void AddMerklisteElement(string newNote){
        playerData.AddProductToMerkliste(newNote);
    }

    public void ButtonClicked(string barCode){
        if((barCode!="")&&(barCode!=null)){
            mySearchControl.SendSearchRequest(barCode);
        }
    }
}
