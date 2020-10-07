using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyUdemy : MonoBehaviour
{

    private Animator anim;
    public float runningSpeed = 1.5f;
    private Rigidbody2D rigidbody;
    public static bool turnAround;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float currentRunningSpeed = runningSpeed;

        if(turnAround == true)
        {
            //Aqui la velocidad es positiva
            currentRunningSpeed = runningSpeed;
            this.transform.eulerAngles = new UnityEngine.Vector3(0, 180.0f, 0);
        } else {
            //Aqui la velocidad es negativa
            currentRunningSpeed = -runningSpeed;
            this.transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
        }

        if (GameManager.sharedInstance.currentGameState == GameState.InGame)
        {
           // if (this.rigidbody.velocity.x < runningSpeed && this.rigidbody.velocity.x > -runningSpeed)
            //{
                rigidbody.velocity = new UnityEngine.Vector2(currentRunningSpeed, rigidbody.velocity.y);
            //}
        }
    }
}
