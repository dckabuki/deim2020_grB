﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBut : MonoBehaviour
{
     public void Exit()
    {
        SceneManager.LoadScene("game_start");
    }
}
