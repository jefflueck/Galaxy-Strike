using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float controlSpeed = 50f; // Speed of movement

    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
    }


    public void OnMove(InputValue value)
    {
        Debug.Log("OnMove called with value: " + value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;

        transform.localPosition = new Vector3(transform.localPosition.x + xOffset, transform.localPosition.y + yOffset, 0f);
    }

}
