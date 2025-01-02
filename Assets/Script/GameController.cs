using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set;}

    float screenWidth = 8.0f;
    float screenHeight = 4.25f;


    public float ScreenWidth {get {return screenWidth; }}
    public float ScreenHeight {get {return screenHeight; }}

    [SerializeField] GameObject spawnObject;
    [SerializeField] int spawnChance = 10;
    [SerializeField] int maxSpawnChance = 30;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] float screenOffset = 3.0f;
    public float ScreenOffset {get{return screenOffset;}}

    #region Game Data
    [SerializeField] float gameTime = 10.0f;

    float remainingTime;
    
    int score = 0;
    bool isPlaying = false;
    #endregion
   



    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
        score = 0;
        remainingTime = gameTime;
        isPlaying = true;
        UpdateUI();
        
    }

    // Update is called once per frame
    void Update()
    {

        remainingTime = remainingTime - Time.deltaTime;
        UpdateUI();

        if (remainingTime <= Mathf.Epsilon){
            remainingTime = 0.0f;
            isPlaying = false;
        }


        UpdateUI();
        //Debug.Log("Remaining Time: " + (int)remainingTime);

        
        if(isPlaying)
        {
            if (Random.Range(0, maxSpawnChance) < spawnChance) 
            { 
                SpawnObject(); 
            }
        }
    }



    void SpawnObject(){
        Vector3 spawnPosition = new Vector3(
            screenWidth + screenOffset,
            Random.Range(-screenHeight, screenHeight),
            0.0f
        );


        Quaternion SpawnRotation = Quaternion.identity;
        Instantiate(spawnObject, spawnPosition, SpawnRotation);


    }


public void UpdateScore(int update){
    score = score + update;
    UpdateUI();
}

void UpdateUI(){

    scoreText.text = "Score: " + score.ToString();
    timeText.text = "Time: " + (int)remainingTime;

}



}