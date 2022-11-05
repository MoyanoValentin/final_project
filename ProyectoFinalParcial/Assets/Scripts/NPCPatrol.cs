using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour{
    [SerializeField] GameObject npc;
    [SerializeField] Transform[] puntosControl;
    [SerializeField] float velocidad = 5;
    [SerializeField] private GameObject npcModel;
    private Animator npcAnim;
    private Vector3 direction;
    private Quaternion generatorDirection;

    void Start(){
        npcAnim=npcModel.GetComponent<Animator>();
        StartCoroutine("MueveNPC", "He llegado al punto de control");
    }

    private void Update(){}

    IEnumerator MueveNPC(string texto){
        int i = 0;
        Vector3 nuevaPosicion = new Vector3(puntosControl[i].position.x, npc.transform.position.y, puntosControl[i].position.z);
        while (true){
            direction=puntosControl[i].transform.position-npc.transform.position;
            generatorDirection=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
            npc.transform.rotation=generatorDirection;
            while(puntosControl[i]){
                npcAnim.SetBool("Walk",true);
                npc.transform.position = Vector3.MoveTowards(npc.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                yield return null;
            }
            Debug.Log(texto);
            if (i <= 10) i++;
            else{
                npcAnim.SetBool("Walk",false);
                i = 0;
            }
            nuevaPosicion = new Vector3(puntosControl[i].position.x, npc.transform.position.y, puntosControl[i].position.z);
        }
    }
}
