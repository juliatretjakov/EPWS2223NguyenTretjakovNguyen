using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using OpenFoodFactsProduct;

public class Player{
    private string name;
    public string playerDataPath="Assets\\Resources\\playerDataJSON.txt";
    public string historyPath="Assets\\Resources\\historyJSON.txt";
    public string searchResultPath="Assets\\Resources\\tmpSearchResultJSON.txt";
    public string comfortFoodPath="Assets\\Resources\\comfortFoodJSON.txt";
    public string feedHistoryPath="Assets\\Resources\\feedHistoryJSON.txt";
    private readonly int drinksSize=10;
    public Queue <DateTime> drinks=new Queue<DateTime>();
    public List <MerklisteElement> Merkliste= new List<MerklisteElement>();
    public Scan selectedScan;
    
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

    public void AddMerklisteElement(string newNote){
        MerklisteElement newElement= new MerklisteElement(newNote);
        Merkliste.Insert(0,newElement);
    }

    public void RemoveNoteAt(int index){
        Merkliste.RemoveAt(index);
    }


}
