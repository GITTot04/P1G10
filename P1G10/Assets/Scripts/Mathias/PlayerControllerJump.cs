using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    GameObject gameController;
    GameObject ui;
    GameObject restartButton;
    public GameObject LevelPrefab;
    public float newLevelLocation;
    private void Awake()
    {
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);
    }
    void Start()
    {
        HP = 3;
        gameController = GameObject.Find("GameMaster");
        ui = GameObject.FindGameObjectWithTag("UI");
    }
    void Update()
    {
        lastVelocity = body.velocity;
    }
    public void goodJump() 
    {
        body.velocity = new Vector2(jumpXSpeed, jumpYSpeed);
        ui.SetActive(false);
        animator.Play("frog_goodJump");
    }

    public void badJump() 
    {
        body.velocity = new Vector2(jumpXSpeed2, jumpYSpeed2);
        ui.SetActive(false);
        animator.Play("frog_badJump");
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
