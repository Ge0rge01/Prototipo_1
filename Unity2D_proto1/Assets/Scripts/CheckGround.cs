using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Grounded")
        //{
            player.isGrounded = true;
        //}

       // if (collision.gameObject.tag == "Ground")
        //{
          //  player.isGrounded = true;         
        //}
        //if(collision.gameObject.tag == "Platform")
        //{
          //  player.transform.parent = collision.transform;
           // player.isGrounded = true;
        //}
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Comprobar que estos if funcionan correctamente, porque no se cambiaba la animacion
       // if (collision.gameObject.tag == "Grounded")
        //{
            player.isGrounded = false;
        //}

       // if (collision.gameObject.tag == "Ground")
        //{
          //  player.isGrounded = true;
        //}
        //if (collision.gameObject.tag == "Platform")
        //{
        //
          //  player.transform.parent = null;
            //player.isGrounded = true;
        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "GroundKill")
        {
            Debug.Log("El jugador ha entrado en la zona de la muerte");
            PlayerController.sharedInstance.Kill();
        }

    }

}
