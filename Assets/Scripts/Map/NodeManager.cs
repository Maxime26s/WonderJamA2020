using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public GameObject nodePrefab, pathPrefab;
    public Vector2 nodeDistance;
    public int nodeAmount;
    float offset;
    GameObject start;
    public GameObject player;

    public Timer timer;

    public GameObject currentNode;
    int currentIndex;
    List<GameObject> choices = new List<GameObject>();

    public float cdSelect;
    bool onCd = false;

    bool end = false;

    public int nbPoints;
    
    private void OnEnable()
    {
        timer.RefreshText();
        timer.enabled = false;
        timer.timer.color = new Color32(152, 221, 227, 255);
        //if (end)
        //CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE
    }

    private void OnDisable()
    {
        timer.enabled = true;
        timer.timer.color = new Color32(255, 255, 255, 255);
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
            /*
            IEnumerator SwitchTarget(float cdSelect)
            {
                onCd = true;
                yield return new WaitForSeconds(cdSelect);
                onCd = false;
            }
            */
            float y = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(y) > 0.2)
            {
                if (y > 0 && currentIndex > 0 && !onCd)
                {
                    //StartCoroutine(SwitchTarget(cdSelect));
                    currentIndex--;
                    currentNode = choices[currentIndex];
                    player.transform.position = currentNode.transform.position;
                }
                else if (y < 0 && currentIndex < choices.Count - 1 && !onCd)
                {
                    //StartCoroutine(SwitchTarget(cdSelect));
                    currentIndex++;
                    currentNode = choices[currentIndex];
                    player.transform.position = currentNode.transform.position;
                }
                onCd = true;
            }
            else
            {
                onCd = false;
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
        if(currentNode.GetComponent<Node>().gameObjects.Count != 0)
        {
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
                    start.GetComponent<Node>().RefreshType(GameManager.NodeType.Start);
                }
                else
                {
                    GameObject temp;
                    switch (oldType)
                    {
                        case 2:
                            /*
                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / 2) - offset, nodeDistance.y / 4), Quaternion.identity, transform);
                            temp.transform.eulerAngles = new Vector3(0, 0, -Mathf.Rad2Deg * Mathf.Atan2(oldNode[0].transform.position.y - nextNode[0].transform.position.y, nextNode[0].transform.position.x - oldNode[0].transform.position.x));
                            temp.transform.localScale = new Vector3(0.33f, 0.1f);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / 2) - offset, -nodeDistance.y / 4), Quaternion.identity, transform);
                            temp.transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(oldNode[0].transform.position.y - nextNode[0].transform.position.y, nextNode[0].transform.position.x - oldNode[0].transform.position.x));
                            temp.transform.localScale = new Vector3(0.33f, 0.1f);
                            */

                            for(int j=1;j < nbPoints+1; j++)
                            {
                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j+1)) - offset, (nodeDistance.y / 2) / (nbPoints + 3) * (j+1)), Quaternion.identity, transform);
                                if(j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);

                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, (-nodeDistance.y / 2) / (nbPoints + 3) * (j + 1)), Quaternion.identity, transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);
                            }
                            break;
                        case 3:
                            /*
                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / 2) - offset, nodeDistance.y / 2), Quaternion.identity, transform);
                            temp.transform.eulerAngles = new Vector3(0, 0, -Mathf.Rad2Deg * Mathf.Atan2(oldNode[0].transform.position.y - nextNode[0].transform.position.y, nextNode[0].transform.position.x - oldNode[0].transform.position.x));
                            temp.transform.localScale = new Vector3(0.5f, 0.1f);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / 2) - offset, 0), Quaternion.identity, transform);
                            temp.transform.localScale = new Vector3(0.25f, 0.1f);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / 2) - offset, -nodeDistance.y / 2), Quaternion.identity, transform);
                            temp.transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(oldNode[0].transform.position.y - nextNode[0].transform.position.y, nextNode[0].transform.position.x - oldNode[0].transform.position.x));
                            temp.transform.localScale = new Vector3(0.5f, 0.1f);
                            */

                            for (int j = 1; j < nbPoints + 1; j++)
                            {
                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);

                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, 0), Quaternion.identity, transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);

                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, -nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);
                            }
                            break;
                    }
                    if (i == nodeAmount - 1)
                    {
                        if (GameManager.Instance.dungeon == 4)
                            nextNode[0].GetComponent<Node>().RefreshType(GameManager.NodeType.Boss);
                        else
                            nextNode[0].GetComponent<Node>().RefreshType(GameManager.NodeType.Miniboss);
                    }
                    else
                        nextNode[0].GetComponent<Node>().RefreshType(GameManager.NodeType.Enemy);
                }
            }
            else
            {
                nextType = Random.Range(2, 4);
                GameObject temp;
                switch (nextType)
                {
                    case 2:
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, nodeDistance.y/2), Quaternion.identity, transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, -nodeDistance.y/2), Quaternion.identity, transform));

                        for (int j = 1; j < nbPoints + 1; j++)
                        {
                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, (nodeDistance.y / 2) / (nbPoints + 3) * (j + 1)), Quaternion.identity, transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, (-nodeDistance.y / 2) / (nbPoints + 3) * (j + 1)), Quaternion.identity, transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);
                        }
                        break;
                    case 3:
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, nodeDistance.y), Quaternion.identity, transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, 0), Quaternion.identity, transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, -nodeDistance.y), Quaternion.identity, transform));

                        for (int j = 1; j < nbPoints + 1; j++)
                        {
                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, 0), Quaternion.identity, transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, -nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);
                        }
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
