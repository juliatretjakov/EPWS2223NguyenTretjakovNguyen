using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;
using System.IO;

public class PlayerControl : MonoBehaviour
{   public Player player=new Player();
    public ScanListControl historyControl;
    public ScanListControl searchResultsControl;
    public ScanListControl comfortFoodControl;
    public ScanListControl feedHistoryControl;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    /**
        Read Lists functions
    */
    public void ReadHistory(){
        historyControl.ReadScanList(player.historyPath);
    }

    public void ReadSearchResults(){
        searchResultsControl.ReadScanList(player.searchResultPath);
    }

    public void ReadComfortFood(){
        comfortFoodControl.ReadScanList(player.comfortFoodPath);
    }

    public void ReadFeedHistory(){
        feedHistoryControl.ReadScanList(player.feedHistoryPath);
    }

    /**
        Write Lists functions
    */
    public void WriteHistory(){
        historyControl.WriteScanList(player.historyPath);
    }

    public void WriteSearchResults(){
        searchResultsControl.WriteScanList(player.searchResultPath);
    }

    public void SetSearchResults(SearchResult newResults){
        searchResultsControl.SetListTo(newResults);
        searchResultsControl.WriteScanList(player.searchResultPath);
    }

    public void WriteComfortFood(){
        comfortFoodControl.WriteScanList(player.comfortFoodPath);
    }

    public void WriteFeedHistory(){
        feedHistoryControl.WriteScanList(player.feedHistoryPath);
    }

    /**
        Add new Item to Lists Functions
    */
    public void AddProductToHistory(Scan newItem){
        historyControl.AddProduct(newItem);
    }
    public void AddProductToSearchResults(Scan newItem){
        searchResultsControl.AddProduct(newItem);
    }
    public void AddProductToComfortFood(Scan newItem){
        comfortFoodControl.AddProduct(newItem);
    }
    public void AddProductToFoodHistory(Scan newItem){
        feedHistoryControl.AddProduct(newItem);
    }

    /**
        Save and Reset PlayerData Functions
    */
    public void SavePlayerData(){
        WriteHistory();
        WriteSearchResults();
        WriteComfortFood();
        WriteFeedHistory();
        string jsonString= JsonUtility.ToJson(player);
        File.WriteAllText(player.playerDataPath, jsonString);
    }

    public void ReadPlayerData(){
        string jsonText = System.IO.File.ReadAllText(player.playerDataPath);
        Player tmpPlayer = JsonUtility.FromJson<Player>(jsonText);
        player=tmpPlayer;
    }

    public void ResetPlayerData(){
        historyControl.ClearScanList();
        searchResultsControl.ClearScanList();
        comfortFoodControl.ClearScanList();
        feedHistoryControl.ClearScanList();
        SavePlayerData();
    }

    /**
        otherFunctions
    */
    public int GetFeedCountToday(){
        return feedHistoryControl.GetFeedCountToday();
    }
}
