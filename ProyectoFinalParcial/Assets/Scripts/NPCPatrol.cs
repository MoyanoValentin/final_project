using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour{
    [SerializeField] GameObject npc;
    [SerializeField] GameObject[] puntosControl;
    [SerializeField] float velocidad = 5;
    [SerializeField] private GameObject npcModel;
    private Animator npcAnim;
    private Vector3 direction;
    private Quaternion generatorDirection;

    void Start(){
        npcAnim=npcModel.GetComponent<Animator>();
        StartCoroutine("MueveNPC", "He llegado al punto de control");
    }

    IEnumerator MueveNPC(string texto){
        int i = 0;
        Vector3 nuevaPosicion;
        while (true){
            while(puntosControl[i].activeSelf){
                direction=puntosControl[i].transform.position-npc.transform.position;
                nuevaPosicion = new Vector3(puntosControl[i].transform.position.x, npc.transform.position.y, puntosControl[i].transform.position.z);
                npcAnim.SetBool("Walk",true);
                npc.transform.position = Vector3.MoveTowards(npc.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                generatorDirection=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
                npc.transform.rotation=generatorDirection;
                if(npc.transform.position==nuevaPosicion){
                    npcAnim.SetBool("Walk",false);
                    puntosControl[i].SetActive(false);
                }
                yield return null;
            }
            Debug.Log(texto);
            if(i <= 11){
                i++;
            }else{
                yield return false;
            }
        }
    }
}
