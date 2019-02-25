using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void Task1()
    {
        SceneManager.LoadScene("Task1");
    }

    public void Task2()
    {
        SceneManager.LoadScene("Task2");
    }

    public void Task3()
    {
        SceneManager.LoadScene("Task3");
    }

    public void Back()
    {
        SceneManager.LoadScene("Selection");
    }
}
