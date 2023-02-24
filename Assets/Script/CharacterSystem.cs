using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterSystem : MonoBehaviour
{
    public int playerEnergy;
    public int playerHP;
    public int maxPlayerEnergy;
    public int maxPlayerHP;
    public CharacterController characterController;

    public static CharacterSystem instance = null;

    public float meleeAttackRange = 2f;
    public int meleeAtkDmg = 2;
    public float shurikenAttackRange = 6f;
    public int shurikenAtkDmg = 1;

    private Collider2D hitCollider;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    void restart()
    {
        playerEnergy = maxPlayerEnergy;
        playerHP = maxPlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0)
        {
            gameover();
        }
        if (Input.GetKeyDown("q"))
        {
            CardSystem.instance.currentCardHand[0].PlayCard();
            CardSystem.instance.dropAndDraw(0);
        }
        else if (Input.GetKeyDown("w"))
        {
            CardSystem.instance.currentCardHand[1].PlayCard();
            CardSystem.instance.dropAndDraw(1);
        }
        else if (Input.GetKeyDown("e"))
        {
            CardSystem.instance.currentCardHand[2].PlayCard();
            CardSystem.instance.dropAndDraw(2);
        }
        else if (Input.GetKeyDown("r"))
        {
            CardSystem.instance.currentCardHand[3].PlayCard();
            CardSystem.instance.dropAndDraw(3);
        }
    }

    void gameover()
    {
        //play some ui and animation

    }

    public void melee()
    {
        //check around the melee radius and attack
        //attack animation TODO
        hitCollider = Physics2D.OverlapCircle(transform.position, meleeAttackRange, 6);//6 stands for enemy
        if (hitCollider.CompareTag("Enemy"))
        {
            hitCollider.gameObject.GetComponent<Enemy>().takeDamage(meleeAtkDmg);
        }
    }

    public void shuriken()
    {
        //check around the ranged radius and attack
        hitCollider = Physics2D.OverlapCircle(transform.position, shurikenAttackRange, 6);//6 stands for enemy
        if (hitCollider.CompareTag("Enemy"))
        {
            hitCollider.gameObject.GetComponent<Enemy>().takeDamage(shurikenAtkDmg);
        }
    }

    void beenHit(int hpLoss)
    {
        if (playerHP < hpLoss)
        {
            playerHP = 0;
        }
        else
        {
            playerHP -= hpLoss;
        }
    }

    void beenHitCard(Card card)
    {
        CardSystem.instance.AddCardtoDeck(card);
    }
}
