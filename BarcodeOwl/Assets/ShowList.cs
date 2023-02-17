using BarcodeScanner;
using BarcodeScanner.Scanner;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wizcorp.Utils.Logger;
using System.Net;
using System.IO;
using TMPro;
using JSON;

public class ShowList : MonoBehaviour
{
    public TMP_Text DialogText;
    // Start is called before the first frame update
    public void Start()
    {
        DialogText.text = "hi";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
