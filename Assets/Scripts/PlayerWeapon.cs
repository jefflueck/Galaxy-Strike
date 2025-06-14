using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject[] lasers;
    [SerializeField]
    RectTransform crosshair;
    [SerializeField]
    Transform targetPoint;
    [SerializeField]
    float targetDistance = 100f;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value)
    {

        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;

        }
    }

    public void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            // In this line we calculate the distance between the player ship to the target point
            Vector3 fireDirection = targetPoint.position - transform.position;
            // This will calculate the rotation needed to point the laser at the target point
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            // Finally we apply the rotation to the laser
            laser.transform.rotation = rotationToTarget;
        }
    }


}
