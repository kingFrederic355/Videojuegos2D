using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float input;
    float thrust;
    public KeyCode jump;
    public float jumpForce;
    int doubleJump;
    public GameObject bulletprefab;
    float bulletForce;
    bool canShoot;
    Vector2 bulletSpeed;
    public KeyCode shootKey;
    int timer;
    
    void Start(){
        thrust = 10f;
        doubleJump = 0;
        bulletForce = 1;
        canShoot = true;
        bulletSpeed = new Vector2(0,5);

        timer = 0;
    }

    void Update()
    {
        Move();
        Jump();

        timer ++;
        
        if(timer == 100){
            timer = 0;
            canShoot = true;

        }
        Shoot();
    }
      void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Floor") {
            Debug.Log("Piso");
            doubleJump = 2;
        }
    }
    void Move(){
        input = Input.GetAxis("Horizontal");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(input * thrust, GetComponent<Rigidbody2D>().velocity.y);  
    }

    void Jump(){
        if (Input.GetKeyDown(jump) && doubleJump > 0){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
            doubleJump--;
        }
    }
    void Shoot(){
        if (canShoot && Input.GetKeyDown(shootKey)){
            GameObject bullet = Instantiate(bulletprefab) as GameObject;
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            bullet.transform.position = new Vector2(transform.position.x, transform.position.y);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1) * bulletForce);    
        }
        
        canShoot = false;
    }
}