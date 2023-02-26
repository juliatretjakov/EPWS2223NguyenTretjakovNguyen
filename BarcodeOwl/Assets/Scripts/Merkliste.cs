using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Globalization;
using OpenFoodFactsProduct;


   [System.Serializable]
    public class Merkliste{

        public MerklisteElement[] merkliste;

        public MerklisteElement GetProduct(int i){
            return merkliste[i];
        }

        public int GetLength(){
            return merkliste.Count();  
        }


        public void AddMerklisteElement(Scan newScan){
            MerklisteElement newElement= new MerklisteElement(newScan);
            //newItem.scanTime=DateTime.Now.ToString("f",CultureInfo.GetCultureInfo("de-DE"));
            int size= GetLength();
            Debug.Log(size);
            MerklisteElement[] tmp= new MerklisteElement[size+1];
            if(!isEmpty()){
                for (int i=0;i<size;i++){
                    tmp[i]=merkliste[i];
                }
                tmp[size]=newElement;
                merkliste=tmp;
            }else{
                tmp[0]=newElement;
                merkliste=tmp;
            }
        }

        public void AddMerklisteElement(string newProductName){
            MerklisteElement newElement= new MerklisteElement(newProductName);
            //newItem.scanTime=DateTime.Now.ToString("f",CultureInfo.GetCultureInfo("de-DE"));
            int size= GetLength();
            MerklisteElement[] tmp= new MerklisteElement[size+1];
            if(!isEmpty()){
                for (int i=0;i<size;i++){
                    tmp[i]=merkliste[i];
                }
                tmp[size]=newElement;
                merkliste=tmp;
            }else{
                tmp[0]=newElement;
                merkliste=tmp;
            }
        }

        public void ClearScanList(){
            MerklisteElement[] tmp= new MerklisteElement[0];
            merkliste = tmp;
        }

        public bool isEmpty(){
            if(GetLength()<=0){
                return true;
            }else return false;
        }
    }
