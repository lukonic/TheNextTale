using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public static int health; //Needed for saving state
    public int numberOfHearts;
    public bool invincibility;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Saving>().Load();
        numberOfHearts = startingHealth;
        health = startingHealth;
        invincibility = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > numberOfHearts)
        {
            currentHealth = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        // somehow show that the damage is taken
    }

    public void TakeDamage(int damage)
    {
        if (invincibility == false)
        {
            currentHealth = currentHealth - damage;
            health = currentHealth;
        }
    }
}
