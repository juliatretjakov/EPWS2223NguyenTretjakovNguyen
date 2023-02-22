using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;
using TMPro;
using System.IO;

namespace OpenFoodFactsProduct{
public class ScanListControl : MonoBehaviour
    {
        public ScanList myScanList;


        // Start is called before the first frame update
        void Start()
        {
           
        }

        public void readScanList(string path){
            string jsonText = System.IO.File.ReadAllText(path);
            myScanList = JsonUtility.FromJson<ScanList>(jsonText);
        }

        public Scan GetProduct(int i){
            return myScanList.GetProduct(i);
        }

        public Scan GetLatestScan(){
            return myScanList.GetLatestScan();
        }


        public int GetLength(){
            return myScanList.GetLength();
        }

        public void AddProduct(Scan newItem){
            myScanList.AddProduct(newItem);
        }

        public void setListTo(SearchResult newList){
            myScanList.setListTo(newList);
        }

        public void ClearScanList(){
            myScanList.ClearScanList();
        }

        public int getScanCountToday(){
           return myScanList.getScanCountToday();
        }

        public void writeScanList(string path){
            string jsonString= JsonUtility.ToJson(myScanList);
            File.WriteAllText(path, jsonString);
        }

    }
}