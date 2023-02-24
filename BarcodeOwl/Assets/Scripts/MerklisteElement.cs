using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerklisteElement
{
    public string product_name;
    public string barCode;
    public bool toggle;

    public MerklisteElement(string product_name){
        this.product_name=product_name;
        this.barCode="";
        this.toggle=false;
    }
    public MerklisteElement(string product_name,string barCode){
        this.product_name=product_name;
        this.barCode=barCode;
        this.toggle=false;
    }
}

