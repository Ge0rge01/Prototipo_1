using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; //El objetivo a quien seguir
    public UnityEngine.Vector3 offset = new UnityEngine.Vector3(0.2f, 0.0f, -10.0f);
    public float dampTime = 0.3f;
    public UnityEngine.Vector3 velocity = UnityEngine.Vector3.zero;

    private void Awake()
    {
        //Que unity renderize al número de frames que yo le indique - no siempre lo hace claro
        Application.targetFrameRate = 60;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Que las coordenadas de la camara sigan a las que tiene el personaje
        //Las coordenadas del mundo a coordenadas de la camara
        UnityEngine.Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
        //Objetivo donde quiero ir - la cantidad del movimiento que debe de moverse
        UnityEngine.Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new UnityEngine.Vector3(offset.x, offset.y, point.z));
        UnityEngine.Vector3 destination = point + delta;
        destination = new UnityEngine.Vector3(target.position.x, offset.y, offset.z);
        //Movimiento suave de la camara
        this.transform.position = UnityEngine.Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampTime);


    }
}
