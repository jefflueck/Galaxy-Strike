using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject destroyedVFX;

    private void OnTriggerEnter(Collider other)
    {
        // Use the other object's position (the player)
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
