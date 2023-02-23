using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;

public class PlayerControl : MonoBehaviour
{   public Player player=new Player();
    public ScanListControl historyControl;
    public ScanListControl searchResultsControl;
    public ScanListControl comfortFoodControl;
    public ScanListControl feedHistoryControl;
    
    // Start is called before the first frame update
    void Start()
    {
        readHistory();
        readSearchResults();
        readComfortFood();
        readFeedHistory();
    }

    /**
        read Lists functions
    */
    public void readHistory(){
        historyControl.readScanList(player.historyPath);
    }

    public void readSearchResults(){
        searchResultsControl.readScanList(player.searchResultPath);
    }

    public void readComfortFood(){
        comfortFoodControl.readScanList(player.comfortFoodPath);
    }

    public void readFeedHistory(){
        feedHistoryControl.readScanList(player.feedHistoryPath);
    }

    /**
        write Lists functions
    */
    public void writeHistory(){
        historyControl.writeScanList(player.historyPath);
    }

    public void writeSearchResults(){
        searchResultsControl.writeScanList(player.searchResultPath);
    }

    public void setSearchResults(SearchResult newResults){
        searchResultsControl.setListTo(newResults);
        searchResultsControl.writeScanList(player.searchResultPath);
    }

    public void writeComfortFood(){
        comfortFoodControl.writeScanList(player.comfortFoodPath);
    }

    public void writeFeedHistory(){
        feedHistoryControl.writeScanList(player.feedHistoryPath);
    }

    /**
        add new Item to Lists Functions
    */
    public void addProductToHistory(Scan newItem){
        historyControl.AddProduct(newItem);
    }
    public void addProductToSearchResults(Scan newItem){
        searchResultsControl.AddProduct(newItem);
    }
    public void addProductToComfortFood(Scan newItem){
        comfortFoodControl.AddProduct(newItem);
    }
    public void addProductToFoodHistory(Scan newItem){
        feedHistoryControl.AddProduct(newItem);
    }

    /**
        Save and Reset PlayerData Functions
    */
    public void savePlayerData(){
        writeHistory();
        writeSearchResults();
        writeComfortFood();
        writeFeedHistory();
    }

    public void resetPlayerData(){
        historyControl.ClearScanList();
        searchResultsControl.ClearScanList();
        comfortFoodControl.ClearScanList();
        feedHistoryControl.ClearScanList();
        savePlayerData();
    }

    /**
        otherFunctions
    */
    public int getScanCountToday(){
        return feedHistoryControl.getScanCountToday();
    }
}
