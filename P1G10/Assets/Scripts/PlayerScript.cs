using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int damage = 2;
    GameObject gameController;
    private void Start()
    {
        gameController = GameObject.Find("GameMaster");
    }
    public void DoDamage()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy.GetComponent<EnemyScript>().hp -= damage;
        gameController.GetComponent<EnemyController>().UpdateEnemyHealthText();
        if (enemy.GetComponent<EnemyScript>().hp <= 0)
        {
            Destroy(enemy);
            gameController.GetComponent<EnemyController>().SpawnNextEnemy();
        }
    }
}
