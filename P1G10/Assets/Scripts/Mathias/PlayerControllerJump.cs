using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJump : MonoBehaviour
    
{
    //variables

    public Rigidbody2D body;
    // Jump vector coordinates for the good jump
    public int jumpXSpeed;
    public int jumpYSpeed;
    // Jump vector coordinates for the bad jump
    public int jumpXSpeed2;
    public int jumpYSpeed2;

    public int HP;
    public Sprite heartEmpty;
    public Animator animator;
    Vector2 lastVelocity;
    GameObject gameController;
    GameObject ui;
    GameObject restartButton;
    GameObject endscreenButton;
    public GameObject LevelPrefab;
    public float newLevelLocation;
    private void Awake()
    {
        // Setting up the Danok System
        restartButton = GameObject.Find("RestartButton");
        endscreenButton = GameObject.Find("OpenEndscreenButton");
        restartButton.SetActive(false);
        endscreenButton.SetActive(false);
    }
    void Start()
    {
        // HP tracker + Danok keyboard and word
        HP = 3;
        gameController = GameObject.Find("GameMaster");
        ui = GameObject.FindGameObjectWithTag("UI");
    }
    void Update()
    {
        // Saving the last velocity, to use for the bad jump
        lastVelocity = body.velocity;
    }

    // Method used when the correct answer is input. It makes the frog leap over
    // the obstacle by creating a new velocity vector based on the jump speed variables.
    public void goodJump() 
    {
        body.velocity = new Vector2(jumpXSpeed, jumpYSpeed);
        ui.SetActive(false);
        animator.Play("frog_goodJump");
    }

    // Method used when the wrong answer is input. It makes the frog jump into
    // the obstacle by creating a new velocity vector based on the secondary jump speed variables.
    public void badJump() 
    {
        body.velocity = new Vector2(jumpXSpeed2, jumpYSpeed2);
        ui.SetActive(false);
        animator.Play("frog_badJump");
    }

    // Method for handeling collisions. The first part of the "if" statment handles collisions with obstacles
    // after a bad jump. The second part stops movement on collision with the ground.
    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Handeling collision with obstacles + ground
        if (coll.gameObject.tag == "Obstacle")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            body.velocity = direction * Mathf.Max(speed, 0f);

            HP -= 1;
            updateHealth();
        }
        else if (coll.gameObject.tag == "Ground")
        {
            body.velocity = new Vector2(0, 0);
            ui.SetActive(true);
            if (HP != 0)
            {
                gameController.GetComponent<GameController>().PlayCoroutine();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PrefabLoader")
        {
            Instantiate(LevelPrefab, new Vector3(collision.transform.parent.transform.position.x + newLevelLocation, collision.transform.parent.transform.position.y, collision.transform.parent.transform.position.z), collision.transform.parent.transform.rotation);
        }
    }

    // A swich command keeping track of the players health and changing the healthbar sprite accordingly.
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
                restartButton.SetActive(true);
                endscreenButton.SetActive(true);
                break;
        }
    }

    // Methods for playing different animations, these are triggered using an "end" event on the animations
    void frogIdle() 
    {
        animator.Play("frog_idle");
    }
    void frogSplat()
    {
        animator.Play("frog_splat");
    }
}
