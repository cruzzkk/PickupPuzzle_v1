using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ContainerEnterAction(string _containerName);
public delegate void ContainerExitAction(string _containerName);
public abstract class BaseContainer:MonoBehaviour {
    protected abstract string containername { get; set; }
    protected abstract void OnEnter();
    protected abstract void OnExit();
    protected abstract void OnCollisionEnter(Collision collision);
    protected abstract void OnCollisionExit(Collision collision);

    
    public abstract  event ContainerEnterAction OnContainerEnterAction;
   
    public abstract event ContainerExitAction OnContainerExitAction;
}
