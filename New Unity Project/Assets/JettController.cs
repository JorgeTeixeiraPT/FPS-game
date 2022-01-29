using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JettController : MonoBehaviour
{
    public bool isDashing;

    private int dashAttempts;
    private float dashStartTime;

    PlayerMovement playerController;
    CharacterController characterController;
    

    void Start()
    {
        playerController.GetComponent<PlayerMovement>();
        characterController.GetComponent<CharacterController>();
    }

   
    void Update()
    {

        HandleDash();
    }

    void HandleDash()
    {
        bool isTryingToDash = Input.GetKeyDown(KeyCode.LeftShift);
        if (isTryingToDash && !isDashing)
        {
            if (dashAttempts <= 50)
            {
                OnStartDash();
            }
        }
        if (isDashing)
        {
            if (Time.time - dashStartTime <= 0.4f)
            {
            //    if (playerController.movementVector.Equals(Vector3.zero))
            //    {
            //        characterController.Move(transform.forward * 30f * Time.deltaTime);
            //    }else
            //    {
            //        characterController.Move(playerController.movementVector.normalized * 30f * Time.deltaTime);
            //    }

            }
            else
            {
                OnEndDash();
            }
        }

    }
    void OnStartDash()
    {

    }
    void OnEndDash()
    {

    }
}
