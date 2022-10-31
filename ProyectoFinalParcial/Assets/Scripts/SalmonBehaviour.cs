using UnityEngine;
using System.Collections;

public class SalmonBehaviour : MonoBehaviour {
    private float rotationSpeed=10;
    public Transform player;
    public Transform npc;
    public Transform npc2;
    public PlayerBehaviour playerBehaviour;
    public NPCBehaviour npcBehaviour;
    public NPC2Behaviour npc2Behaviour;

    void Start(){
        player=GameObject.FindGameObjectWithTag("CollectedSalmon").GetComponent<Transform>();
        playerBehaviour=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        npc=GameObject.FindGameObjectWithTag("NPCSalmon").GetComponent<Transform>();
        npc2=GameObject.FindGameObjectWithTag("NPC2Salmon").GetComponent<Transform>();
        npcBehaviour=GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCBehaviour>();
        npc2Behaviour=GameObject.FindGameObjectWithTag("NPC2").GetComponent<NPC2Behaviour>();
    }

	void Update (){
        transform.Rotate(new Vector3(0,0,10)*rotationSpeed*Time.deltaTime);
        if(npcBehaviour.isInNpc && transform.parent.name=="CollectedSalmon"){
            transform.parent=npc.transform;
            transform.position=npc.position;
            transform.rotation=npc.rotation;
        }
        if(npc2Behaviour.isInNpc && transform.parent.name=="CollectedSalmon"){
            transform.parent=npc2.transform;
            transform.position=npc2.position;
            transform.rotation=npc2.rotation;
        }
    }

    void OnTriggerEnter(Collider other){
        playerBehaviour.hasSalmon++;
        transform.parent=player.transform;
        rotationSpeed=0;
        gameObject.GetComponent<BoxCollider>().enabled=false;
        transform.position=player.position;
        transform.rotation=player.rotation;
        transform.localScale=player.localScale;
    }
}