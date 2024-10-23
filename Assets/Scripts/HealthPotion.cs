using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    public Transform Player;
    public float detectionRadius = 2.5f;
    //public TextMeshProUGUI score;

    private Renderer Renderer;
    private bool isPassed = false;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isPassed && Vector3.Distance(Player.position, transform.position) <= detectionRadius)
        {

            isPassed = true;
            if (PlayerHealth.health <= 5)
            {

                PlayerHealth.health += 5;
            }
            else
            {
                PlayerHealth.health = 10;
            }
            Debug.Log("Destroying Potion");
            Destroy(gameObject, 0f);
            if (true)
            {
                //Color newColor;
                //if (ColorUtility.TryParseHtmlString("#FF000080", out newColor)) // Hex code with alpha (80 = 50% opacity)
                //{
                //    Renderer.material.color = newColor;
                //}
                
                
            }

            
        }
    }
}
