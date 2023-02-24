using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class MerklisteButton : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text myText;
    [SerializeField]
    private Toggle myToggle;
    [SerializeField]
    private MerklistePanelControl myPanelControl;

    private string barCode;

    // Start is called before the first frame update
    public void SetText(string textString)
    {
        myText.text=textString;
    }

    public void SetToggle(bool toggle){
        myToggle.isOn=toggle;
    }

    public void SwitchToggle(){
        myToggle.isOn=!myToggle.isOn;
    }

    public void SetBarCode(string newBarCode){
        barCode=newBarCode;
    }

    public void onClick(){
        myPanelControl.ButtonClicked(barCode);
    }
}
