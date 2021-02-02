using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBut : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("zaxxon_scene1");
    }
}
