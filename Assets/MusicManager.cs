using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public AudioSource songMap;
    public AudioSource songFight;

    private void Start()
    {
        songMap.Play();
    }

    public void FightMusic()
    {
        IEnumerator fm()
        {
            songMap.Pause();
            yield return new WaitForSeconds(1.5f);
            songFight.Play();
        }
        StartCoroutine(fm());
    }

    public void MapMusic()
    {
        IEnumerator mm()
        {
            songFight.Stop();
            yield return new WaitForSeconds(1.5f);
            songMap.UnPause();
        }
        StartCoroutine(mm());
    }

    public void StopAll()
    {
        songFight.Stop();
        songMap.Pause();
    }
}
