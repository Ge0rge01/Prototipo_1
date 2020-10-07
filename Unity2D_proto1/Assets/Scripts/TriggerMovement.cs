using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovement : MonoBehaviour
{

    public bool movingForward;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Se hace para poner etiquetas a objetos y que el enemigo no gire ante ellos
        //if(otherCollider.tag == "item")
        //{
        //    return;
        //}

        if(movingForward == true)
        {
            EnemyUdemy.turnAround = true;
        } else
        {
            EnemyUdemy.turnAround = false;
        }

        movingForward = !movingForward;
    }
}
