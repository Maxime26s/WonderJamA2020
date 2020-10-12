using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monobehaviours
{
public class LabyrintheMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float playerSpeed = 2.0f;
    public Animator animator;
        public SetAnimation sa;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Vector2 moveInput = new Vector2(InputManager.Instance.x1, InputManager.Instance.y1);
        moveVelocity = moveInput.normalized * playerSpeed;

            if (moveInput == Vector2.zero)
            {
                sa.Set(0);
            } else if (moveInput.x > 0 && moveInput.y > 0)
            {
                sa.Set(8);
            } else if (moveInput.x > 0 && moveInput.y == 0){
                sa.Set(5);
            }else if(moveInput.x > 0 && moveInput.y< 0)
            {
                sa.Set(3);
            }else if (moveInput.x==0 && moveInput.y<0)
            {
                sa.Set(1);
            }else if(moveInput.x < 0 && moveInput.y < 0)
            {
                sa.Set(2);
            }else if(moveInput.x <0 && moveInput.y == 0)
            {
                sa.Set(4);
            }else if(moveInput.x < 0 && moveInput.y > 0)
            {
                sa.Set(7);
            }
            else
            {
                sa.Set(6);
            }
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }

   
}

}
