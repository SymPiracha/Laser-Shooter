using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Details")]
    [SerializeField] float health = 100f;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] int enemyPoints = 125;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [Header("VFX Details")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [Header("Sound")]
    [SerializeField] AudioClip enemyLaser;
    [SerializeField] [Range(0f, 1f)] float laserSoundVolume = 0.5f;
    [SerializeField] AudioClip enemyDeath;
    [SerializeField] [Range(0f,1f)]float deathSoundVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position,Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyLaser, Camera.main.transform.position, laserSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        //Process hitd
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if ( health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(enemyPoints);
        Destroy(gameObject);
        GameObject explosionParticles = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosionParticles, durationOfExplosion);
        AudioSource.PlayClipAtPoint(enemyDeath, Camera.main.transform.position,deathSoundVolume);
    }
}
