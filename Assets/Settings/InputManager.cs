using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Input input;

    public float x1, y1, x2, y2;
    public bool a, b, x, y;

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
        input = new Input();

        input.Game.Horizontal.performed += ctx => x1 = ctx.ReadValue<float>();
        input.Game.Horizontal.canceled += ctx => x1 = 0;
        
        input.Game.Vertical.performed += ctx => y1 = ctx.ReadValue<float>();
        input.Game.Vertical.canceled += ctx => y1 = 0;

        input.Game.Horizontal2.performed += ctx => x2 = ctx.ReadValue<float>();
        input.Game.Horizontal2.canceled += ctx => x2 = 0;

        input.Game.Vertical2.performed += ctx => y2 = ctx.ReadValue<float>();
        input.Game.Vertical2.canceled += ctx => y2 = 0;
    }

    private void Update()
    {
        a = input.Game.A.triggered;
        b = input.Game.B.triggered;
        x = input.Game.X.triggered;
        y = input.Game.Y.triggered;
        if (input.Game.A.triggered)
            Debug.Log("update" + Time.frameCount);
    }

    private void OnEnable()
    {
        input.Game.Enable();
    }
}
