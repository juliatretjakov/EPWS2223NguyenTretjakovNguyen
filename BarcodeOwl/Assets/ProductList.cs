using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace OpenFoodFactsProduct{
   [System.Serializable]
    public class ProductList{ 
    //employees is case sensitive and must match the string "employees" in the JSON.
        public Product[] product;
    
        public Product getProduct(int i){
            return product[i];
        }

        public int getLength(){
            Debug.Log(product.Count());
            return product.Count();
        }
    }
}
