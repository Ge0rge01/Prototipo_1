using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public static PlayerController sharedInstance;
    private Vector3 startPosition;
    public float maxSpeed = 10f; //Atributo del nuevo desarrollo
    public float jumpForce = 6.5f;
    private bool jump;
    private Rigidbody2D rigidbody;
    public float Speed = 1.5f;
    //public LayerMask groundLayer;
    public bool isGrounded;
    private bool doubleJump; //Variable para el uso del doble salto del pj
    public Animator animator; //probar a ponerla private

    //Se comenta de momento pero estaria bien que se probase directamente aquí en el despertar
    // private void Awake() //Se configuran los elementos que deben inicializarse antes del arranque del videojuego
    //{
    //    rigidbody = GetComponent<Rigidbody2D>();
    //  }
    private void Awake()
    {
        sharedInstance = this;
        //Toma el valor de donde empieza nuestro personaje
        startPosition = this.transform.position;
        


    }

    // Start is called before the first frame update
    public void StartGame()
    {   
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //Cada vez que reiniciamos ponemos al personaje en la startPosition
        this.transform.position = startPosition;
        animator.SetBool("isAlive", true);
        animator.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del personaje
        //if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow))) {
        //    if (rigidbody.velocity.x > -Speed){
        //        rigidbody.velocity = new Vector2(-Speed, rigidbody.velocity.y);
        //        transform.localScale = new Vector3(-1f, 1f, 1f);
        //    }
        //}

        //if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow))) {          
        //    if (rigidbody.velocity.x < Speed){
        //        rigidbody.velocity = new Vector2(Speed, rigidbody.velocity.y);
        //        transform.localScale = new Vector3(1f, 1f, 1f);
        //    }

        // }

        //El personaje salta
        // if (Input.GetKeyDown(KeyCode.Space)) //El usuario ha pulsado la tecla espacio
        //{
        //  Jump();
        //}

        //Si el usuario pulsa el boton S el personaje mira hacia abajo si su velocidad en X y en Y es 0 y si esta pisando el suelo
        //  if ((Input.GetKey(KeyCode.S)) && (rigidbody.velocity.x == 0) && (IsTouchingTheGround()))
        // {
        // }

        // if ((Input.GetKey(KeyCode.W)) && (rigidbody.velocity.x == 0) && (IsTouchingTheGround()))
        //{
        //}

        //Salto y doble salto en el pj

        if (GameManager.sharedInstance.currentGameState == GameState.InGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    jump = true;
                    doubleJump = true;
                }
                else if (doubleJump)
                {
                    jump = true;
                    doubleJump = false;
                }

            }
        }

        //Mirar hacia arriba y mirar hacia abajo
        //if(Input.GetKey(KeyCode.W) && isGrounded && Speed == 0)
        //{
            
        //}

        //if (Input.GetKey(KeyCode.S) && isGrounded && Speed == 0)
        //{

        //}

        //Compruebo en cada Frame si estoy o no tocando el suelo
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x)); //Busca el valor absoluto

    }

    //El personaje de esta forma se mueve siempre automaticamente hacia delante en el videojuego como una forma constante
    private void FixedUpdate() //Mejor implementar el movimiento dentro del fixed que se ejecuta menos que el update pero de forma fija
    {
        //if (rigidbody.velocity.x < runningSpeed) {
        //     rigidbody.velocity = new Vector2(runningSpeed, rigidbody.velocity.y);
        // }

        //Parte del movimiento correspondiente al nuevo desarrollo
        if(GameManager.sharedInstance.currentGameState == GameState.InGame) { //Solo le dejo moverse y saltar si esta en modo InGame
        float h = Input.GetAxis("Horizontal");

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //ir a izq
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        //Configuar en Edit la fuerza de la gravedad y la jumpForce
        if(jump)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        rigidbody.AddForce(Vector2.right * Speed * h);
        float limitedSpeed = Mathf.Clamp(rigidbody.velocity.x, -maxSpeed, maxSpeed);
        rigidbody.velocity = new Vector2(limitedSpeed, rigidbody.velocity.y);

        //usar la funcion matemática clamp para limitar la velocidad del pj, rango de una variable

        //  if(rigidbody.velocity.x > maxSpeed)
        // {
        //   rigidbody.velocity = new Vector2(maxSpeed,rigidbody.velocity.y);
        //}

        //if (rigidbody.velocity.x < -maxSpeed)
        //{
        //  rigidbody.velocity = new Vector2(-maxSpeed, rigidbody.velocity.y);
        //}

        Debug.Log(rigidbody.velocity.x);
        }
    }

    //void Jump ()
    //{
        //F = m*a
      //  if(IsTouchingTheGround()) //El personaje esta tocando el suelo
        //{
       // rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //}
        
    //}

    

   // bool IsTouchingTheGround()
    //{
      //  if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.8f, groundLayer))
        //{
          //  return true; //Toco el suelo
        //} else
        //{
          //  return false; //No toco el suelo
        //}
    //}

        //Metodo que mata al jugador
    public void Kill()
    {
       GameManager.sharedInstance.GameOver();
        this.animator.SetBool("isAlive", false);
    }


    

}
