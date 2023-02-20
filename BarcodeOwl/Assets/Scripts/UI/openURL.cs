using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openURL : MonoBehaviour
{
    // Start is called before the first frame update
    public void openURLinBrowser()
    {
        Application.OpenURL("http://unity3d.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
