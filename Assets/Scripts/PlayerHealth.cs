using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer sr;

    //255,255,255,255
    [SerializeField]
    private Color normalColor;

    //should be transperant or whatever
    [SerializeField]
    private Color flashColor;

    //change this value from true to false to determine if you should be flashing or not
    private bool flashEffectTrigger;
    [SerializeField]
    private float timeBetweenFlashes;

    public static PlayerHealth instance;

    
    public int maxHP;
    [SerializeField]
    private int currentHP;

    [SerializeField]
    private Image[] hearts;

    [SerializeField]
    private Sprite fullHeart;

    [SerializeField]
    private Sprite emptyHeart;
    private bool isTakingDamage;

    [SerializeField]
    private float immortalityTime;
    private int num = 0;
    // Use this for initialization
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        instance = this;
        currentHP = maxHP;
        CalculateHearts();
        isTakingDamage = true;
    }

    public void Damage(int damangeTaken)
    {
        if (isTakingDamage == true)
        {
            isTakingDamage = false;
            currentHP -= damangeTaken;
            //become immortal for X amount of time
            StartCoroutine("BecomeImmortal", immortalityTime);
            //ignore the collision between the player and enemies
            Physics2D.IgnoreLayerCollision(10, 11);
            
            if (currentHP <= 0)
            {
                Die();
            }
            CalculateHearts();
        }
        else
        {
            return;
        }
        
    }

    public void CalculateHearts()
    {
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHP)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }

    }

    public void Heal(int amountToHeal)
    {
        currentHP += amountToHeal;
        CalculateHearts();
    }

    public void Die()
    {
        Debug.Log("Dead!");
    }

    IEnumerator BecomeImmortal(float immortalityTime)
    {
        //Start flashing, instantly, every X amount of time 
        InvokeRepeating("Flash", 0, timeBetweenFlashes);
        //wait for the immortality timer to expire
        yield return new WaitForSeconds(immortalityTime);
        //stop flashing
        CancelInvoke();
        //change color back to normal if the flash finished on the transperant value
        sr.color = new Color(255, 255, 255, 255);
        //Re-enable the collisions between the player and the enemy
        Physics2D.IgnoreLayerCollision(10, 11, false);
        isTakingDamage = true;

    }

    void Flash()
    {
            if (flashEffectTrigger == true)
            {
                sr.color = flashColor;
                flashEffectTrigger = false;
            }
            else
            {
                sr.color = normalColor;
                flashEffectTrigger = true;
            }
    }
}
