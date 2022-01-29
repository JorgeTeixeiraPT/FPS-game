using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groudDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    public float vidaInicial = 200f;
    public bool fazerRespawn = false;
    public Vector3 posicaoRespawn;
    public float vidaAtual;

    public Image imagemVida;
    
    private void Start()
    {
        posicaoRespawn = gameObject.transform.position;
        vidaAtual = vidaInicial;
        
    }
    

    public void TakeDamage(float amount)
    {
        vidaAtual -= amount;
        if (vidaAtual <= 0f)
        {
            if (fazerRespawn == true)
            {
                gameObject.transform.position = posicaoRespawn;
                vidaAtual = vidaInicial;
            }
            else
            {
                SceneManager.LoadScene("game_map1");
                //gameObject.SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groudDistance, groundMask);

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (imagemVida !=null)
        {
            imagemVida.fillAmount = vidaAtual / vidaInicial;
        }
    }
}
