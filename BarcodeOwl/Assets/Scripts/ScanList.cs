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
        ScoreConverter convertScore;

        public Scan GetProduct(int i){
            return scan[i];
        }

        public int GetLength(){
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
                    }else{
                        break;
                    }
                }
            }
            return count;
        }

        public string GetAvgEcoPastSevenDays(){
            double count=0;
            double total=0;
            double avg; 
            if(!isEmpty()){
                for(int i=GetLength()-1;i>=0;i--){
                    if(DateTime.Compare(scan[i].GetScanTimeAsDateTime(),DateTime.Today.AddDays(-7))>=0){
                        int scoreNumber=convertScore.GetScoreAsNumber(scan[i].product.ecoscore_grade);
                        count += scoreNumber;
                        if(scoreNumber!=0){
                            total ++;
                        }
                    }else{
                        break;
                    }
                }
            }
            if(total>0){
                avg=Math.Floor(count/total);
                int result=Convert.ToInt32(avg);
                return convertScore.GetNumberToScore(result);
            }else{
                return "";
            }
        }

        public string GetAvgNutriPastSevenDays(){
            double count=0;
            double total=0;
            double avg; 
            if(!isEmpty()){
                for(int i=GetLength()-1;i>=0;i--){
                    if(DateTime.Compare(scan[i].GetScanTimeAsDateTime(),DateTime.Today.AddDays(-7))>=0){
                        int scoreNumber=convertScore.GetScoreAsNumber(scan[i].product.nutriscore_grade);
                        count += scoreNumber;
                        Debug.Log(scoreNumber);
                        if(scoreNumber!=0){
                            total ++;
                        }
                    }else{
                        break;
                    }
                }
            }
            if(total>0){
                avg=Math.Floor(count/total);
                int result=Convert.ToInt32(avg);
                return convertScore.GetNumberToScore(result);
            }else{
                return "";
            }

        }

        public void SortListBestEcoFirst(){
            int n = GetLength();
            for (int i = 0; i < n - 1; i++){
                for (int j = 0; j < n - i - 1; j++){
                    if (convertScore.GetScoreAsNumber(scan[j].product.ecoscore_grade) < convertScore.GetScoreAsNumber(scan[j + 1].product.ecoscore_grade)){
                        // swap temp and arr[i]
                        Scan temp = scan[j];
                        scan[j] = scan[j + 1];
                        scan[j + 1] = temp;
                    }
                }
            }
        }

        private bool isEmpty(){
            if(GetLength()<=0){
                return true;
            }else return false;
        }
    }
}
