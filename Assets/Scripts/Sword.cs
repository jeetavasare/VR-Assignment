using UnityEngine;


using System.Collections.Generic;
public class Sword : MonoBehaviour
{
    public float damage = 2f; 
    public float speedThreshold = .00001f; 
    private Rigidbody rb;
    private AudioSource audioSource;
    public List<AudioClip> playerAttackSounds;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ZombieHealth zombieHealth = collision.gameObject.GetComponent<ZombieHealth>();
        //Debug.Log(collision.gameObject + "zomibe mil gaya");
        //zombieHealth.TakeDamage(10);
        
        if (collision.gameObject.CompareTag("Zombie") && PlayerHealth.health >0)
        {
            Debug.Log("Sword hit the zombie!");
            zombieHealth.TakeDamage(damage);
            audioSource.PlayOneShot(SoundCentral.PlayRandomSound(playerAttackSounds));
            // Check the sword's speed or other conditions for damage
            Rigidbody swordRb = GetComponent<Rigidbody>();
            if (swordRb != null && swordRb.velocity.magnitude > speedThreshold) 
            {
                // Apply damage to the zombie
                //ZombieHealth zombieHealth = collision.gameObject.GetComponent<ZombieHealth>();
                if (zombieHealth != null)
                {
                    zombieHealth.TakeDamage(5); // Assume you have a method to apply damage
                }
            }
        }
    }
}
