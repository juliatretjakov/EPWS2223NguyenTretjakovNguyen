using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreConverter
{
    // Start is called before the first frame update
        public int GetScoreAsNumber(string score){
            if(score.ToUpper().Equals("A")){
                return 5;
            }else if(score.ToUpper().Equals("B")){
                return 4;
            }else if(score.ToUpper().Equals("C")){
                return 3;
            }else if(score.ToUpper().Equals("D")){
                return 2;
            }else if(score.ToUpper().Equals("E")){
                return 1;
            }else{
                return 0;
            }
        }

        public string GetNumberToScore(int number){
            if(number==5){
                return "A";
            }else if(number==4){
                return "B";
            }else if(number==3){
                return "C";
            }else if(number==2){
                return "D";
            }else if(number==1){
                return "E";
            }else{
                return "";
            }
        }
}
