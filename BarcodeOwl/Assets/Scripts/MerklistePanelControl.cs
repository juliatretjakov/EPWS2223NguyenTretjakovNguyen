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

        playerData.player.AddMerklisteElement("Tomate");
        playerData.player.AddMerklisteElement("Ei");
        playerData.player.AddMerklisteElement("Zwiebeln");

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
            foreach (MerklisteElement element in playerData.player.Merkliste){
                GameObject button= Instantiate(buttonTemplate) as GameObject;
                buttons.Add(button);
                button.SetActive(true);
                button.GetComponent<MerklisteButton>().SetText(element.product_name);
                button.GetComponent<MerklisteButton>().SetToggle(element.toggle);
                button.GetComponent<MerklisteButton>().SetBarCode(element.barCode);
                button.transform.SetParent(buttonTemplate.transform.parent,false);
            }
        }else{
            foreach (MerklisteElement element in playerData.player.Merkliste){
                if(element.product_name.ToUpper().Contains(inputField.text.ToUpper())){
                    GameObject button= Instantiate(buttonTemplate) as GameObject;
                    buttons.Add(button);
                    button.SetActive(true);
                    button.GetComponent<MerklisteButton>().SetText(element.product_name);
                    button.GetComponent<MerklisteButton>().SetToggle(element.toggle);
                    button.GetComponent<MerklisteButton>().SetBarCode(element.barCode);
                    button.transform.SetParent(buttonTemplate.transform.parent,false);
                }
            }
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
