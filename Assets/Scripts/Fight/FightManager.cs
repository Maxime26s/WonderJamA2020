using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> miniBosses = new List<GameObject>();
    public GameObject boss;
    public float offsety;
    public GameObject enemy, player;

    private void Awake()
    {
        Init(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int type)
    {
        player = Instantiate(player, new Vector2(player.transform.position.x, player.transform.position.y - offsety), Quaternion.identity);
        switch (type)
        {
            case 0:
                enemy = enemies[Random.Range(0, enemies.Count)];
                enemy = Instantiate(enemy, new Vector2(enemy.transform.position.x, enemy.transform.position.y - offsety), Quaternion.identity);
                break;
            case 1:
                enemy = enemies[Random.Range(0, enemies.Count)];
                enemy = Instantiate(enemy, new Vector2(enemy.transform.position.x, enemy.transform.position.y - offsety), Quaternion.identity);
                break;
            case 2:
                enemy = enemies[Random.Range(0, enemies.Count)];
                enemy = Instantiate(enemy, new Vector2(enemy.transform.position.x, enemy.transform.position.y - offsety), Quaternion.identity);
                break;
        }
    }
}
