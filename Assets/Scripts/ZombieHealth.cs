using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    public float health = 10f;
    private AudioSource audioSource;
    public List<AudioClip> zombieHurt;
    public AudioClip zombieDeath;
    public void TakeDamage(float damage)
    {
        audioSource = GetComponent<AudioSource>();
        //Destroy(gameObject);
        Debug.Log("Health left" + health.ToString());
        health -= damage;
        if (health > 0)
        {
            audioSource.PlayOneShot(SoundCentral.PlayRandomSound(zombieHurt));
        }
        
        Debug.Log("Zombie health: " + health);

        if (health <= 0)
        {
            //ZombieDeathSound.PlayDeathSound();
            //audioSource.PlayOneShot(zombieDeath);
            //// Handle zombie death (e.g., disable, destroy, etc.)

            //Destroy(gameObject);
            HandleZombieDeath();
        }
    }


    private void HandleZombieDeath()
    {
        PlayerHealth.playerScore += 1;
        //ZombieDeathSound.PlayDeathSound();
        audioSource.PlayOneShot(zombieDeath);


        GetComponent<Collider>().enabled = false; 
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Animator>().enabled = false; 

        
        StartCoroutine(DestroyZombieAfterDelay(1.5f)); 
    }

    private IEnumerator DestroyZombieAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        Destroy(gameObject); 
    }

}
