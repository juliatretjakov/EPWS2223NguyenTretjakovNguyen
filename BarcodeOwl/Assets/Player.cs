using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{
    private string name;
    public string historyPath="Assets\\Resources\\historyJSON.txt";
    public string searchResultPath="Assets\\Resources\\tmpSearchResultJSON.txt";
    public string comfortFoodPath="Assets\\Resources\\comfortFoodJSON.txt";


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
