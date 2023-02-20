using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;



namespace OpenFoodFactsProduct{
    [System.Serializable]
    public class Scan{
            public string code;
            public Product product;
            public string scanTime;

            public Scan(string code,Product product,string scanTime){
                this.product=product;
                this.code=code;
                this.scanTime=scanTime;
            }

            public Scan(string code,Product product){
                DateTime currentTime=DateTime.Now;
                this.product=product;
                this.code=code;
                this.scanTime=currentTime.ToString("f",CultureInfo.GetCultureInfo("de-DE"));
            }

            public override string ToString(){
                return code+" "+product.ToString()+""+scanTime;
            }
        }

        [System.Serializable]
        public class Product{
            public string product_name;
            public string ecoscore_grade;
            public string nutriscore_grade;

            public Product(string product_name, string ecoscore_grade,string nutriscore_grade){
                this.product_name=product_name;
                this.ecoscore_grade=ecoscore_grade;
                this.nutriscore_grade=nutriscore_grade;
            }

            public override string ToString(){
                return product_name+" "+ecoscore_grade+" "+nutriscore_grade;
            }
        }
}
