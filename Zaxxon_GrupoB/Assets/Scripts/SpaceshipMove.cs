using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI


public class SpaceshipMove : MonoBehaviour
{
    //capturamos el canvas
    public GameObject endCanvas;
    //capturamos el script
    private GameOver gameOver;
    //capturamos prefab explosion
    public Transform explosionPrefab;
    //variable para saber si estamos vivos
    private bool alive = true;

    //capturar sonidos
    [SerializeField] AudioClip disparo1;
    [SerializeField] AudioClip motores;
    [SerializeField] AudioClip boom;

    //codigo para la colision. Ojo, el objeto tiene que tener un rigid body y los obstáculos is trigger activo
    [SerializeField] MeshRenderer myMesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            myMesh.enabled = false;
            alive = false; 
            //con este segmento paramos la corrutina y la velocidad
            StopCoroutine("Distancia");
            speed = 0f;
            //llamamos al canvas a los 2 segundos de colisionar
            Invoke("showCanvas", 2f);
            //stop musica
            audioSource.Stop();
            //explosion
            audioSource.PlayOneShot(boom,6f);
            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
            

        }
    }

    void showCanvas()
    {
        //activamos el canvas
        endCanvas.SetActive(true);
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
    //capturamos el texto de score
    [SerializeField] Text TextScore;

    // Start is called before the first frame update
    void Start()
    {

    
        speed = 3f;
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
        StartCoroutine("Speed");


        //asocio componente de audio
        audioSource = GetComponent<AudioSource>();
        //asociamos componente del canvas
        gameOver = GetComponent<GameOver>();


        audioSource.PlayOneShot(motores, 1f);

    }


    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();
        


        //Dispara el sonido al pulsar space
        if (Input.GetKeyDown("space"))
        {
            audioSource.PlayOneShot(disparo1);
        }


    }
    

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 1 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for(int n = 0; ; n += 1)
        {
            float distance;
            distance = n * speed; 
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCE: " + distance.ToString("F0");
            TextScore.text = "SCORE = " + distance.ToString("F0") + " POINTS" ;

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
        for (int s = 0; ; s += 6)
        {
            float completeSpeed;
            completeSpeed = speed * 5f;
            TextSpeed.text = "SPEED:" + completeSpeed.ToString("f0");
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
        if (transform.position.x < -5f && desplX < 0f)
        {
            desplX = 0f;
        }
        else if (transform.position.x > 5f && desplX > 0f)
        {
            desplX = 0f;  
        }

        float desplY = Input.GetAxis("Vertical");
        //limitar movimiento en y
        if (transform.position.y < 0.2f && desplY < 0f)
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

        //rotacion (de Iris)
        transform.rotation = Quaternion.Euler(0, 0, desplX * -20);
    }
}
