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
    public Button restartButton;
    public GameObject gameOverScreen;

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
        gameOverScreen.gameObject.SetActive(false);
        ruby = 0;
        emerald = 0;
        sapphire = 0;
        RubyTracker(0);
        EmeraldTracker(0);
        SapphireTracker(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Tracks health

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

        // Ends game when health runs out

        if (health == 0)
        {
            GameOver();
        }
    }

    // Damages the player

    public void DamagePlayer()
    {
        health -= 1;
    }

    // Tracks the gems

    public void RubyTracker(int gemCount)
    {
        ruby += gemCount;
        rubyText.text = ": " + ruby;
    }

    public void EmeraldTracker(int gemCount)
    {
        emerald += gemCount;
        emeraldText.text = ": " + emerald;
    }

    public void SapphireTracker(int gemCount)
    {
        sapphire += gemCount;
        sapphireText.text = ": " + sapphire;
    }

    // Restarts the game

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Activates the game over screen

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
