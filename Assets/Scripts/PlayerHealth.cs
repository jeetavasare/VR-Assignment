using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using TMPro.EditorUtilities;

public class PlayerHealth : MonoBehaviour

{

    public TextMeshProUGUI playerHealth;
    public static int health = 10;
    public static int playerScore = 0;
    private bool onDeathScreen = false;
    public GameObject playerRig;
    public GameObject DeathScreenPanel;
    public TextMeshProUGUI ScoreCard;

    // Start is called before the first frame update
    void Start()
    {
        DeathScreenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCard.text = playerScore.ToString();
        playerHealth.text = health.ToString();
        if(health < 6)
        {
            playerHealth.color = Color.yellow;

        }
        else if (health <= 2)
        {
            playerHealth.color = Color.red;
        }
        else
        {
            playerHealth.color = Color.green;
            
        }
        if (health <= 0)
        {
            //SceneManager.LoadScene("GameOver");
            //UnityEngine.Debug.Log("GAME OVER!!!");
            if (!onDeathScreen)
            {
                DeathScreen();

            }
        }
    }


    void DeathScreen()
    {
        onDeathScreen = true;
        DeathScreenPanel.SetActive(true);
    }

    public void Respwawn()
    {
        DeathScreenPanel.SetActive(false);
        health = 10;
        onDeathScreen=false;
        playerScore = 0;
        ScoreCard.text = playerScore.ToString();
        playerRig.transform.position = new Vector3(348.940002f,-5.67999983f,64.211998f);

    }
}
