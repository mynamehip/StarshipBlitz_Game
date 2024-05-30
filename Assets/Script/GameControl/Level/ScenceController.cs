using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScenceController : MonoBehaviour
{
    List<GameObject> scence = new List<GameObject>();
    public List<GameObject> achivementItem;
    public List<Achievement> achievements;
    public Sprite star;

    string scenceScore;
    string achivementScore;

    void Start()
    {
        Scence s = GetComponent<Scence>();
        if(s != null )
        {
            scence = s.GetScence();
        }
        if (SceneManager.GetActiveScene().name != "Main" && SceneManager.GetActiveScene().name != "LevelSeclection")
        {
            AudioController.instance.PlayBackgroundMusic();
        }
        scenceScore = PlayerPrefs.GetString("ScenceScore");
        if(scenceScore == "")
        {
            PlayerPrefs.SetString("ScenceScore", "0000000000");
            scenceScore = PlayerPrefs.GetString("ScenceScore");
        }
        achivementScore = PlayerPrefs.GetString("Achivement");
        if (achivementScore == "")
        {
            PlayerPrefs.SetString("Achivement", "00000");
            achivementScore = PlayerPrefs.GetString("Achivement");
        }
        ShowScore();
        ShowAchivement();
        CheckGun();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            PlayerPrefs.SetString("ScenceScore", "0000000000");
            Debug.Log(0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerPrefs.SetString("ScenceScore", "0030010002");
            Debug.Log(1);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            PlayerPrefs.SetString("Achivement", "01010");
            Debug.Log(2);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            PlayerPrefs.SetString("Achivement", "00000");
            Debug.Log(3);
        }
    }

    void CheckGun()
    {
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "LevelSeclection")
        {
            PlayerData.instance.SetWeaponLevel(0);
        }
    }

    public void ToScence(int index)
    {
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "LevelSeclection")
        {
            if(index > 1)
            {
                AudioController.instance.StopMusic();
            }

        }
        else
        {
            if (index == 1)
            {
                AudioController.instance.PlayMainMusic();
            }
            else
            {
                AudioController.instance.StopMusic();
            }
        }
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        int curentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curentIndex);
        Time.timeScale = 1;
    }

    public void NextGame()
    {
        int curentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curentIndex + 1);
        Time.timeScale = 1;
    }

    void ShowScore()
    {
        for (int i = 0; i < scence.Count; i++)
        {
            Transform child = scence[i].transform.GetChild(1);
            if (scenceScore[i] == '3')
            {
                for (int j = 0; j < child.transform.childCount; j++)
                {
                    Transform childStar = child.transform.GetChild(j);
                    Image starImg = childStar.GetComponent<Image>();
                    starImg.sprite = star;
                }
            }
            else if (scenceScore[i] == '2')
            {
                for (int j = 0; j < child.transform.childCount - 1; j++)
                {
                    Transform childStar = child.transform.GetChild(j);
                    Image starImg = childStar.GetComponent<Image>();
                    starImg.sprite = star;
                }
            }
            else if (scenceScore[i] == '1')
            {
                Transform childStar = child.transform.GetChild(0);
                Image starImg = childStar.GetComponent<Image>();
                starImg.sprite = star;
            }
        }
    }
    void ShowAchivement()
    {
        for (int i = 0; i < achivementItem.Count; i++)
        {
            if (achivementScore[i] == '1')
            {
                Transform child0 = achivementItem[i].transform.GetChild(0);
                Image starImg = child0.GetComponent<Image>();
                starImg.sprite = star;
            }
            Transform child1 = achivementItem[i].transform.GetChild(1);
            Text achivementName = child1.GetComponent<Text>();
            achivementName.text = achievements[i].GetName();
            Transform child2 = achivementItem[i].transform.GetChild(2);
            Text achivementDes = child2.GetComponent<Text>();
            achivementDes.text = achievements[i].GetDescription();
        }
    }
}
