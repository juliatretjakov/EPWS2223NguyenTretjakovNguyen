using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenFoodFactsProduct{
    [System.Serializable]
    public class Product{
            public string name;
            public int eco;
            public int nutri;

            public string toString(){
                return name+" "+eco+" "+nutri;
            }
        }
}
