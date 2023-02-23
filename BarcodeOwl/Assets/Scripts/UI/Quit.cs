using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quit : MonoBehaviour
{
    public PlayerControl playerData;
    // Start is called before the first frame update
    public void clickQuit()
    {
        playerData.savePlayerData();
        Application.Quit();
    }
}
