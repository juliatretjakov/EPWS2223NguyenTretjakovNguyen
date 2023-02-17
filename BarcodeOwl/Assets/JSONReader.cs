using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenFoodFactsProduct;
using TMPro;

namespace JSON{
public class JSONReader : MonoBehaviour
    {
        public ProductList myProductList;
        public TextAsset textJSON;

        // Start is called before the first frame update
        void Start()
        {
           myProductList = JsonUtility.FromJson<ProductList>(textJSON.text);
        }

        public Product getProduct(int i){
            return myProductList.getProduct(i);
        }

        public int getLength(){
            return myProductList.getLength();
        }

    }
}
