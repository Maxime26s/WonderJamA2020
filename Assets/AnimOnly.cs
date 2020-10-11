using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOnly : MonoBehaviour
{
    public Animator anim;
    public IEnumerator AttackAnim()
    {
        Debug.Log(anim.parameterCount);
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("attacking", false);
    }
}
