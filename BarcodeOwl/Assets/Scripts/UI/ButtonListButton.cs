using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ButtonListButton : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text myText;

    // Start is called before the first frame update
    public void SetText(string textString)
    {
        myText.text=textString;
    }

}
