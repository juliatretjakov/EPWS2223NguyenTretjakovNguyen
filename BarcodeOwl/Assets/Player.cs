using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;

public class Player{
    private string name;
    public string historyPath="Assets\\Resources\\historyJSON.txt";
    public string searchResultPath="Assets\\Resources\\tmpSearchResultJSON.txt";
    public string comfortFoodPath="Assets\\Resources\\comfortFoodJSON.txt";
    public string feedHistoryPath="Assets\\Resources\\feedHistorySON.txt";

    public string GetName(){
        return name;
    }
/*
    public string GetHistoryPath(){
        return historyPath;
    }

        public string GetSearchResultPath(){
        return tmpSearchResultPath;
    }

        public string GetComfortFoodPath(){
        return comfortFoodPath;
    }
    */
}
