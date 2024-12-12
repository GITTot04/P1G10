using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[10];
    int currentEnemyIndex = 0;
    GameObject enemyHealthText;
    GameObject currentEnemy;

    private void Awake()
    {
        enemyHealthText = GameObject.Find("EnemyHealthText");
    }
    private void Start()
    {
        SpawnNextEnemy();
    }
    public void SpawnNextEnemy()
    {
        Instantiate(enemies[currentEnemyIndex]);
        currentEnemyIndex++;
    }
    public void UpdateEnemyHealthText()
    {
        currentEnemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealthText.GetComponent<TextMeshProUGUI>().text = "Modstanderens liv: " + currentEnemy.GetComponent<EnemyScript>().hp + "/" + currentEnemy.GetComponent<EnemyScript>().maxHP;
    }
}
