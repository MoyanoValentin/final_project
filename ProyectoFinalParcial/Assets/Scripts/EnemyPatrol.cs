using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] GameObject Enemigo;
    [SerializeField] Transform[] puntosControl;
    [SerializeField] float velocidad = 1;

    void Start()
    {
        StartCoroutine("MueveEnemigo", "He llegado al punto de control");

    }

   
    private void Update()
    {
        
    }

    IEnumerator MueveEnemigo(string texto)
    {
        int i = 1;
        Vector3 nuevaPosicion = new Vector3(puntosControl[i].position.x, Enemigo.transform.position.y, puntosControl[i].position.z);
        while (true)
        {
            while(Enemigo.transform.position != nuevaPosicion)
            {
                Enemigo.transform.position = Vector3.MoveTowards(Enemigo.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                yield return null;
            }
            Debug.Log(texto);
            yield return StartCoroutine("RotaEnemigo");
            if (i < 3) i++; else i = 0;
            nuevaPosicion = new Vector3(puntosControl[i].position.x, Enemigo.transform.position.y, puntosControl[i].position.z);

        }

    }

    IEnumerator RotaEnemigo()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        for(int i = 1; i <= 90; i++)
        {
            Enemigo.transform.Rotate(0, -1, 0);
            yield return null;
        }
    }
}
