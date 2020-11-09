using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    [SerializeField] Transform Tarjet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Tarjet);
        //hacemos que la cámara siga al tarjet
        transform.position = new Vector3(Tarjet.position.x, Tarjet.position.y +0.5f, Tarjet.position.z - 2);
    }
}
