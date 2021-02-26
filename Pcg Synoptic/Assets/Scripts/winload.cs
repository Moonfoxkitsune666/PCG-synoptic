using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winload : MonoBehaviour
{
    public void Loadfootballgame()
    {
        SceneManager.LoadScene(0);
    }

    public void Loadwin()
    {
        Thread.Sleep(2000);
        SceneManager.LoadScene("win");
    }
}
