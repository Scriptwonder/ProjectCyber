using UnityEngine;

public class EnemyAIRobot : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float sightRange = 5f;
    public float attackRange = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, sightRange);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                player = hitCollider.gameObject.transform;
                break;
            }
        }

        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= attackRange)
            {
                // Attack player
                //Debug.Log("Attack");
            }
            else if (distance <= sightRange)
            {
                // Move towards player
                movement = player.position - transform.position;
                rb.velocity = movement.normalized * moveSpeed;
            }
            else
            {
                // Player out of sight range
                rb.velocity = Vector2.zero;
            }
        }
    }
}
