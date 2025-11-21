using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
