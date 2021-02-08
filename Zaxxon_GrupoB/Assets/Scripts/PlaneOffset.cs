using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOffset : MonoBehaviour
{

    //componente de tipo renderer 
    Renderer rend;
    //vector de desplazamiento
    [SerializeField] Vector2 despl;
    //datos de juego
    SpaceshipMove initgame;
    
    // Start is called before the first frame update
    void Start()
    {
        //asignamos el componente renderer
        rend = GetComponent<Renderer>();

        //obtener el script 
        GameObject InitEmpty = GameObject.Find("Spaceship");
        initgame = InitEmpty.GetComponent<SpaceshipMove>();
    }

    // Update is called once per frame
    void Update()
    {
    //velocidad desplazamiento
     float scrollSpeed = initgame.speed/-6f;
    //desplazamiento segun tiempo
     float offset = Time.time * scrollSpeed;
    //vector desplazamiento
     despl = new Vector2(0, offset);
    //desplazar texturas
     rend.material.SetTextureOffset("_MainTex", despl); 
     rend.material.SetTextureOffset("_BumpMap", despl);     
    }
}
