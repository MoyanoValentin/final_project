using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviourScript : MonoBehaviour{
    [SerializeField]//para q se vea en el unity
    private float speedZ = 20f;

    void Update(){
        transform.Translate(0, 0, speedZ *Time.deltaTime);     
    }

    //Para que busque el Tag del enemigo y lo destruya
    private void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }
}