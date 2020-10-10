﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public int nbOfStars = 10;
    public float fadeSpeed = 0.1f;
    public float shakeDuration = 3;
    public float redDuration = 10;
    public GameObject star;
    public GameObject fade;
    public GameObject earth;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        for(int i = 0; i < nbOfStars; i++)
        {
            GameObject newStar = Instantiate(star, new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight), 0), Quaternion.identity);
            newStar.GetComponent<Animator>().Play("Star Twinkle", 0, Random.Range(0.0f, 1.0f));
        }

        StartCoroutine("Intro");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Intro()
    {
        yield return StartCoroutine("FadeIn");
        yield return StartCoroutine("ApproachEarth");
        yield return StartCoroutine("EarthShake");
        yield return StartCoroutine("EarthRed");
    }

    IEnumerator FadeIn() 
    {
        for (float ft = 1f; ft >= 0; ft -= fadeSpeed) 
        {
            Color c = fade.GetComponent<SpriteRenderer>().color;
            c.a = ft;
            fade.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
    }

    IEnumerator ApproachEarth() 
    {
        for (float size = 1f; size <= 800f; size++) 
        {
            earth.transform.localScale += new Vector3(0.001f, 0.001f, 0);
            yield return null;
        }
        yield return new WaitForSeconds(2);
    }

    public IEnumerator EarthShake()
    {
        Vector3 orignalPosition = earth.transform.position;
        float elapsed = 0f;
        
        while (elapsed < shakeDuration)
        {
            earth.transform.position = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        earth.transform.position = orignalPosition;
    }

    public IEnumerator EarthRed()
    {
        Vector3 orignalPosition = earth.transform.position;
        float elapsed = 0f;
        
        while (elapsed < redDuration)
        {
            earth.transform.position = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            elapsed += Time.deltaTime;

            Color c = earth.GetComponent<SpriteRenderer>().color;
            c.b = 1 - (elapsed / redDuration);
            c.g = 1 - (elapsed / redDuration);
            earth.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        earth.transform.position = orignalPosition;
    }
}