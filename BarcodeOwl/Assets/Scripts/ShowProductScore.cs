using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OpenFoodFactsProduct;

public class ShowProductScore : MonoBehaviour
{   
    public TMP_Text productNameText;
    public TMP_Text barCodeText;
    public TMP_Text ecoScoreText;
    public TMP_Text nutriScoreText;
    public TMP_Text nutrimentText;

    public PlayerControl playerData;
    public OpenPanel openPanel;
    public string historyPath;
    
    // Start is called before the first frame update
    void Start(){
        playerData.readHistory();
        FillText();
    }

    void FillText()
    {
       productNameText.text=playerData.historyControl.GetLatestScan().product.product_name;
       barCodeText.text=playerData.historyControl.GetLatestScan().code;
       ecoScoreText.text=playerData.historyControl.GetLatestScan().product.ecoscore_grade;
       nutriScoreText.text=playerData.historyControl.GetLatestScan().product.nutriscore_grade;
      // nutrimentText.text=myScanListControl.GetLatestScan().product.product_name;
       openPanel.PanelOpener();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
