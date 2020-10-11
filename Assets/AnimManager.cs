using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AnimManager : MonoBehaviour
{
    public Animator animator;
    public GameObject transition;
    public GameObject instructionB1, instructionB2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        IEnumerator OnAndOff()
        {
            transition.SetActive(true);
            animator.SetBool("Play", true);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("Play", false);
            SceneManager.LoadScene("Intro", LoadSceneMode.Additive);
            gameObject.SetActive(false);
        }
        StartCoroutine(OnAndOff());
    }

    public void SelectInstructions1()
    {
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(instructionB1.gameObject);
    }

    public void SelectInstructions2()
    {
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(instructionB2.gameObject);
    }
}
