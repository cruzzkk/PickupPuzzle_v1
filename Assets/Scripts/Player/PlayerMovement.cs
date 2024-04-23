using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeedUP = 2.0f;
    public float lookSpeedLeft = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public delegate void DetachGrabbleAction();
    public static event DetachGrabbleAction OnDetachGrabbleAction;

   
    private void Awake()
    {
        GameManger.OnMovePlayerAction += GameManger_OnMovePlayerAction;
    }

    private void GameManger_OnMovePlayerAction(Vector3 position)
    {
        MovePlayer(position);
        OnDetachGrabbleAction();
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!GameManger.instance._freeze)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            float curSpeedX = walkingSpeed * Input.GetAxis("Vertical");
            float curSpeedY = walkingSpeed * Input.GetAxis("Horizontal");
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            moveDirection.y = movementDirectionY;

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            characterController.Move(moveDirection * Time.deltaTime);
        }
        
    }
    private void LateUpdate()
    {
        if (!GameManger.instance._freeze)
        {
            rotationX += -Input.GetAxis("Mouse Y") * (lookSpeedUP * Time.deltaTime);
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * (lookSpeedLeft * Time.deltaTime), 0);
        }
        
    }
    void MovePlayer(Vector3 _locCheckPoint)
    {
        transform.position = _locCheckPoint;
    }
    private void OnDisable()
    {
        GameManger.OnMovePlayerAction -= GameManger_OnMovePlayerAction;
    }
}
