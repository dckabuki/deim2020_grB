using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //---SCRIPT ASOCIADO AL EMPTY OBJECT QUE CREARÁ LOS OBSTÁCULOS--//

    //Variable que contendré el prefab con el obstáculo
    [SerializeField] GameObject Columna;

    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumber;
    Vector3 RandomPos;
    Vector3 InitCol;

 //Acceder a los componentes de la nave
    public GameObject Nave;
    private SpaceshipMove spaceshipMove;

    // Start is called before the first frame update
   
    void Start()
    {
        //Accedo al script de la nave
        spaceshipMove = Nave.GetComponent<SpaceshipMove>();

        {//Para crear 15 columnas antes de las del instanciador. 
            //En el repositorio de Álvaro hay otro método más sencillo, mirar
            for (int i =1; i< 15; i++)
                {
                randomNumber = Random.Range(-4.25f, 7f);
                InitCol = new Vector3(randomNumber, 0, i*-5);
                Vector3 newPosition = InitPos.position + InitCol;
                Instantiate(Columna, newPosition, Quaternion.identity);
                }
             }
        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");
    

    }

    //Función que crea una columna en una posición Random
    void CrearColumna()
    {
        randomNumber = Random.Range(-4.25f, 7f);
        RandomPos = new Vector3(randomNumber, 0, 0);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            //para crear columnas. La velocidad de generación depende de la distancia entre columnas (4) y la velocidad de la nave
            CrearColumna();
            //la variable interval sirve para dar frecuencia a la corrutina
            float interval = 4 / spaceshipMove.speed;
            yield return new WaitForSeconds(interval);
        }

    }
   
}


