using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;
using TMPro;
using System.IO;


public class MerklisteControl : MonoBehaviour
{
        public Merkliste myMerkliste;


        // Start is called before the first frame update
        void Start()
        {
           
        }

        public void ReadScanList(string path){
            if(File.Exists(path)){
            string jsonText = System.IO.File.ReadAllText(path);
            myMerkliste = JsonUtility.FromJson<Merkliste>(jsonText);
            }else{
                WriteScanList(path);
            }

        }

        public MerklisteElement GetProduct(int i){
            return myMerkliste.GetProduct(i);
        }

        public int GetLength(){
            return myMerkliste.GetLength();
        }

        public void AddMerklisteElement(Scan newItem){
            myMerkliste.AddMerklisteElement(newItem);
        }

        public void AddMerklisteElement(string newString){
            myMerkliste.AddMerklisteElement(newString);
        }

        public void ClearScanList(){
            myMerkliste.ClearScanList();
        }

        public bool isEmpty(){
            return myMerkliste.isEmpty();
        }

        public void WriteScanList(string path){
            string jsonString= JsonUtility.ToJson(myMerkliste);
            File.WriteAllText(path, jsonString);
        }
}