using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDash : MonoBehaviour
{
    PlayerMovement move;

    public float dashSpeed;
    public float dashTime;
    void Start()
    {
        move = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
        
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            move.controller.Move(move.moveDir * dashSpeed * Time.deltaTime);
            yield return null;
        }
        
    }


}
