using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //capturamos el canvas
    public GameObject gameOver;
    //capturamos la nave
    public GameObject ship;
    //capturamos el script de la nave
    private SpaceshipMove spaceshipMove; 
    

    // Start is called before the first frame update
    void Start()
    {
       gameOver.SetActive(false);
       spaceshipMove = ship.GetComponent<SpaceshipMove>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
