using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour

{
    private Enemy enemy;
    public float damage = 10f;
    public LayerMask target;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy.Destroy(gameObject);
    }
}
