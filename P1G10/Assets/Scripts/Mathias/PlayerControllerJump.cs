using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerJump : MonoBehaviour
{
    public Rigidbody2D body;
    public int jumpXSpeed;
    public int jumpYSpeed;
    public int jumpXSpeed2;
    public int jumpYSpeed2;
    public int HP;
    public Sprite heartEmpty;
    public Animator animator;
    Vector2 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = body.velocity;
        goodJump();
        badJump();
        if (HP == 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void goodJump() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            body.velocity = new Vector2(jumpXSpeed,jumpYSpeed);
            
            animator.Play("frog_goodJump");
            
           
        }
    }

    void badJump() 
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            body.velocity = new Vector2(jumpXSpeed2, jumpYSpeed2);
            animator.Play("frog_badJump");
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            body.velocity = direction * Mathf.Max(speed, 0f);

            HP -= 1;
            updateHealth();

            Debug.Log(HP);
        }
        else if (coll.gameObject.tag == "Ground")
        {
            body.velocity = new Vector2(0, 0);
            /*animator.Play("frog_splat");*/
        }
    }
    void updateHealth() 
    {
        switch (HP) 
        {
            case 3:
                break;

            case 2:
                GameObject.Find("Heart 1").GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;

            case 1:
                GameObject.Find("Heart 2").GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;

            case 0:
                GameObject.Find("Heart 3").GetComponent<SpriteRenderer>().sprite = heartEmpty;
                break;
        }
    }

    void frogIdle() 
    {
        animator.Play("frog_idle");
    }
    void frogSplat()
    {
        animator.Play("frog_splat");
    }
}
