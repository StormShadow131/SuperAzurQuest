using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playersSpawn;
    private Animator fadeSystem;

    private void Awake()
    {
        // Get the Transform from the player's spawn point of "PlayerSpawn" tag
        playersSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        // Get the Animator component of "FadeSystem" tag
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the collider has “Player” tag
        if (collision.CompareTag("Player"))
        {
            // Launches player's reappearance coroutine
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    public IEnumerator ReplacePlayer(Collider2D collision)
    {
        // Trigger fade animation from Animator
        fadeSystem.SetTrigger("FadeIn");
        // Wait 0.8 seconds to allow the animation to run
        yield return new WaitForSeconds(0.8f);
        // Reposition the player on the spawn
        collision.transform.position = playersSpawn.position;
    }
}
