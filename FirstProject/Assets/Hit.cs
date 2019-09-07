using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private MainCharacter player;
    public float damage = 10f;
    public GameObject blood;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<MainCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthBarScript.health -= 10f;

            var player = other.GetComponent<MainCharacter>();
            player.knockbackCount = player.knockbackLenght;

            if (other.transform.position.x < transform.position.x) player.knockFromRight = true;
            else player.knockFromRight = false;
        }
    }

}
