using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void buttonPlay()
    {
        Application.LoadLevel(1);
    }
    public void buttonInstruction()
    {
        Application.LoadLevel(2);
    }
    public void buttonQuitter()
    {
        Application.Quit(0);
    }
}
