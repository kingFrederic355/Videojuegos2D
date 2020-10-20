using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float thrust;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(thrust, GetComponent<Rigidbody2D>().velocity.y);  
    }
    void OnCollisionENter2D(Collision2D collision){
        if(collision.collider.tag == "Muro"){
            thrust *= -1;
        }
        
    }
}
