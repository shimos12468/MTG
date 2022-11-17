using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[System.Serializable]
public class EnemyStats
{
    public float Health;
    public float baseHealth;
    public float Damage;
    public float Stamina;
    public float exp;
    public int coins;
    public int points;

}

public class Pathfinder : MonoBehaviour
{
    public NavMeshAgent agent;
    public Slider slider;
    Transform player;
    public LayerMask WhatIsGround, WhatIsplayer;
    public Vector3 WalkPoint;
    public Animator anim;
    public bool WalkPointSet;
    public float WalkPointRange;
    public float stamina;
    public GameObject fire;
    public float TimeBetweenAttacks;
    public bool alreadyAttacked;
    public EnemyStats enemyStats;
    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerInAttackRange;
   
    
    void Start()
    {
        
       agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        


        PlayerInSightRange = Physics.CheckSphere(transform.position,SightRange ,WhatIsplayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsplayer);


        if (!PlayerInSightRange && !PlayerInAttackRange) Patroling();
        if (PlayerInSightRange && !PlayerInAttackRange) ChasePlayer();
        if (PlayerInSightRange && PlayerInAttackRange) AttackPlayer();
    }

    public void Patroling()
    {  
        if (!WalkPointSet) SearchWalkPoint();
        if (WalkPointSet)
        {
            agent.SetDestination(WalkPoint);
            anim.SetFloat("walk", agent.velocity.magnitude);
        }

        Vector3 distanceToWalkPoint = transform.position - WalkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            WalkPointSet = false;
            anim.SetFloat("walk", 0.01f);
        }
        
    }

    private void SearchWalkPoint()
    {
       
        float randomZ = UnityEngine.Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = UnityEngine.Random.Range(-WalkPointRange, WalkPointRange);
        WalkPoint = new Vector3(transform.position.x+randomX, transform.position.y, transform.position.z+ randomZ);

        if(Physics.Raycast(WalkPoint,-transform.up,2f, WhatIsGround))
        {
            WalkPointSet = true;
        }
    }

    public void ChasePlayer()
    {
        player = GameObject.FindGameObjectWithTag("creature").transform;
        anim.SetFloat("walk", 2f);
        agent.SetDestination(player.position);
        Vector3 distanceToWalkPoint = transform.position - player.position;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            WalkPointSet = false;
            anim.SetFloat("walk", 0.01f);
        }
        
    }
    public void AttackPlayer()
    {
        player = GameObject.FindGameObjectWithTag("creature").transform;
        //agent.SetDestination(transform.position);
        anim.SetFloat("walk", 0.01f);
        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            anim.SetBool("Attack", true);

            Invoke(nameof(RestAttack), TimeBetweenAttacks);
        }

    }

    private void RestAttack()
    {
        anim.SetBool("Attack", false);
        alreadyAttacked = false;
    }

    public void ActiaveFire()
    {
        fire.SetActive(true);
        Debug.Log("Active");
    }
    public void DecativateFire()
    {
        fire.SetActive(false);
        Debug.Log("NotActive");
    }

    public void  TakeDamage(float Damage ,Stats stat)
    {
       
        enemyStats.Health -= Damage;
        slider.value = enemyStats.Health;
        //slider.value = enemyStats.Health;
        if (enemyStats.Health <= 0)
        {


            stat.TakeExp(enemyStats.exp, enemyStats.points, enemyStats.coins);
            //set daying animation  , after that make transition to  enable material change or color change 
            gameObject.tag = "DeadEnemy";
            Destroy(this.gameObject ,10);
        }
    }

}
