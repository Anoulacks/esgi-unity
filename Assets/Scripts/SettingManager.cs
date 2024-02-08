using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public GameObject popup;
    public void OpenSetting() {
        if (popup != null) {
            popup.SetActive(true);
        }
    }
}
