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
        playerData.ReadFeedHistory();
        playerData.player.AddDrink();
        playerData.player.AddDrink();
        playerData.player.AddDrink();
        playerData.player.AddDrink();
        UpdateFeedCountText();
        UpdateDrinkCountText();
    }

    public void UpdateFeedCountText(){
        int feedsToday=playerData.GetFeedCountToday();
        if(feedsToday<0){
            scanCount.text="0/3";
        }if(feedsToday>3){
            scanCount.text="3/3";
        }else{
            scanCount.text=feedsToday+"/3";
        }
        
    }

    public void UpdateDrinkCountText(){
        int drinksToday=playerData.player.GetDrinkCountToday();
        if(drinksToday<0){
            drinksCount.text="0/6";
        }if(drinksToday>6){
            drinksCount.text="6/6";
        }else{
            drinksCount.text=drinksToday+"/6";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
