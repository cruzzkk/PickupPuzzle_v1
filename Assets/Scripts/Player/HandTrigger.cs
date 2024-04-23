using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class HandTrigger : MonoBehaviour
{
    public delegate void GrabAction(Transform fingerTipTransform,GameObject grabbleObject);
    public static event GrabAction OnGrabAction;
    public delegate void DetachObjectAction(GameObject grabbleObject);
    public static event DetachObjectAction OnDetachObjectAction;
   

    [SerializeField]
    GameObject _currentGrabbleObject, _last_currentGrabbleObject;
    [SerializeField]
    Transform _fingerTip;
    private void Awake()
    {
        MouseInputAction.OnLeftClicked += MouseInputAction_OnLeftClicked;
        PlayerMovement.OnDetachGrabbleAction += PlayerMovement_OnDetachGrabbleAction;
    }

    private void PlayerMovement_OnDetachGrabbleAction()
    {
         
            OnDetachObjectAction(_last_currentGrabbleObject);
        
       
        //_currentGrabbleObject = null;
    }

    private void MouseInputAction_OnLeftClicked()
    {
        if (_currentGrabbleObject != null&&!GameManger.instance._freeze)
        {
            if (_currentGrabbleObject.gameObject.TryGetComponent(out IGrabble grabble))
            {
                AudioManger.instance.AudioPlay(0);
                OnGrabAction(_fingerTip, _currentGrabbleObject);
               
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.TryGetComponent(out IGrabble grabble)&&!GameManger.instance._freeze)
        {
          
                _currentGrabbleObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.TryGetComponent(out IGrabble grabble)&&!GameManger.instance._freeze)
        {
            if (!grabble._isGrabbed)
            {
                _last_currentGrabbleObject = _currentGrabbleObject;
                _currentGrabbleObject = null;
            }
              
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IGrabble grabble) && !GameManger.instance._freeze)
        {

            _currentGrabbleObject = other.gameObject;
        }
    }

    private void OnDisable()
    {
        MouseInputAction.OnLeftClicked -= MouseInputAction_OnLeftClicked;
        PlayerMovement.OnDetachGrabbleAction -= PlayerMovement_OnDetachGrabbleAction;
    }

}
