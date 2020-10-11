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

    // Start is called before the first frame update
    void Start()
    {
        timer.enabled = true;
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
            playerTime.LoseTime(Random.Range(minDamage, maxDamage));
            attack = false;
            
            StartCoroutine(WaitCoolDown());
            StartCoroutine(AttackAnim());
            //Do anim stuff
        }

        if(timer.minutes == 0 && timer.seconds == 0 && timer.miliseconds <= 0)
        {
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
        Debug.Log(anim.parameterCount);
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("attacking", false);
    }
}