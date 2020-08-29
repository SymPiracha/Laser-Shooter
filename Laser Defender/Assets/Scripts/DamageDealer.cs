using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
   
    public int GetDamage()
    {
        return this.damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}

