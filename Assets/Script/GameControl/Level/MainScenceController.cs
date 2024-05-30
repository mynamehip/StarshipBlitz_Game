using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenceController : MonoBehaviour
{
    public GameObject settingPopup, achivementPopup;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSetting()
    {
        settingPopup.SetActive(true);
    }

    public void CloseSetting()
    {
        settingPopup.SetActive(false);
    }

    public void OpenAchivement()
    {
        if(achivementPopup.activeSelf == true)
        {
            achivementPopup.SetActive(false);
        }
        else
        {
            achivementPopup.SetActive(true);
        }
    }
}
