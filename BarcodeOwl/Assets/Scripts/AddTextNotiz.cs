using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AddTextNotiz: MonoBehaviour
{
	public PlayerControl myPlayerControl;
	public TMP_InputField inputField;
    public OpenPanel panelOpener;
    public MerklistePanelControl myPanelControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	 void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return)){
			if (inputField.text==""){
			Debug.Log("EmptyInput");
			}else{
				ReadInputString();     
			}

		}
    }

	public void ReadInputString(){
		if (inputField.text==""){
			Debug.Log("EmptyInput");
		}else{
			myPlayerControl.player.AddMerklisteElement(inputField.text);
            inputField.text="";
            myPanelControl.UpdateMerkliste();
            panelOpener.PanelOpener();

		}
	}

}
