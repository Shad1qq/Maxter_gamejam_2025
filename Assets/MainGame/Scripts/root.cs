using UnityEngine;

public class root : MonoBehaviour
{
    public float rotationSpeed = 100f; // Скорость вращения

    void FixedUpdate()
    {
        // Поворот вокруг локальной оси Y
        transform.Rotate(new Vector3 (0,0,1), rotationSpeed * Time.fixedDeltaTime);
    }
}
