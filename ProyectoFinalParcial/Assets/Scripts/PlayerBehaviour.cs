using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour{
    private float speed=10;
    private float rotationSpeed=200;
    [SerializeField]public int hasSalmon=0;
    [SerializeField]public bool isLive=true;
    private Animator cat;
    private float jumpForce;
    private Rigidbody physiscsBody;
    bool floorDetected = true;

    void Start(){
        cat=GameObject.FindGameObjectWithTag("Cat").GetComponent<Animator>();
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        jumpForce = 5f;
        physiscsBody = GetComponent<Rigidbody>();
    }

    void Update(){
        MoverGato();
        SaltarGato();
    }

    public void MoverGato(){
        float moveX=Input.GetAxis("Horizontal");
        float moveZ=Input.GetAxis("Vertical");
        float rotateY=Input.GetAxis("Mouse X");
        Vector3 movement=new Vector3(moveX,0,moveZ).normalized;
        switch(isLive){
            case true:{
                transform.Translate(movement*speed*Time.deltaTime);
                transform.Rotate(new Vector3(0,rotateY,0)*rotationSpeed*Time.deltaTime);
                AnimarGato();
                break;
            }
            case false:{
                Destroy(gameObject);
                cat.SetBool("Walk",false);
                break;
            }
        }
    }

    public void SaltarGato()
    {
        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 1.08f))
        {
            floorDetected = true;
        }
        else
        {
            floorDetected = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && floorDetected == true)//si se preciona la barra y el personaje esta en el suelo podra realizar el salto
        {
            physiscsBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void AnimarGato(){
        if(Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal")!=0){
            cat.SetBool("Walk",true);
        }else{
            cat.SetBool("Walk",false);
        }
    }

    public int HasSalmon {get => hasSalmon; set => hasSalmon=value;}
}