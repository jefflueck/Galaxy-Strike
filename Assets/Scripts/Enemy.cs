using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject destroyedVFX;
    [SerializeField]
    int hitPoints = 6;
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            // Optionally, you can also play a sound effect here if you have one.
            Destroy(gameObject);
        }
    }
}

