using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField]
    public bool debug = false;


    public UnityEvent onEscape, onSpace;

    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (debug) Debug.Log("Escape pressed");
            onEscape.Invoke();
        }

        if (Input.GetButtonDown("Space"))
        {
            onSpace.Invoke();
        }
    }
}
