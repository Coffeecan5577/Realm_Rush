using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Collider collisionMesh;
    [SerializeField] private int hitPoints = 3;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] private AudioClip destroyedSFX;

    private AudioSource myAudioSource;

	// Use this for initialization
	void Start ()
	{
	    myAudioSource = GetComponent<AudioSource>();
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(damageSFX);
    }

    private void KillEnemy()
    {
        // important to instantiate before destroying the object.
        var vfx =Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        AudioSource.PlayClipAtPoint(destroyedSFX, Camera.main.transform.position, 1f);
        Destroy(vfx.gameObject, 1f);
        Destroy(gameObject);
    }
}
