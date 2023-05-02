using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    private GameManager gameManager;
    public int gemNum;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ruby"))
        {
            gameManager.RubyTracker(gemNum);
        }

        if (other.CompareTag("Emerald"))
        {
            gameManager.EmeraldTracker(gemNum);
        }

        if (other.CompareTag("Sapphire"))
        {
            gameManager.SapphireTracker(gemNum);
        }
    }
}
