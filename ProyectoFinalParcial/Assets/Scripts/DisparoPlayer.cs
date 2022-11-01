using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBall;
    [SerializeField]
    private GameObject a;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time>shotRateTime)
            { 
                GameObject newPlayerBall;

                  newPlayerBall= Instantiate(playerBall,transform.position, transform.rotation);
                  shotRateTime = Time.time + shotRate;
                   Destroy(newPlayerBall, 2);
            }
        }
    }
}
