using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController p;
    public GameObject pauseMenu;
    public GameObject endMenu;
    public int enemyGroupNumber;
    public List<Sprite> star;
    public Skin skin;
    List<Sprite> sprites;
    public Player player;
    int skinIndex;

    int enemyGroupCleared = 0;

    void Start()
    {
        if(skin != null)
        {
            sprites = skin.GetSkin();
            skinIndex = player.currentSprite;
        }
    }

    void Update()
    {
    }

    public void Forward()
    {
        if (skinIndex < sprites.Count - 1)
        {
            skinIndex++;
        }
        else
        {
            skinIndex = 0;
        }
        PlayerData.instance.SetSkin(skinIndex);
        PlayerData.instance.SetWeaponType(skinIndex + 1);
        player.SetSkin(skinIndex);
    }
    public void Backward()
    {
        if (skinIndex > 0)
        {
            skinIndex--;
        }
        else
        {
            skinIndex = sprites.Count - 1;
        }
        PlayerData.instance.SetSkin(skinIndex);
        PlayerData.instance.SetWeaponType(skinIndex + 1);
        player.SetSkin(skinIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void DeadPlayer()
    {
        StartCoroutine(EndGame());
    }

    public void Win()
    {
        StartCoroutine(CountDownToWin());
    }

    IEnumerator CountDownToWin()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(WinGame());
    }

    public void ClearedEnemy()
    {
        enemyGroupCleared++;
        if (enemyGroupCleared == enemyGroupNumber)
        {
            StartCoroutine(WinGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        AudioController.instance.PlayMusic("lose");
        endMenu.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator WinGame()
    {
        Transform childScore = endMenu.transform.GetChild(4);
        if (p.heart == 5)
        {
            for(int i = 0; i < childScore.transform.childCount; i++)
            {
                Transform childStar = childScore.transform.GetChild(i);
                Image starImg = childStar.GetComponent<Image>();
                starImg.sprite = star[1];
            }
            SaveScore('3');
        }
        else if(p.heart < 5 && p.heart > 2)
        {
            for (int i = 0; i < childScore.transform.childCount; i++)
            {
                Transform childStar = childScore.transform.GetChild(i);
                Image starImg = childStar.GetComponent<Image>();
                starImg.sprite = star[1];
                if(i == 2)
                {
                    starImg.sprite = star[0];
                }
            }
            SaveScore('2');
        }
        else
        {
            for (int i = 0; i < childScore.transform.childCount; i++)
            {
                Transform childStar = childScore.transform.GetChild(i);
                Image starImg = childStar.GetComponent<Image>();
                starImg.sprite = star[0];
                if (i == 0)
                {
                    starImg.sprite = star[1];
                }
            }
            SaveScore('1');
        }
        yield return new WaitForSeconds(1);
        endMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void SaveScore(char c)
    {
        int scenceIndex = SceneManager.GetActiveScene().buildIndex;
        string scenceScore = PlayerPrefs.GetString("ScenceScore");
        char[] scenceScoreArray = scenceScore.ToCharArray();
        scenceScoreArray[scenceIndex - 2] = c;
        scenceScore = new string(scenceScoreArray);
        PlayerPrefs.SetString("ScenceScore", scenceScore);
    }
}
