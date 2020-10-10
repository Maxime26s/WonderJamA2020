using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public GameObject nodePrefab;
    public Vector2 nodeDistance;
    public int nodeAmount;
    float offset;
    GameObject start;
    public GameObject player;

    public GameObject currentNode;
    int currentIndex;
    List<GameObject> choices = new List<GameObject>();

    public float cdSelect;
    bool onCd = false;

    bool end = false;
    
    private void OnEnable()
    {
        //if (end)
        //CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (nodeAmount % 2 == 0)
            nodeAmount++;
        offset = (nodeDistance.x * (nodeAmount - 1)) / 2;
        MapMaker();
        player = Instantiate(player, start.transform.position, Quaternion.identity, transform);

        currentNode = start;
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            IEnumerator SwitchTarget(float cdSelect)
            {
                onCd = true;
                yield return new WaitForSeconds(cdSelect);
                onCd = false;
            }
            float y = Input.GetAxis("Vertical");
            if(y > 0 && currentIndex > 0 && !onCd)
            {
                StartCoroutine(SwitchTarget(cdSelect));
                currentIndex--;
                currentNode = choices[currentIndex];
                player.transform.position = currentNode.transform.position;
            }
            else if(y < 0 && currentIndex < choices.Count - 1 && !onCd)
            {
                StartCoroutine(SwitchTarget(cdSelect));
                currentIndex++;
                currentNode = choices[currentIndex];
                player.transform.position = currentNode.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //currentNode.GetComponent<Node>().SelectNode();
                NextLevel();
                //START LEVEL START LEVEL START LEVEL START LEVEL START LEVEL START LEVEL 
                //gameObject.SetActive(false);
            }
        }
    }

    void NextLevel()
    {
        Debug.Log("lol1");
        if(currentNode.GetComponent<Node>().gameObjects.Count != 0)
        {
            Debug.Log("lol2");
            choices = currentNode.GetComponent<Node>().gameObjects;
            currentNode = choices[0];
            currentIndex = 0;
            player.transform.position = currentNode.transform.position;
        }
        else
        {
            end = true;
        }
    }

    void MapMaker()
    {
        int nextType = 0, oldType = 0;
        List<GameObject> nextNode = new List<GameObject>(), oldNode = new List<GameObject>();
        for (int i = 0; i < nodeAmount; i++)
        {
            if (i % 2 == 0) {
                nextType = 1;
                nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, 0), Quaternion.identity, transform));
                if (i == 0)
                {
                    start = nextNode[0];
                }
                else if (i == nodeAmount - 1)
                {
                    if(GameManager.Instance.dungeon == 4)
                        nextNode[0].GetComponent<Node>().RefreshType(GameManager.NodeType.Boss);
                    else
                        nextNode[0].GetComponent<Node>().RefreshType(GameManager.NodeType.Miniboss);
                }
                else
                    nextNode[0].GetComponent<Node>().RefreshType(GameManager.NodeType.Enemy);
            }
            else
            {
                nextType = Random.Range(2, 4);
                switch (nextType)
                {
                    case 2:
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, nodeDistance.y/2), Quaternion.identity, transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, -nodeDistance.y/2), Quaternion.identity, transform));
                        break;
                    case 3:
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, nodeDistance.y), Quaternion.identity, transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, 0), Quaternion.identity, transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, -nodeDistance.y), Quaternion.identity, transform));
                        break;
                }
            }
            if(nextNode[0] != start)
                switch (nextType)
                {
                    case 1:
                        for(int j = 0; j < oldType; j++)
                        {
                            oldNode[j].GetComponent<Node>().gameObjects.Add(nextNode[0]);
                        }
                        break;
                    case 2:
                    case 3:
                        for (int j = 0; j < nextType; j++)
                        {
                            oldNode[0].GetComponent<Node>().gameObjects.Add(nextNode[j]);
                        }
                        break;
                }
            oldType = nextType;
            oldNode = nextNode;
            nextNode = new List<GameObject>();
        }
    }
}
