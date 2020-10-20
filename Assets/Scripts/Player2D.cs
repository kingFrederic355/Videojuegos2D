using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    float input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move(){

        input = Input.GetAxis("Horizontal");
        
        if (input != 0)
        {
            GetComponent<Animator>().SetBool("correr",true);
            transform.Translate(0.2f*input,0,0);
            
            if (input > 0){
            GetComponent<SpriteRenderer>().flipX = false;  
            }else{
                GetComponent<SpriteRenderer>().flipX = true;  
            }    
        }else{
            GetComponent<Animator>().SetBool("correr",false);
        }
        
        
    }
}
