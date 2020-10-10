using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameManager.NodeType nodeType;
    public List<Sprite> sprites = new List<Sprite>();
    int lastNodeType;
    public GameObject lastNode;
    public List<GameObject> gameObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        nodeType = (GameManager.NodeType)Random.Range(0, sprites.Count-4);
        GetComponent<SpriteRenderer>().sprite = sprites[(int)nodeType];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshType(GameManager.NodeType newType)
    {
        nodeType = newType;
        GetComponent<SpriteRenderer>().sprite = sprites[(int)nodeType];    }
}
