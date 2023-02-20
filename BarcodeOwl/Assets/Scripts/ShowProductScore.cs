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

    public ScanListControl myScanListControl;
    public OpenPanel openPanel;
    
    // Start is called before the first frame update
    void Start(){
        myScanListControl.readScanList();
        FillText();
    }

    void FillText()
    {
       productNameText.text=myScanListControl.GetLatestScan().product.product_name;
       barCodeText.text=myScanListControl.GetLatestScan().code;
       ecoScoreText.text=myScanListControl.GetLatestScan().product.ecoscore_grade;
       nutriScoreText.text=myScanListControl.GetLatestScan().product.nutriscore_grade;
      // nutrimentText.text=myScanListControl.GetLatestScan().product.product_name;
       openPanel.PanelOpener();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
