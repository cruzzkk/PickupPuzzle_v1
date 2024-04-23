using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputAction : MonoBehaviour
{
    public delegate void LeftClickAction();
    public static event LeftClickAction OnLeftClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftClicked?.Invoke();
        }

    }
}
