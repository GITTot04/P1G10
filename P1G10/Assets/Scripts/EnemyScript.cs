using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public int maxHP;
    public int hp;
    private void Start()
    {
        hp = maxHP;
        GameObject.Find("EnemyHealthText").GetComponent<TextMeshProUGUI>().text = "Modstanderens liv: " + hp + "/" + maxHP;
    }
}
