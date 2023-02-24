using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadScoreImage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadImage(string score,Image scoreImage){
        if(score.ToUpper()=="A"||score.ToUpper()=="B"||score.ToUpper()=="C"||score.ToUpper()=="D"||score.ToUpper()=="E"){
            string path= "Assets\\Textures\\Score\\Score_"+score.ToUpper()+".png";
            Debug.Log(path);
           
            Texture2D myTexture;
            byte[] fileData;
            Sprite newSprite ;
 
            if (File.Exists(path)){
                fileData = File.ReadAllBytes(path);
                myTexture = new Texture2D(2, 2);
                myTexture.LoadImage(fileData); 
                newSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height),new Vector2(0,0));
                scoreImage.overrideSprite=newSprite;
            }
        }

    }
}
