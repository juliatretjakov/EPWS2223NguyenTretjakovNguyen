using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeeklyPanelControl : MonoBehaviour
{   
    public LoadScoreImage scoreLoader;
    public Image avgEcoScore;
    public Image avgNutriScore;
    public PlayerControl playerData;
    public TMP_Text avgDrinksText;

        // Start is called before the first frame update
    void Start()
    {
        ReloadUI();
    }

    public void ReloadUI(){
        playerData.ReadFeedHistory();
        scoreLoader.LoadImage(playerData.GetAvgEcoPastSevenDays(),avgEcoScore);
        scoreLoader.LoadImage(playerData.GetAvgNutriPastSevenDays(),avgNutriScore);
        avgDrinksText.text=playerData.player.GetDrinkCountToday().ToString(); // AVG DRINKS NOT IMPLEMENTED YET 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
