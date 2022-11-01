using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBall;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(playerBall, transform.position, transform.rotation);
        }
    }
}
