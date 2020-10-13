using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Input input;

    public float x1, y1, x2, y2;
    public bool a, b, x, y;
    public bool aTap, bTap, xTap, yTap;
    public Coroutine aCo, bCo, xCo, yCo;

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

        IEnumerator Tap(char button)
        {
            switch (button)
            {
                case 'a':
                    aTap = true;
                    break;
                case 'b':
                    bTap = true;
                    break;
                case 'x':
                    xTap = true;
                    break;
                case 'y':
                    yTap = true;
                    break;
            }

            yield return new WaitForSeconds(0.03f);

            switch (button)
            {
                case 'a':
                    aTap = false;
                    break;
                case 'b':
                    bTap = false;
                    break;
                case 'x':
                    xTap = false;
                    break;
                case 'y':
                    yTap = false;
                    break;
            }
        }

        input.Game.A.started += ctx => { if(aCo != null) StopCoroutine(aCo); aCo = StartCoroutine(Tap('a')); };
        //input.Game.A.canceled += ctx => { StopCoroutine(aCo); StartCoroutine(aCo); };

        input.Game.B.started += ctx => { if (bCo != null) StopCoroutine(bCo); bCo = StartCoroutine(Tap('b')); };
        //input.Game.B.canceled += ctx => { StopCoroutine(bCo); StartCoroutine(bCo); };

        input.Game.X.started += ctx => { if (xCo != null) StopCoroutine(xCo); bCo = StartCoroutine(Tap('x')); };
        //input.Game.X.canceled += ctx => { StopCoroutine(xCo); StartCoroutine(xCo); };

        input.Game.Y.started += ctx => { if (yCo != null) StopCoroutine(yCo); bCo = StartCoroutine(Tap('y')); };
        //input.Game.Y.canceled += ctx => { StopCoroutine(yCo); StartCoroutine(yCo); };
    }

    private void Update()
    {
        a = input.Game.A.triggered;
        b = input.Game.B.triggered;
        x = input.Game.X.triggered;
        y = input.Game.Y.triggered;
    }

    private void OnEnable()
    {
        input.Game.Enable();
    }
}
