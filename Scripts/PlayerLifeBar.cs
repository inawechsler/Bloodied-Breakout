using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBar : MonoBehaviour
{
    [SerializeField] private Image lifebar;
    [SerializeField] public PlayerHealth player;
    private float playerHealth;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerHealth = player.health / 100;

            lifebar.fillAmount = playerHealth;


            if (playerHealth <= 1 && playerHealth > 0.8)
            {
                lifebar.color = Color.green;
            }

            if (playerHealth <= 0.8 && playerHealth > 0.3)
            {
                lifebar.color = Color.yellow;
            }

            if (playerHealth <= 0.3)
            {
                lifebar.color = Color.red;
            }

        }
    }
}
