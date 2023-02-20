using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenPanel: MonoBehaviour {
    public GameObject AnotherPanel;
    public void PanelOpener() {
        if (AnotherPanel != null) {
            bool isActive = AnotherPanel.activeSelf;
            AnotherPanel.SetActive(!isActive);
        }
    }
}