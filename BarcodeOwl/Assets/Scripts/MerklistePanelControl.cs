using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerklistePanelControl : MonoBehaviour
{
    public PlayerControl playerData;
    public ManualSearchControl mySearchControl;
    [SerializeField]
    private GameObject buttonTemplate;

    void Start(){

        playerData.ReadPlayerData();

        playerData.player.AddMerklisteElement("Tomate");
        playerData.player.AddMerklisteElement("Ei");
        playerData.player.AddMerklisteElement("Zwiebeln");
        
        playerData.player.AddMerklisteElement("Tomate");
        playerData.player.AddMerklisteElement("Ei");
        playerData.player.AddMerklisteElement("Zwiebeln");
        
        playerData.player.AddMerklisteElement("Tomate");
        playerData.player.AddMerklisteElement("Ei");
        playerData.player.AddMerklisteElement("Zwiebeln");

        UpdateMerkliste();
    }
    
    public void UpdateMerkliste(){
        
        foreach (MerklisteElement element in playerData.player.Merkliste){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<MerklisteButton>().SetText(element.product_name);
            button.GetComponent<MerklisteButton>().SetToggle(element.toggle);
            button.GetComponent<MerklisteButton>().SetBarCode(element.barCode);
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }

    public void AddMerklisteElement(string newNote){
        playerData.player.AddMerklisteElement(newNote);
    }

    public void ButtonClicked(string barCode){
        if((barCode!="")&&(barCode!=null)){
            mySearchControl.SendSearchRequest(barCode);
        }
    }
}
