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
    }

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
        historyControl.readScanList(player.historyPath);
    }

    public void writeHistory(){
        historyControl.writeScanList(player.historyPath);
    }

    public void writeSearchResults(SearchResult newResults){
        searchResultsControl.setListTo(newResults);
        searchResultsControl.writeScanList(player.searchResultPath);
    }

    public void writeComfortFood(){
        comfortFoodControl.writeScanList(player.comfortFoodPath);
    }

    public void writeFeedHistory(){
        historyControl.writeScanList(player.historyPath);
    }


    public void addProductToHistory(Scan newItem){
        historyControl.AddProduct(newItem);
    }
    public void addProductToSearchResults(Scan newItem){
        searchResultsControl.AddProduct(newItem);
    }
    public void addProductToComfortFood(Scan newItem){
        comfortFoodControl.AddProduct(newItem);
    }


    public int getScanCountToday(){
        return feedHistoryControl.getScanCountToday();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
