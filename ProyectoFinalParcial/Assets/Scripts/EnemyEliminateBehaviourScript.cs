using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEliminateBehaviourScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("bala"))
        {
            Destroy(gameObject);
        }

    }
}
