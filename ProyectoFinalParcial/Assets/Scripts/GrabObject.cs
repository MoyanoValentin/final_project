using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public GameObject handPoint; //Referencia al hanPoint ya que es donde cogeremos el objeto.

    private GameObject pickedObject = null; //Referencia para saber si tenemos un objeto ya agarrado, comienza en null porque no tendremos nada en un principio.


    void Update()
    {
        // Condicional si es que tenemos un objeto encima

        if (pickedObject != null)
        {
            if (Input.GetKeyDown("r")) // si pulsamos la r suelta el objeto y lo tiene que devolver al estado original.
            {
                pickedObject.GetComponent<Rigidbody>().useGravity = true; // Se devuelve la gravedad, referencia a picked object (objeto que tiene en la mano).

                pickedObject.GetComponent<Rigidbody>().isKinematic = false; // Se quita el kinematic, referencia a picked object

                pickedObject.gameObject.transform.SetParent(null); // El parent sera null

                pickedObject = null; // Quitar el objeto de la mano (null significa que no hay ningun objeto agarrado).
            }

        }


    }

    // Metodo OntriggerStay para poder detectar el objeto y saber si se puede agarrar
    private void OnTriggerStay(Collider other)
    {
        // Pregunta condicional para preguntar si el objeto tiene el Tag Points para saber que estamos cerca y poder agarrarlo.

        if (other.gameObject.CompareTag("Points"))
        {
            if (Input.GetKey("e") && pickedObject == null) // Pregunta si hemos pulsado una tecla (tecla e) para agarrar el objeto y mientras no tenga otro objeto agarrado.
            {
                other.GetComponent<Rigidbody>().useGravity = false; // Desactivamos la gravedad cuando agarramos un objeto

                other.GetComponent<Rigidbody>().isKinematic = true; // Activamos isKinematic 

                other.transform.position = handPoint.transform.position; // El objeto se transfiere (traslada) al punto de nuestro handPoint

                other.gameObject.transform.SetParent(handPoint.gameObject.transform); //Setea el el parent del handpoint

                pickedObject = other.gameObject; // Referencia de other a pickedObject

            }

        }
    }
}
