using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyDone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
            
            Application.LoadLevel(2);
    }
}
