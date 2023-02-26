using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using OpenFoodFactsProduct;

public class Player{
    private string name;
    public string playerDataPath=Application.persistentDataPath+"/playerDataJSON.txt";
    public string historyPath=Application.persistentDataPath+"/historyJSON.txt";
    public string searchResultPath=Application.persistentDataPath+"/tmpSearchResultJSON.txt";
    public string comfortFoodPath=Application.persistentDataPath+"/comfortFoodJSON.txt";
    public string feedHistoryPath=Application.persistentDataPath+"/feedHistoryJSON.txt";
    public string merklistePath=Application.persistentDataPath+"/merklisteJSON.txt";
    private static int drinksSize=100;
    public Queue <DateTime> drinks=new Queue<DateTime>();
    public Scan compareScan1;
    public Scan compareScan2;
    public Scan selectedScan;
    public ScoreConverter scoreConverter= new ScoreConverter();


    //Owl Related Attributes
    public double hungerCap=10.0;
    public double currentHunger=0.0;
    public DateTime lastFeedingTime=DateTime.MinValue;
    public double lastHungerAmount=0.0;
    public bool sleeps=false;
    
    public void FeedOwl(){
        Debug.Log(selectedScan.product.product_name);
        currentHunger+=scoreConverter.GetScoreAsNumber(selectedScan.product.nutriscore_grade);
        Debug.Log(currentHunger);
        if(currentHunger>10){
            currentHunger=10;
        }
        lastFeedingTime=DateTime.Now;
        lastHungerAmount=currentHunger;
    }

    public void UpdateHunger(){
        TimeSpan interval = DateTime.Now.Subtract(lastFeedingTime);
        int diff = (int) interval.TotalMinutes;
        currentHunger=lastHungerAmount-diff*(100/60);
        if(currentHunger<0){
            currentHunger=0;
        }
    }

    public double GetHungerPercentage(){
        UpdateHunger();
        return Math.Floor(currentHunger/hungerCap)*100;
    }
    
    public bool isHungry(){
        return currentHunger<3;
    }

    public string GetName(){
        return name;
    }

    public void SetSelectedScan(Scan newScan){
        selectedScan=newScan;
    }

    public void AddDrink(){
        if(drinks.Count<=drinksSize){
            drinks.Enqueue(DateTime.Now);
        }else{
            drinks.Dequeue();
            drinks.Enqueue(DateTime.Now);
        }
    }

    public void AddCompare(Scan newScan){
        if(compareScan1.code!=newScan.code&&compareScan2.code!=newScan.code){
            if(compareScan1.code==null||compareScan1.code.Equals("")){ 
                compareScan1=newScan;
            }else if(compareScan2.code==null||compareScan2.code.Equals("")){
                compareScan2=newScan;
            }
        }

    }

    public int GetDrinkCountToday(){
        int count=0;
        if(drinks!=null){
            foreach (DateTime element in drinks){
                Debug.Log(element.ToString());
                if(DateTime.Compare(element,DateTime.Today)>=0){
                    count++;
                }
            }
        }
        return count;
    }
}
