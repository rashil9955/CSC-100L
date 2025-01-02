using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{

    [SerializeField] float lifetime = 1.25f;
    





    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject , lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }






}
