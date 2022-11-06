using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    public void PlayLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame(){
        Application.Quit();
    }

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

    public void OpenPanel(GameObject panel){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        panel.SetActive(true);
        PlaySoundButton();
    }

    public void ChangeVolumeMaster(float v){
        mixer.SetFloat("volMaster", v);
    }
    public void ChangeVolumeFx(float v){
        mixer.SetFloat("volFx", v);
    }

    public void PlaySoundButton(){
        fxSource.PlayOneShot(clickSound);
    }
}