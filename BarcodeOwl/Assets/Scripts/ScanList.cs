using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Globalization;

namespace OpenFoodFactsProduct{
   [System.Serializable]
    public class ScanList{

        public Scan[] scan;

        public Scan GetProduct(int i){
            return scan[i];
        }

        public int GetLength(){
            Debug.Log(scan.Count());
            return scan.Count();  
        }

        public Scan GetLatestScan(){
            return scan[GetLength()-1];
        }


        public void AddProduct(Scan newItem){
            newItem.scanTime=DateTime.Now.ToString("f",CultureInfo.GetCultureInfo("de-DE"));
            Debug.Log("oldSize="+GetLength());
            int size= GetLength();
            Scan[] tmp= new Scan[size+1];
            if(!isEmpty()){
                for (int i=0;i<size;i++){
                    tmp[i]=scan[i];
                }
                tmp[size]=newItem;
                scan=tmp;
                Debug.Log("newSize="+GetLength());
            }else{
                tmp[0]=newItem;
                scan=tmp;
            }
        }

        public void SetListTo(SearchResult newList){
            Scan[] tmp=new Scan[newList.products.Count()];
            for(int i=0;i<newList.products.Count();i++){
                Scan tmpScan=new Scan(newList.products[i].code,newList.products[i]);
                tmp[i]=tmpScan;
            }
            scan=tmp;
        }

        public void ClearScanList(){
            Scan[] tmp= new Scan[0];
            scan = tmp;
        }

        public int GetFeedCountToday(){
            int count=0;
            if(!isEmpty()){
                for(int i=GetLength()-1;i>=0;i--){
                    if(DateTime.Compare(scan[i].GetScanTimeAsDateTime(),DateTime.Today)>=0){
                        count++;
                    }
                }
            }
            return count;
        }


        private bool isEmpty(){
            if(GetLength()<=0){
                return true;
            }else return false;
        }
    }
}
