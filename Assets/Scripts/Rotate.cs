using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
