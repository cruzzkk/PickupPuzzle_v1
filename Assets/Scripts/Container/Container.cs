using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Container : BaseContainer
{
   

    [SerializeField]
    string _containerName;
    [SerializeField]
    GameObject _particleSystem;
    /* public delegate void ContainerEnterAction(string _containerName);
     public static event ContainerEnterAction OnContainerEnterAction;
     public delegate void ContainerExitAction(string _containerName);
     public static event ContainerExitAction OnContainerExitAction;*/
    public override event ContainerEnterAction OnContainerEnterAction;
    public override event ContainerExitAction OnContainerExitAction;

    protected override string containername { get { return _containerName; } set { _containerName = value; } }

    private void Start()
    {
       
        _particleSystem.SetActive(false);
    }

    protected override void OnEnter()
    {
      OnContainerEnterAction(containername);
    }

    protected override void OnExit()
    {
      OnContainerExitAction(containername);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.gameObject.TryGetComponent(out IGrabble grabble))
        {
            if (!grabble._isGrabbed)
            {
                _particleSystem.SetActive(true);
                OnEnter();
            }

        }
    }
    protected override void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out IGrabble grabble))
        {
            _particleSystem.SetActive(false);
            OnExit();

        }
    }
 
}
