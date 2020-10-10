using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameManager.NodeType nodeType;
    public List<Sprite> sprites = new List<Sprite>();
    int lastNodeType;
    public List<GameObject> gameObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        nodeType = (GameManager.NodeType)Random.Range(0, sprites.Count-3);
        GetComponent<SpriteRenderer>().sprite = sprites[(int)nodeType];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNode()
    {
        switch (nodeType)
        {
            case GameManager.NodeType.Time:
                GameManager.Instance.InstantiateTime();
                break;
            case GameManager.NodeType.Treasure:
                GameManager.Instance.InstantiateTreaure();
                break;
            case GameManager.NodeType.Trap:
                GameManager.Instance.InstantiateTrap();
                break;
            case GameManager.NodeType.Card:
                GameManager.Instance.InstantiateCard();
                break;
            case GameManager.NodeType.Enemy:
                GameManager.Instance.InstantiateEnemy();
                break;
            case GameManager.NodeType.Miniboss:
                GameManager.Instance.InstantiateMiniboss();
                break;
            case GameManager.NodeType.Boss:
                GameManager.Instance.InstantiateBoss();
                break;
        }
    }

    public void RefreshType(GameManager.NodeType newType)
    {
        nodeType = newType;
        GetComponent<SpriteRenderer>().sprite = sprites[(int)nodeType];
        Debug.Log(2 + ", time: " + Time.time);
    }
}
