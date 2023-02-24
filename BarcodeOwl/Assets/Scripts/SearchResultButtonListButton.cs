using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Networking;
using OpenFoodFactsProduct;


public class SearchResultButtonListButton : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text myText;
    [SerializeField]
    private Image myImage;
    [SerializeField]
    private Scan myScan;
    public SearchResultsButtonListControl myButtonListControl;
    // Start is called before the first frame update
    public void SetText(string textString)
    {
        myText.text=textString;
    }

    public void SetTexture(string url){
        StartCoroutine(GetTexture(url));
    }

    IEnumerator GetTexture(string url) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success){
            Debug.Log(request.error);
        }
        else {
            Texture2D myTexture=  ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite newSprite=Sprite.Create(myTexture,new Rect(0,0,myTexture.width,myTexture.height),new Vector2(0.5f,0.5f));
            myImage.overrideSprite=newSprite;
        }
    }

    public void SetScan(Scan newScan){
        myScan=newScan;
    }

    public void OnClick(){
        myButtonListControl.ButtonClicked(myScan);
    }

}
