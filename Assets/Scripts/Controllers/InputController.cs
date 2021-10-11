using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField]
    public bool debug = false;
    public UnityEvent onArrowDown;
    public UnityEvent onArrowUp;
    public UnityEvent onArrowLeft;
    public UnityEvent onArrowRight;

    public UnityEvent onSpace;

    private void Update()
    {
        if (Input.GetButtonDown("ArrowDown"))
        {
            if (debug) Debug.Log("ArrowDown pressed");
            onArrowDown.Invoke();
        }
        if (Input.GetButtonDown("ArrowUp"))
        {
            if (debug) Debug.Log("ArrowUp pressed");
            onArrowUp.Invoke();
        }
        if (Input.GetButtonDown("ArrowRight"))
        {
            if (debug) Debug.Log("ArrowRight pressed");
            onArrowRight.Invoke();
        }
        if (Input.GetButtonDown("ArrowLeft"))
        {
            if (debug) Debug.Log("ArrowLeft pressed");
            onArrowLeft.Invoke();
        }
        if (Input.GetButtonDown("Space"))
        {
            if (debug) Debug.Log("Space pressed");
            onSpace.Invoke();
        }
    }
}
