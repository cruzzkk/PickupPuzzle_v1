using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabble
{
    bool _isGrabbed { get; set; }
    void Grab(Transform toAttached);
    void Drop();
}
