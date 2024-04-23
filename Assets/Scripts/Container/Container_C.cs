using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_C : BaseContainer
{
    [SerializeField]
    string _containerName;
    
    public override event ContainerEnterAction OnContainerEnterAction;
    public override event ContainerExitAction OnContainerExitAction;
    protected override string containername { get { return _containerName; } set { _containerName = value; } }
    

    protected override void OnEnter()
    {
        OnContainerEnterAction(containername);
    }

    protected override void OnExit()
    {
        if(containername!= _containerName)
            OnContainerExitAction(containername);
    }
    protected override void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject.TryGetComponent(out IGrabble grabble))
        {
            if (!grabble._isGrabbed)
            {
                
                OnEnter();
            }

        }
    }
    protected override void OnCollisionExit(Collision collision)
    {
    }
   
}
