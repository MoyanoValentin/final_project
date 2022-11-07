using UnityEngine;
using System.Collections;

public class SalmonScene2 : MonoBehaviour {
    private float rotationSpeed=10;
    public Transform player;
    public Transform npc;
    public Transform npc2;
    public PlayerBehaviour playerBehaviour;
    public NPCBehaviour npcBehaviour;
    public NPC2Behaviour npc2Behaviour;
    public AudioSource controlSonido;
    public AudioClip sonidoSalmon;

    void Start(){
        player=GameObject.FindGameObjectWithTag("CollectedSalmon").GetComponent<Transform>();
        playerBehaviour=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        npc2=GameObject.FindGameObjectWithTag("NPC2Salmon").GetComponent<Transform>();
        npc2Behaviour=GameObject.FindGameObjectWithTag("NPC2").GetComponent<NPC2Behaviour>();
    }

	void Update (){
        transform.Rotate(new Vector3(0,0,10)*rotationSpeed*Time.deltaTime); //rota el objeto
        if(npc2Behaviour.isInNpc && transform.parent.name=="CollectedSalmon"){ //mueve el salmón al parent del NPC 2
            transform.parent=npc2.transform;
            transform.position=npc2.position;
            transform.rotation=npc2.rotation;
        }
    }

    void OnTriggerEnter(Collider other){
        playerBehaviour.hasSalmon++; //aumenta el contador de salmones
        transform.parent=player.transform; //mueve un salmón al parent del Jugador
        rotationSpeed=0;
        gameObject.GetComponent<BoxCollider>().enabled=false; //desactiva la colisión del salmón
        transform.position=player.position;
        transform.rotation=player.rotation;
        transform.localScale=player.localScale;
        controlSonido.PlayOneShot(sonidoSalmon);
    }
}