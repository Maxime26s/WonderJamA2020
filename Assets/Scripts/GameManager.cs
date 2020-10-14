using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        /*
        IEnumerator WaitAndKill()
        {
            yield return new WaitForSeconds(1.15f);
            if (SceneManager.GetActiveScene().name == "Menu")
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        }
        StartCoroutine(WaitAndKill());*/
    }

    public List<GameObject> enemies = new List<GameObject>(); //miniboss = better boss
    public List<GameObject> miniBoss = new List<GameObject>();
    public List<GameObject> treasures = new List<GameObject>();
    public List<GameObject> traps = new List<GameObject>();
    public List<GameObject> cards = new List<GameObject>();
    public GameObject boss;
    public int dungeon = 0;
    public Animator animator;

    public bool skipEnemy = false;

    public GameObject map;
    public NodeManager mapManager;

    public float transWait;


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

    public void SceneTransition()
    {
        IEnumerator animationPlay()
        {
            animator.SetBool("Play", true);
            yield return new WaitForSeconds(1f);
            animator.SetBool("Play", false);
        }
        StartCoroutine(animationPlay());
    }

    public void LoadScenesFromMap()
    {
        SceneTransition();
        switch (mapManager.currentNode.GetComponent<Node>().nodeType)
        {
            case NodeType.Enemy:
            case NodeType.Miniboss:
            case NodeType.Boss:
                LoadFight();
                break;
            case NodeType.Treasure:
                LoadTreasure();
                break;
            case NodeType.Card:
                LoadCard();
                break;
            case NodeType.Time:
                LoadTime();
                break;
            case NodeType.Trap:
                LoadTrap();
                break;
        }
    }

    public void LoadMap()
    {
        IEnumerator Wait()
        {
            SceneTransition();
            yield return new WaitForSeconds(transWait);
            map.SetActive(true);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            yield return new WaitForSeconds(transWait);
            mapManager.stop = false;
        }
        StartCoroutine(Wait());
    }

    public void LoadFight()
    {
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(transWait);
            SceneManager.LoadScene("Fight", LoadSceneMode.Additive);
            mapManager.NextLevel();
            yield return new WaitForSeconds(0.1f);
            map.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Fight"));
        }
        StartCoroutine(Wait());
    }

    public void LoadTreasure()
    {
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(transWait);
            SceneManager.LoadScene("Chest", LoadSceneMode.Additive);
            mapManager.NextLevel();
            yield return new WaitForSeconds(0.1f);
            map.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Chest"));
        }
        StartCoroutine(Wait());
    }

    public void LoadCard()
    {
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(transWait);
            SceneManager.LoadScene("Card", LoadSceneMode.Additive);
            mapManager.NextLevel();
            yield return new WaitForSeconds(0.1f);
            map.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Card"));
        }
        StartCoroutine(Wait());
    }

    public void LoadTime()
    {
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(transWait);
            SceneManager.LoadScene("GH", LoadSceneMode.Additive);
            mapManager.NextLevel();
            yield return new WaitForSeconds(0.1f);
            map.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("GH"));
        }
        StartCoroutine(Wait());
    }

    public void LoadTrap()
    {
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(transWait);
            SceneManager.LoadScene("Memory", LoadSceneMode.Additive);
            mapManager.NextLevel();
            yield return new WaitForSeconds(0.1f);
            map.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Memory"));
        }
        StartCoroutine(Wait());
    }

    public void LoadDeath()
    {
        IEnumerator Wait()
        {
            SceneManager.LoadScene("Death");
            yield return null;
            /*
            SceneTransition();
            yield return new WaitForSeconds(0.5f);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            map.SetActive(false);
            T
            SceneManager.LoadScene("Death", LoadSceneMode.Additive);
            yield return new WaitForSeconds(0.1f);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Death"));
            yield return new WaitForSeconds(0.7f);
            SceneManager.UnloadSceneAsync("Map");*/
        }
        StartCoroutine(Wait());
    }

    public void PerteTemps(float secondes)
    {
        mapManager.timer.RemoveTime(secondes);
    }

    public void AjoutTemps(float secondes)
    {
        mapManager.timer.AddTime(secondes);
    }

    public void TpBoss()
    {
        while (mapManager.currentNode.GetComponent<Node>().gameObjects.Count != 0)
        {
            mapManager.choices = mapManager.currentNode.GetComponent<Node>().gameObjects;
            mapManager.currentNode = mapManager.choices[0];
            mapManager.currentIndex = 0;
        }
        mapManager.player.transform.position = mapManager.currentNode.transform.position;
    }

    public void TpStart()
    {
        mapManager.choices = new List<GameObject>();
        mapManager.choices.Add(mapManager.start);
        mapManager.currentNode = mapManager.start;
        mapManager.currentIndex = 0;
        mapManager.player.transform.position = mapManager.currentNode.transform.position;
    }

    public void SkipEnemy()
    {
        skipEnemy = true;
    }

    public void ReculeCase()
    {
        GameObject oldNode = mapManager.currentNode.GetComponent<Node>().lastNode;
        if (oldNode != mapManager.start)
        {
            oldNode = oldNode.GetComponent<Node>().lastNode;
            mapManager.choices = new List<GameObject>();
            mapManager.choices.Add(oldNode);
            mapManager.currentNode = oldNode;
            mapManager.currentIndex = 0;
            mapManager.player.transform.position = mapManager.currentNode.transform.position;
        }
    }
}
