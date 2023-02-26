using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;

[System.Serializable]
public class MerklisteElement
{   
    public Scan myScan;
    public bool toggle;

    public MerklisteElement(Scan newScan){
        this.myScan=newScan;
        this.toggle=false;
    }
    public MerklisteElement(string product_name){
        Product tmpProduct=new Product();
        this.myScan=new Scan("",tmpProduct);
        this.myScan.product.product_name=product_name;
        this.toggle=false;
    }
}

