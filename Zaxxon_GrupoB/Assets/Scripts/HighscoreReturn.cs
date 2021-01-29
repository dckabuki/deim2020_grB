using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreReturn : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("game_start");
    }
}
