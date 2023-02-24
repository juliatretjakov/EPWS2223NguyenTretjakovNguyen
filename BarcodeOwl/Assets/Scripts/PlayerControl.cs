using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;
using System.IO;

public class PlayerControl : MonoBehaviour
{   public Player player=new Player();
    public ScanListControl myScanControl;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    /**
        Read Lists functions
    */
    public void ReadHistory(){
        myScanControl.ReadScanList(player.historyPath);
    }

    public void ReadSearchResults(){
        myScanControl.ReadScanList(player.searchResultPath);
    }

    public void ReadComfortFood(){
        myScanControl.ReadScanList(player.comfortFoodPath);
    }

    public void ReadFeedHistory(){
        myScanControl.ReadScanList(player.feedHistoryPath);
    }

    /**
        Write Lists functions
    */
    public void WriteHistory(){
        myScanControl.WriteScanList(player.historyPath);
    }

    public void WriteSearchResults(){
        myScanControl.WriteScanList(player.searchResultPath);
    }

    public void SetSearchResults(SearchResult newResults){
        myScanControl.SetListTo(newResults);
        myScanControl.WriteScanList(player.searchResultPath);
    }

    public void WriteComfortFood(){
        myScanControl.WriteScanList(player.comfortFoodPath);
    }

    public void WriteFeedHistory(){
        myScanControl.WriteScanList(player.feedHistoryPath);
    }

    /**
        Add new Item to Lists Functions
    */
    public void AddProductToHistory(Scan newItem){
        ReadHistory();
        myScanControl.AddProduct(newItem);
    }
    public void AddProductToSearchResults(Scan newItem){
        ReadSearchResults();
        myScanControl.AddProduct(newItem);
    }
    public void AddProductToComfortFood(Scan newItem){
        ReadComfortFood();
        myScanControl.AddProduct(newItem);
    }
    public void AddProductToFeedHistory(Scan newItem){
        ReadFeedHistory();
        myScanControl.AddProduct(newItem);
    }

    /**
        Save and Reset PlayerData Functions
    */
    public void SavePlayerData(){
        string jsonString= JsonUtility.ToJson(player);
        File.WriteAllText(player.playerDataPath, jsonString);
    }

    public void ReadPlayerData(){
        string jsonText = System.IO.File.ReadAllText(player.playerDataPath);
        Player tmpPlayer = JsonUtility.FromJson<Player>(jsonText);
        player=tmpPlayer;
    }

    public void ResetPlayerData(){
        myScanControl.ClearScanList();
        SavePlayerData();
    }

    /**
        otherFunctions
    */
    public int GetFeedCountToday(){
        return myScanControl.GetFeedCountToday();
    }

    public void AddDrink(){
        player.AddDrink();
    }
}
