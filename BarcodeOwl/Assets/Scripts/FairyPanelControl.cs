using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FairyPanelControl : MonoBehaviour
{
    PlayerControl playerData;
    TMP_Text scanCount;
    TMP_Text drinksCount;

    // Start is called before the first frame update
    void Start()
    {
        setText();
    }

    public void setText(){
        scanCount.text="/3";
        drinksCount.text="/6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
