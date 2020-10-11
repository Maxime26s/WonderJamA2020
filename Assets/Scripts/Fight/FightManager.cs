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

    // Start is called before the first frame update
    void Start()
    {
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.15f);
            Init(GameManager.Instance.mapManager.currentNode.GetComponent<Node>().nodeType);
        }
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(GameManager.NodeType type)
    {
        player = Instantiate(player, new Vector2(player.transform.position.x, player.transform.position.y - offsety), Quaternion.identity);
        switch (type)
        {
            default:
            case GameManager.NodeType.Enemy:
                enemy = enemies[Random.Range(0, enemies.Count)];
                enemy = Instantiate(enemy, new Vector2(enemy.transform.position.x, enemy.transform.position.y - offsety), Quaternion.identity);
                break;
            case GameManager.NodeType.Miniboss:
                enemy = miniBosses[Random.Range(0, miniBosses.Count)];
                enemy = Instantiate(enemy, new Vector2(enemy.transform.position.x, enemy.transform.position.y - offsety), Quaternion.identity);
                break;
            case GameManager.NodeType.Boss:
                enemy = Instantiate(boss, new Vector2(boss.transform.position.x, boss.transform.position.y - offsety), Quaternion.identity);
                break;
        }
    }
}
