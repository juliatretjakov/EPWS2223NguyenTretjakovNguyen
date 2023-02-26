using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;
using System.IO;

public class PlayerControl : MonoBehaviour
{   public Player player;
    public ScanListControl myScanControl;
    public MerklisteControl myMerkliste;
    
    // Start is called before the first frame update
    void Awake(){
        player= new Player();
        
    }
    void Start()
    {
        ReadPlayerData();
        Debug.Log(Application.persistentDataPath);
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

    public void ReadMerkliste(){
        myMerkliste.ReadScanList(player.merklistePath);
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

    public void WriteMerkliste(){
        myMerkliste.WriteScanList(player.merklistePath);
    }

    /**
        Add new Item to Lists Functions
    */
    public void AddProductToHistory(){
        ReadHistory();
        myScanControl.AddProduct(player.selectedScan);
        WriteHistory();
    }
    public void AddProductToSearchResults(){
        ReadSearchResults();
        myScanControl.AddProduct(player.selectedScan);
        WriteSearchResults();
    }
    public void AddProductToComfortFood(){
        ReadComfortFood();
        myScanControl.AddProduct(player.selectedScan);
        WriteComfortFood();
    }
    public void AddProductToFeedHistory(){
        ReadFeedHistory();
        ReadPlayerData();
        player.FeedOwl();
        SavePlayerData();
        myScanControl.AddProduct(player.selectedScan);
        WriteFeedHistory();
    }
    public void AddProductToMerkliste(){
        ReadMerkliste();
        myMerkliste.AddMerklisteElement(player.selectedScan);
        WriteMerkliste();
    }
    public void AddProductToMerkliste(string newString){
        ReadMerkliste();
        myMerkliste.AddMerklisteElement(newString);
        Debug.Log(myMerkliste.GetLength());
        WriteMerkliste();
    }

    /**
        Save and Reset PlayerData Functions
    */
    public void SavePlayerData(){
        string jsonString= JsonUtility.ToJson(player);
        Debug.Log(player.playerDataPath);
        File.WriteAllText(player.playerDataPath, jsonString);
    }

    public void ReadPlayerData(){
        if(File.Exists(player.playerDataPath)){
            string jsonText = System.IO.File.ReadAllText(player.playerDataPath);
            Player tmpPlayer = JsonUtility.FromJson<Player>(jsonText);
            player=tmpPlayer;
        }else{
            SavePlayerData();
        }

    }

    public void ResetPlayerData(){
        ReadHistory();
        myScanControl.ClearScanList();
        WriteHistory();

        ReadSearchResults();
        myScanControl.ClearScanList();
        WriteSearchResults();

        ReadComfortFood();
        myScanControl.ClearScanList();
        WriteComfortFood();

        ReadFeedHistory();
        myScanControl.ClearScanList();
        WriteFeedHistory();

        ReadMerkliste();
        myMerkliste.ClearScanList();
        WriteMerkliste();

        Player tmpPlayer= new Player();
        player=tmpPlayer;
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

    public string GetAvgEcoPastSevenDays(){
        return myScanControl.GetAvgEcoPastSevenDays();
    }
    
    public string GetAvgNutriPastSevenDays(){
        return myScanControl.GetAvgNutriPastSevenDays();
    }

    public void SortListBestEcoFirst(){
        myScanControl.SortListBestEcoFirst();
    }

}
