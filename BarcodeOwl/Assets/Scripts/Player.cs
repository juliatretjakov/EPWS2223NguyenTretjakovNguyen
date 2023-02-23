using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using OpenFoodFactsProduct;

public class Player{
    private string name;
    public string historyPath="Assets\\Resources\\historyJSON.txt";
    public string searchResultPath="Assets\\Resources\\tmpSearchResultJSON.txt";
    public string comfortFoodPath="Assets\\Resources\\comfortFoodJSON.txt";
    public string feedHistoryPath="Assets\\Resources\\feedHistoryJSON.txt";
    private readonly int drinksSize=10;
    public Queue <DateTime> drinks=new Queue<DateTime>();
    public List <string> Merkliste= new List<String>();
    
    public string GetName(){
        return name;
    }

    public void addDrink(){
        if(drinks.Count<=drinksSize){
            drinks.Enqueue(DateTime.Now);
        }else{
            drinks.Dequeue();
            drinks.Enqueue(DateTime.Now);
        }
    }

    public int getDrinksToday(){
        int count=0;
        Debug.Log("hey ich bims");
        if(drinks!=null){
            foreach (DateTime element in drinks){
                Debug.Log(element.ToString());
                if(DateTime.Compare(element,DateTime.Today)>=0){
                    Debug.Log("here we go");
                    count++;
                }
            }
        }
        return count;
    }

    public void AddNote(string newNote){
        Merkliste.Insert(0,newNote);
    }

    public void RemoveNoteAt(int index){
        Merkliste.RemoveAt(index);
    }


}
