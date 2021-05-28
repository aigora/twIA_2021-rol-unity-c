using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject Hero;
  public void PlayGame()
    {
        SceneManager.LoadScene("Mapa");
        //Instantiate(Hero, new Vector3(-50,-2,0), Quaternion.identity); (Intento raro de hacer un arreglo de un bug)
    }
    public void QuitGame()
    {
        Debug.Log("Closes");
        Application.Quit();
    }
}
