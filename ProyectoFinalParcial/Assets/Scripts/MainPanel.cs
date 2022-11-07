using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour{
    //Distintas opciones 
    [Header("Options")]
    public Slider volumeFX;// Slider del volumenFx en el menu
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer; //
    public AudioSource fxSource;
    public AudioClip clickSound; // clip del audio cuando se presiona un boton
    private float lastVolume;

    //Diferentes Paneles
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    public void PlayLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    //Metodo para salir del juego cuando se presiona el boton salir
    public void ExitGame(){
        Application.Quit();
    }
    // Metodo para mutear la musica 
    public void SetMute(){
        if(mute.isOn){
            mixer.GetFloat("volMaster", out lastVolume);
            mixer.SetFloat("volMaster", -80);
        }
        else{
            mixer.SetFloat("volMaster", lastVolume);
        }
    }

    public void Awake(){
        volumeFX.onValueChanged.AddListener(ChangeVolumeFx);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    //Todos los paneles comienzan en falso, si se presiona algun boton se activa el panel
    public void OpenPanel(GameObject panel){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        panel.SetActive(true);
        PlaySoundButton();
    }

//Metodo para cambiar el volumen del maste
    public void ChangeVolumeMaster(float v){
        mixer.SetFloat("volMaster", v);
    }
    //Metodo para cambiar el volumen del volume Fx
    public void ChangeVolumeFx(float v){
        mixer.SetFloat("volFx", v);
    }
    //Metodo del sonido al clickear, lo reproduce al momento
    public void PlaySoundButton(){
        fxSource.PlayOneShot(clickSound);
    }
}