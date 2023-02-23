using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerklistePanelControl : MonoBehaviour
{
    public PlayerControl playerData;
    [SerializeField]
    private GameObject buttonTemplate;

    void Start(){
        updateMerkliste();
    }
    
    public void updateMerkliste(){
        //playerData.read();
        foreach (string element in playerData.player.Merkliste){
            GameObject button= Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            
            button.GetComponent<ButtonListButton>().SetText(element);
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }

    public void AddNote(string newNote){
        playerData.player.AddNote(newNote);
    }
}
