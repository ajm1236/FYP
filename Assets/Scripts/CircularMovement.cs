using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField]
    public float angularSpeed = 2f;
    public float angle = 0f;
    public Transform center;
    public float radius = 20f;

    private void Awake()
    {
        transform.position = this.transform.position;
    }
    void Update()
    {
        // maths equation to create a direction for the platform that makes it move in a circular postion around a center
        angle += Time.deltaTime * angularSpeed;
        Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.up;
        transform.position = center.position + (direction * radius);
    }
}
