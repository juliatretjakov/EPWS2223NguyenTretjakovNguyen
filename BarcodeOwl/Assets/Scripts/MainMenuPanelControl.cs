using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class MainMenuPanelControl : MonoBehaviour
{
    public PlayerControl playerData;
    public Image owl;
    public Image emotionBubble;
    public LoadScoreImage imageLoader;
    public DateTime nextRandomTime;
    public TMP_Text dialogbox;
    public TMP_Text hungerPercentageText;
   

    // Start is called before the first frame update
    void Start()
    {   
        playerData.ReadPlayerData();
        nextRandomTime=DateTime.Now;
        UpdateOwl();
    }

    // Update is called once per frame
    void Update()
    {
        playerData.ReadPlayerData();
        if(DateTime.Compare(DateTime.Now,nextRandomTime)>0){
        UpdateOwl();
     }
     hungerPercentageText.text=playerData.player.GetHungerPercentage().ToString()+"%";
    }

    public void UpdateOwl(){
        System.Random rnd = new System.Random();
        int seconds= rnd.Next(5,8);
        nextRandomTime=nextRandomTime.AddSeconds(Convert.ToDouble(seconds));
        if(playerData.player.sleeps){
            imageLoader.LoadOwlImage(4,owl);
            dialogbox.text="zZz zZz";
        }else{
            
            int status = rnd.Next(1,4);
            if(status==1&&playerData.player.isHungry()){
                imageLoader.LoadOwlImage(2,owl);
                imageLoader.LoadOwlEmoji(2,emotionBubble);
                dialogbox.text="Ich habe Hunger!!";
            }/*else if(status==2&&playerData.player.isThirsty()){
                imageLoader.LoadOwlImage(2,owl);
            }else if()*/
            else{
                imageLoader.LoadOwlImage(1,owl);
                imageLoader.LoadOwlEmoji(1,emotionBubble);
                dialogbox.text="Lalalala :-)";
            }
        }

    }

    public void ToggleSleep(){
        
        playerData.player.sleeps=!playerData.player.sleeps;        

    }
}
