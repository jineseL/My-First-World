using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int attackDamage;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemies"))
        {
            //hit(collider, attackdamage);
            collider.GetComponent<EnemyBehaviour>().damage(attackDamage);
        }
    }
    /*public void hit(Collider2D enemy, int damage)
    {
        enemy.GetComponent<EnemyBehaviour>().health -= attackdamage;
        enemy.GetComponent<EnemyBehaviour>().damage();
    }*/
}
