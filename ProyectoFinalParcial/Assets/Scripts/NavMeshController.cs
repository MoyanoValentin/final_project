using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform objetivo;
    public NavMeshAgent agente;

    void Start()
    {

        agente = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        agente.destination = objetivo.position;

    }
}
