using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class ZombieController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private float stoppingDistance = 1.0f;
    private Animator animator;
    public int ZombieDamage = 1;
    private static readonly int WalkTrigger = Animator.StringToHash("startwalking");
    private static readonly int AttackTrigger = Animator.StringToHash("t-pose");
    private static readonly int SitTrigger = Animator.StringToHash("idle");
    private static readonly int PushUpTrigger = Animator.StringToHash("pushup");
    private bool isAttacking = false;
    private bool onCooldown = false;

    private Coroutine healthReductionCoroutine;

    //public AudioClip spawnSound; 
    private AudioSource audioSource;
    public List<AudioClip> zombieSpawn;
    public AudioClip damageSound;

    private string animationState = "s";
    public bool isStopped = false;

    private bool hasStartedMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(SoundCentral.PlayRandomSound(zombieSpawn));


        //Debug.Log("Game started");
        agent = GetComponent<NavMeshAgent>();
        //agent.stoppingDistance = stoppingDistance;
        animator = GetComponent<Animator>();
        //TriggerSitAnimation();
    }

    void Update()
    {
        
        
        //if (!hasStartedMoving && agent.remainingDistance > 0)
        //{
        //    hasStartedMoving = true;
        //}
        agent.destination = player.position;

        if (PlayerHealth.health <= 0)
        {
            agent.isStopped = true;
            return;
        }
        //too far
        if (Vector3.Distance(agent.transform.position, player.position) >= 6.0)
        {
            agent.isStopped = true;
            isStopped = agent.isStopped;
            //Debug.Log("Too far");
            
            TriggerSitAnimation();
            //return;

        }
        //reached
        else if (Vector3.Distance(agent.transform.position, player.position) <= 1.2)
        {
            if (healthReductionCoroutine == null) // Check if coroutine is not already running
            {
                agent.isStopped = true;
                isStopped = agent.isStopped;
                //Debug.Log("Zombie has reached the player!");
                TriggerAttackAnimation();
                healthReductionCoroutine = StartCoroutine(ReducePlayerHealth()); // Start health reduction coroutine
            }
        }
        //chasing
        else
        {
            //Debug.Log("Chasing");

            agent.isStopped = false;
            TriggerWalkAnimation();
            isStopped = agent.isStopped;
            
            if (healthReductionCoroutine != null)
            {
                StopCoroutine(healthReductionCoroutine);
                healthReductionCoroutine = null;
            }
        }
        
    }

    public void TriggerWalkAnimation()
    {
        if(animationState != "w")
        {
            animationState = "w";
            animator.SetTrigger(WalkTrigger);
        }
    }

    public void TriggerAttackAnimation()
    {
        if (animationState != "a")
        {
            animationState = "a";
            animator.SetTrigger(AttackTrigger);
        }
    }

    public void TriggerSitAnimation()
    {
        if (animationState != "s")
        {
            //Debug.Log("SIT TTRIFEWOAHDFAKLDJFHAJFEDHAEDJFHEDKFHJ");
            animationState = "s";
            animator.SetTrigger(SitTrigger);
        }
    }

    public void TriggerPushUpAnimation()
    {
        if (animationState != "p")
        {
            animationState = "p";
            animator.SetTrigger(PushUpTrigger);
        }
    }
    private IEnumerator ReducePlayerHealth()
    {
        
        onCooldown = true;

        
        PlayerHealth.health -= ZombieDamage;
        //Debug.Log("Player health: " + PlayerHealth.health);
        if(audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
            //audioSource.PlayOneShot(spawnSound);
        }
        else
        {
            Debug.Log("SPeakier gaaya");
        }

        if (PlayerHealth.health <= 0)
        {
            Debug.Log("Player is dead!");
            
        }

        // Wait for the cooldown duration
        yield return new WaitForSeconds(2);

        // End cooldown
        onCooldown = false;
    }
}
