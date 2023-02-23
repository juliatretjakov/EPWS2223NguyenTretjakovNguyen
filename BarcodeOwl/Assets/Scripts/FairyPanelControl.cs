using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FairyPanelControl : MonoBehaviour
{
    public PlayerControl playerData;
    public TMP_Text scanCount;
    public TMP_Text drinksCount;

    // Start is called before the first frame update
    void Start()
    {   
        playerData.readFeedHistory();
        playerData.player.addDrink();
        playerData.player.addDrink();
        playerData.player.addDrink();
        updateScanCountText();
        updateDrinkCountText();
    }

    public void updateScanCountText(){
        scanCount.text=playerData.getScanCountToday()+"/3";
    }

   public void updateDrinkCountText(){
        drinksCount.text=playerData.player.getDrinksToday()+"/6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
