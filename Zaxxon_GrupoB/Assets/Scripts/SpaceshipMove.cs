using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI


public class SpaceshipMove : MonoBehaviour
{
    //codigo para la colision. Ojo, el objeto tiene que tener un rigid body y los obstáculos is trigger activo
    [SerializeField] MeshRenderer myMesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            myMesh.enabled = false;
            //con este segmento paramos la corrutina y la velocidad
            StopCoroutine("Distancia");
            speed = 0f;
        }
    }
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed;

    //AudioSource
    private AudioSource audioSource;


    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    [SerializeField] Text TextSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        StartCoroutine("Speed");


        //asocio componente de audio
        audioSource = GetComponent<AudioSource>();
      


    }


    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();

        //Dispara el sonido al pulsar space
        if (Input.GetKeyDown("space"))
        {
            audioSource.Play();
        }


    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 1 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n += 1)
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n * speed;

            //Con esto hacemos que la nave vaya aumentando velocidad
            if (speed < 20f)
            {
                speed = speed + 0.2f;
            }
            //Ejecuto cada ciclo esperando un cuarto de segundo
            yield return new WaitForSeconds(0.25f);
        }
    }

    IEnumerator Speed()
    {
        for (int s = 0; ; s += 5)
        {
            TextSpeed.text = "SPEED:" + speed * 5f;
            yield return new WaitForSeconds(1f);
        }
    }


    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        //limitar movimiento en x
        if (transform.position.x < -7f && desplX < 0f)
        {
            desplX = 0f;
        }
        else if (transform.position.x > 4f && desplX > 0f)
        {
            desplX = 0f;  
        }

        float desplY = Input.GetAxis("Vertical");
        //limitar movimiento en y
        if (transform.position.y < 0.1f && desplY < 0f)
        {
            desplY = 0f;
        }
        else if (transform.position.y > 4f && desplY >0f)
        {
            desplY = 0f;
        }
        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);

        
        
    }
}
