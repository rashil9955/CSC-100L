using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float ScreenHeight;

    [SerializeField] float moveSpeedY = 10.0f;



    void Start(){

        ScreenHeight = GameController.Instance.ScreenHeight;

    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        float positionY  = transform.position.y + (directionY * moveSpeedY * Time.deltaTime);
        
        positionY = Mathf.Clamp(positionY, -ScreenHeight, ScreenHeight);


        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);

  

    }

    void OnCollisionEnter2D(Collision2D other){
       // if(other.gameObject.tag.Equals("Enemy")){
            Debug.Log("Player collided with Enemy");
        }
    //}


}
