using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCollisionIzq : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Collider colliderIzq;
    private Text myText;
    private Image myImage;
    public GameObject uiObject;
    public GameObject uiObjectImage;

    //private void Awake()
    //{
    //    sharedInstance = this;
    //    //Toma el valor de donde empieza nuestro personaje
    //    startPosition = this.transform.position;
    //}

    public void StartGame()
    {
        colliderIzq = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody2D>();
        uiObject.SetActive(false);
        uiObjectImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {

    }



    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            Debug.Log("El player ha colisionado");
            uiObject.SetActive(true);
            uiObjectImage.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
           Debug.Log("Continua colisionando");
            uiObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
         if (otherCollider.tag == "Player")
         {
          Debug.Log("El player ha dejado de colisionar");
            uiObject.SetActive(false);
            uiObjectImage.SetActive(false);
        }
    }



}
