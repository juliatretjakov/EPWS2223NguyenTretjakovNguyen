using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ManualSearch : MonoBehaviour
{
	public ManualSearchControl mySearchControl;
	public TMP_InputField searchInputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	 void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return)){
			ReadInputString();
		}
    }

	public void ReadInputString(){
		mySearchControl.SendSearchRequest(searchInputField.text,1);
	}

}
