using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManger : MonoBehaviour
{
     const string CONTAINER_C = "C";
    [SerializeField]
    Transform[] _checkpoint;
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GameObject _containerUI,_leftCoffin,_categoryUI;
    [SerializeField]
    TMPro.TextMeshProUGUI _containerDisplayUI;
    BaseContainer[] publishers;
    public bool firstPickuped = false;
    public bool _freeze=false;
    // Reference to the Post-Processing Profile
    public PostProcessVolume postProcessVolume;

    public delegate void MovePlayerAction(Vector3 position);
    public static event MovePlayerAction OnMovePlayerAction;
    public static GameManger instance;
    private void Awake()
    {
        instance = this;
        ReserUI();

        publishers = FindObjectsOfType<BaseContainer>();
        foreach (BaseContainer publisher in publishers)
        {
            publisher.OnContainerEnterAction +=  Container_OnContainerEnterAction;
            publisher.OnContainerExitAction += Container_OnContainerExitAction;
        }
        
        GrabbleObject.OnAfterGraborDetachAction += GrabbleObject_OnAfterGraborDetachAction;
    }

    private void GrabbleObject_OnAfterGraborDetachAction()
    {
        LiftCoffin(false);

        if (!firstPickuped)
        {

            _categoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            firstPickuped = true;
            _freeze = true;
        }
    }

   
    private void Start()
    {
        OnMovePlayerAction(_checkpoint[0].position);
        LiftCoffin(true);
    }

    private void Container_OnContainerExitAction(string _containerName)
    {
        _containerUI.SetActive(false);
        _containerDisplayUI.text = "";
    }

    private void Container_OnContainerEnterAction(string _containerName)
    {
        if (_containerName != CONTAINER_C)
        {
            _containerUI.SetActive(true);
            _containerDisplayUI.text = "You have Dropped in " + _containerName;
        }
        else
        {
            OnMovePlayerAction(_checkpoint[0].position);
            firstPickuped = false;
           
        }
          
    }
    void ReserUI() {
        _containerUI.SetActive(false);
        _containerDisplayUI.text = "";
        LiftCoffin(false);
        _categoryUI.SetActive(false);
    }
    private void OnDisable()
    {
       
        foreach (BaseContainer publisher in publishers)
        {
            publisher.OnContainerEnterAction -= Container_OnContainerEnterAction;
            publisher.OnContainerExitAction -= Container_OnContainerExitAction;
        }
    }
    void LiftCoffin(bool value) {
        _leftCoffin.SetActive(value);
    }
}
