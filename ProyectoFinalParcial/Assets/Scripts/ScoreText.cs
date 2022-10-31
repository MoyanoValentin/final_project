using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private PlayerBehaviour player;

    public void Start(){
        scoreText.GetComponent<TextMeshProUGUI>();
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    public void Update(){
        scoreText.text=player.hasSalmon.ToString()+"/10";
    }
}
