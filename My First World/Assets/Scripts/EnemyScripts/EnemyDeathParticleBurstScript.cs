using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathParticleBurstScript : MonoBehaviour
{
    ParticleSystem particleref;
    
    bool once = true;
    void Start()
    {
        if (once == true)
        {
            particleref = GetComponent<ParticleSystem>();
            var em = particleref.emission;
            var dur = particleref.duration;

            em.enabled = true;
            particleref.Play();

            once = false;
            Invoke(nameof(destroyobject), dur);
        }

            
    }

    void destroyobject()
    {
        Destroy(gameObject);
    }
}
