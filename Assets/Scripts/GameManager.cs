using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
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

    public List<GameObject> enemies = new List<GameObject>(); //miniboss = better boss
    public List<GameObject> treasures = new List<GameObject>();
    public List<GameObject> traps = new List<GameObject>();
    public List<GameObject> cards = new List<GameObject>();
    public GameObject boss;
    public int dungeon = 0;

    public enum NodeType
    {
        Treasure,
        Trap,
        Card,
        Time,
        Enemy,
        Miniboss,
        Boss,
        Start
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateTreaure()
    {
        Instantiate(treasures[Random.Range(0, treasures.Count)], Vector3.zero, Quaternion.identity);
    }

    public void InstantiateTrap()
    {
        Instantiate(traps[Random.Range(0, traps.Count)], Vector3.zero, Quaternion.identity);
    }

    public void InstantiateCard()
    {
        Instantiate(cards[Random.Range(0, cards.Count)], Vector3.zero, Quaternion.identity);
    }

    public void InstantiateEnemy()
    {
        //Instantiate(cards[Random.Range(0, cards.Count)], Vector3.zero, Quaternion.identity);
    }

    public void InstantiateTime()
    {
        //Instantiate(cards[Random.Range(0, cards.Count)], Vector3.zero, Quaternion.identity);
    }

    public void InstantiateMiniboss()
    {
        //Instantiate(cards[Random.Range(0, cards.Count)], Vector3.zero, Quaternion.identity);
    }

    public void InstantiateBoss()
    {
        //Instantiate(cards[Random.Range(0, cards.Count)], Vector3.zero, Quaternion.identity);
    }
}
