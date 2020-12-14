using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    [SerializeField] Transform Tarjet;
    
    //Variables necesarias para la opción de suavizado en el seguimiento
    [SerializeField] float smoothVelocity = 0.3F;
    private Vector3 camaraVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(Tarjet);
        //hacemos que la cámara siga al tarjet
        //transform.position = new Vector3(Tarjet.position.x, Tarjet.position.y +0.5f, Tarjet.position.z - 2);

         //Estas líneas de código hacen que la cámara siga al objeyivo (targetPosition) con suavidad (smoothVelocity)
        Vector3 targetPosition = new Vector3(Tarjet.position.x, Tarjet.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
    }
}
