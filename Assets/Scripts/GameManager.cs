using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject titleScreen;
    public GameObject musicBox;
    public Button startButton;
    public GameObject spawnManager;
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private int ruby;
    private int emerald;
    private int sapphire;
    public TextMeshProUGUI rubyText;
    public TextMeshProUGUI emeraldText;
    public TextMeshProUGUI sapphireText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        musicBox.gameObject.SetActive(true);
        spawnManager.gameObject.SetActive(true);
        ruby = 0;
        emerald = 0;
        sapphire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void DamagePlayer()
    {
        health -= 1;
    }

    public void RubyTracker()
    {
        ruby += 1;
        rubyText.text = ": " + ruby;
    }

    public void EmeraldTracker()
    {
        emerald += 1;
        emeraldText.text = ": " + emerald;
    }

    public void SapphireTracker()
    {
        sapphire += 1;
        sapphireText.text = ": " + sapphire;
    }
}
