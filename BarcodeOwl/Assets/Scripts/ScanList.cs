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


        private bool isEmpty(){
            if(GetLength()<=0){
                return true;
            }else return false;
        }
    }
}
