using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleObject : MonoBehaviour,IGrabble
{
    public bool _isGrabbed { get ; set ; }
    Transform _fingerTip;
    [SerializeField]
    Rigidbody _rd;
    [SerializeField]
    float followSpeed = 5;
    [SerializeField]
    Vector3 _initalPosition;

    public delegate void AfterGraborDetachAction();
    public static event AfterGraborDetachAction OnAfterGraborDetachAction;

    private void Awake()
    {
        HandTrigger.OnGrabAction += HandTrigger_OnGrabAction;
        HandTrigger.OnDetachObjectAction += HandTrigger_OnDetachObjectAction;
        _initalPosition = transform.position;
    }

    private void HandTrigger_OnDetachObjectAction(GameObject grabbleObject)
    {
        if (this.gameObject == grabbleObject) {
            _isGrabbed = false;
            Drop();
            transform.position = _initalPosition;
        }
    }
 

    private void HandTrigger_OnGrabAction(Transform fingerTipTransform,GameObject grabbleObject)
    {
        if (!GameManger.instance._freeze&&grabbleObject==this.gameObject)
        {
            TobeGraborDrop(fingerTipTransform);
            OnAfterGraborDetachAction();
        }
           
    }

    private void TobeGraborDrop(Transform fingerTipTransform)
    {
        _isGrabbed = !_isGrabbed;
        if (_isGrabbed)
        {
            Grab(fingerTipTransform);
        }
        else {
            Drop();
        }
    }

    public void Drop()
    {

        _rd.isKinematic = false;
        _rd.useGravity = true;
        _fingerTip = null;


        if (transform.GetChild(1).GetComponent<Camera>() != null)
        {
            transform.GetChild(1).GetComponent<Camera>().gameObject.SetActive(false);
        }

    }
 

    // Update is called once per frame
    void Update()
    {
        if (_isGrabbed)
        {
            transform.position = Vector3.Lerp(transform.position, _fingerTip.position, followSpeed * Time.deltaTime);
            //_rd.MovePosition(_fingerTip.position);
            // transform.position = _fingerTip.position;
            // transform.rotation = _fingerTip.rotation;
        }
      
    }

    public void Grab(Transform toAttached)
    {
         
            _rd.isKinematic = true;
            _rd.useGravity = false;
            _fingerTip = toAttached;
        
        if (transform.GetChild(1).GetComponent<Camera>() != null)
        {
            transform.GetChild(1).GetComponent<Camera>().gameObject.SetActive(true);
        }

    }
    private void OnDisable()
    {
        HandTrigger.OnGrabAction -= HandTrigger_OnGrabAction;
        HandTrigger.OnDetachObjectAction += HandTrigger_OnDetachObjectAction;
    }
}
