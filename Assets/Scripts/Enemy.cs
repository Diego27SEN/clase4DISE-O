using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float range = 5f;
    public float speed = 3f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= range)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        if (player != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}