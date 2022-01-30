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
    private float speed2;
    private bool toggle=false;

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
    public GameObject player;

    public Vector3 moveDir;
    private void Start()
    {
        posicaoRespawn = gameObject.transform.position;
        vidaAtual = vidaInicial;
        speed2 = speed;
        
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

        moveDir = transform.right * x + transform.forward * z;

        controller.Move(moveDir * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (toggle == true)
            {
                toggle = false;
                
            }
            else
            {
                toggle = true;
                
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed2 * 200;
        }

        if (toggle==true)
        {
            speed = speed2 / 2;
            player.layer = 0;
        }

        if(toggle==false)
        {
            player.layer = 7;
            speed = speed2;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (imagemVida !=null)
        {
            imagemVida.fillAmount = vidaAtual / vidaInicial;
        }
    }
}
