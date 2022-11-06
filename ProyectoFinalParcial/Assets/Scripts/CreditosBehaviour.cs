using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosBehaviour : MonoBehaviour
{
    
    void Start()
    {
       Invoke("WaitToEnd",21);//Espera 21 segundos para pasar a la escena de menu
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))//si se presiona la tecla Escape nos tira el main menu
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }

     public void WaitToEnd()
     {
        
        SceneManager.LoadScene("MainMenu");

     }
}
