﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    public Type type;
    public Timer timer;
    public string name;
    public float maxDamage, minDamage;
    public TextMeshProUGUI text;
    public float attackCD;
    public Timer playerTime;
    public bool attack;
    public Animator anim;
    public bool calledEnd;
    public bool lastBoss;

    List<Type> types = new List<Type> { Type.Fire, Type.Water, Type.Air, Type.Earth };

    // Start is called before the first frame update
    void Start()
    {
        if(lastBoss)
            type = types[Random.Range(0, 3)];
        calledEnd = false;
        timer.running = true;
        playerTime = GameManager.Instance.mapManager.timer.GetComponentInChildren<Timer>();
        attackCD = Random.Range(4.0f, 6.0f);
        StartCoroutine(WaitCoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(attack)
        {
            attackCD = Random.Range(3.0f, 5.0f);
            playerTime.RemoveTime(Random.Range((int)minDamage, (int)maxDamage), Random.Range(10, 90));
            attack = false;

            if (lastBoss)
            {
                GameObject.FindGameObjectWithTag("DuelManager").GetComponent<DuelManager>().UpdateEnemyElement();
                type = types[Random.Range(0, 3)];
            }
            
            StartCoroutine(WaitCoolDown());
            StartCoroutine(AttackAnim());
            //Do anim stuff
        }

        if(timer.miliseconds <= 0 && timer.seconds <= 0 && timer.minutes <= 0 && !calledEnd)
        {
            calledEnd = true;
            GameObject.FindGameObjectWithTag("DuelManager").GetComponent<DuelManager>().EndFight();
        }

    }

    IEnumerator WaitCoolDown()
    {
        yield return new WaitForSeconds(attackCD);
        attack = true;
    }

    public IEnumerator AttackAnim()
    {
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("attacking", false);
    }
}
