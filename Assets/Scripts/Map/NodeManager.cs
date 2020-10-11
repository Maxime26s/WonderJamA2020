using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NodeManager : MonoBehaviour
{
    public GameObject nodePrefab, pathPrefab;
    public Vector2 nodeDistance;
    public int nodeAmount;
    float offset;
    public GameObject start;
    public GameObject player;

    public List<GameObject> dungeons = new List<GameObject>();

    public Timer timer;

    public GameObject currentNode;
    public int currentIndex;
    public List<GameObject> choices = new List<GameObject>();

    GameObject currentDungeonGO;

    public float cdSelect;
    bool onCd = false;
    public bool stop = false;
    bool end = false;
    bool aDown = false;
    bool dungeonSwitch = false;

    public int nbPoints;

    private void OnEnable()
    {
        timer.RefreshText();
        timer.running = false;
        timer.timer.color = new Color32(152, 221, 227, 255);
        if (dungeonSwitch)
        {
            StartCoroutine(WaitAnimationDungeon("Done"));
            GameManager.Instance.dungeon++;
            StartCoroutine(WaitAnimationDungeon("Init"));
            MapMaker();
            dungeonSwitch = false;
        }
        if (end)
        {
            stop = true;
            IEnumerator End()
            {
                dungeons[GameManager.Instance.dungeon].GetComponent<Animator>().SetBool("Done", true);
                yield return new WaitForSeconds(1.1f);
                GameManager.Instance.SceneTransition();
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            }
            StartCoroutine(End());
        }
    }

    private void OnDisable()
    {
        timer.running = true;
        timer.timer.color = new Color32(255, 255, 255, 255);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (nodeAmount % 2 == 0)
            nodeAmount++;
        offset = (nodeDistance.x * (nodeAmount - 1)) / 2;
        player = Instantiate(player, transform);
        MapMaker();
        StartCoroutine(WaitAnimationDungeon("Init"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("A"))
            aDown = false;
        
        if(Input.GetKeyDown(KeyCode.J))
            NextLevel();

        if (!stop)
        {
            float y = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(y) > 0.2)
            {
                if (y > 0 && currentIndex > 0 && !onCd)
                {
                    currentIndex--;
                    currentNode = choices[currentIndex];
                    player.transform.position = currentNode.transform.position;
                }
                else if (y < 0 && currentIndex < choices.Count - 1 && !onCd)
                {
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
            if (!aDown)
            {
                if ((Input.GetButton("A")) || Input.GetKeyDown(KeyCode.Space))
                {
                    aDown = true;
                    if (currentNode == start || GameManager.Instance.skipEnemy && currentNode.GetComponent<Node>().nodeType == GameManager.NodeType.Enemy)
                    {
                        if (currentNode.GetComponent<Node>().nodeType == GameManager.NodeType.Enemy)
                            GameManager.Instance.skipEnemy = false;
                        NextLevel();
                    }
                    else
                    {
                        stop = true;
                        GameManager.Instance.LoadScenesFromMap();
                    }
                }
            }
        }
    }

    public void NextLevel()
    {
        if (currentNode.GetComponent<Node>().gameObjects.Count != 0)
        {
            choices = currentNode.GetComponent<Node>().gameObjects;
            currentNode = choices[0];
            currentIndex = 0;
            player.transform.position = currentNode.transform.position;
        }
        else
        {
            if (GameManager.Instance.dungeon < 4)
            {
                dungeonSwitch = true;
            }
            else
            {
                end = true;
            }
        }
    }

    void MapMaker()
    {
        Destroy(currentDungeonGO);
        currentDungeonGO = new GameObject();
        currentDungeonGO.transform.SetParent(transform);
        int nextType = 0, oldType = 0;
        List<GameObject> nextNode = new List<GameObject>(), oldNode = new List<GameObject>();
        for (int i = 0; i < nodeAmount; i++)
        {
            if (i % 2 == 0)
            {
                nextType = 1;
                nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, 0), Quaternion.identity, currentDungeonGO.transform));
                if (i == 0)
                {
                    start = nextNode[0];
                    start.GetComponent<Node>().RefreshType(GameManager.NodeType.Start);
                }
                else
                {
                    nextNode[0].GetComponent<Node>().RefreshType(GameManager.NodeType.Enemy);
                    GameObject temp;
                    switch (oldType)
                    {
                        case 2:
                            for (int j = 1; j < nbPoints + 1; j++)
                            {
                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, (nodeDistance.y / 2) / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);

                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, (-nodeDistance.y / 2) / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);
                            }
                            break;
                        case 3:
                            for (int j = 1; j < nbPoints + 1; j++)
                            {
                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);

                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, 0), Quaternion.identity, currentDungeonGO.transform);
                                if (j % 2 == 0)
                                    temp.transform.localScale = new Vector3(0.1f, 0.1f);
                                else
                                    temp.transform.localScale = new Vector3(0.05f, 0.05f);
                                temp.transform.eulerAngles = new Vector3(0, 0, 45);

                                temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * i) - (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, -nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
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
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, nodeDistance.y / 2), Quaternion.identity, currentDungeonGO.transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, -nodeDistance.y / 2), Quaternion.identity, currentDungeonGO.transform));

                        for (int j = 1; j < nbPoints + 1; j++)
                        {
                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, (nodeDistance.y / 2) / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, (-nodeDistance.y / 2) / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);
                        }
                        break;
                    case 3:
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, nodeDistance.y), Quaternion.identity, currentDungeonGO.transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, 0), Quaternion.identity, currentDungeonGO.transform));
                        nextNode.Add(Instantiate(nodePrefab, new Vector2(nodeDistance.x * i - offset, -nodeDistance.y), Quaternion.identity, currentDungeonGO.transform));

                        for (int j = 1; j < nbPoints + 1; j++)
                        {
                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, 0), Quaternion.identity, currentDungeonGO.transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);

                            temp = Instantiate(pathPrefab, new Vector2((nodeDistance.x * (i - 1)) + (nodeDistance.x / (nbPoints + 3) * (j + 1)) - offset, -nodeDistance.y / (nbPoints + 3) * (j + 1)), Quaternion.identity, currentDungeonGO.transform);
                            if (j % 2 == 0)
                                temp.transform.localScale = new Vector3(0.1f, 0.1f);
                            else
                                temp.transform.localScale = new Vector3(0.05f, 0.05f);
                            temp.transform.eulerAngles = new Vector3(0, 0, 45);
                        }
                        break;
                }
            }
            if (nextNode[0] != start)
                switch (nextType)
                {
                    case 1:
                        for (int j = 0; j < oldType; j++)
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

            for (int j = 0; j < nextNode.Count; j++)
            {
                if (nextNode[j] != start)
                    nextNode[j].GetComponent<Node>().lastNode = oldNode[0];
            }

            oldType = nextType;
            oldNode = nextNode;
            nextNode = new List<GameObject>();
        }
        player.transform.position = start.transform.position;

        currentNode = start;
        currentIndex = 0;
    }

    IEnumerator WaitAnimationDungeon(string name)
    {
        Animator animator = dungeons[GameManager.Instance.dungeon].GetComponent<Animator>();
        yield return new WaitForSeconds(1f);
        animator.SetBool(name, true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool(name, false);
    }
}
