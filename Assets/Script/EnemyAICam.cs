using UnityEngine;

public class EnemyAICam : MonoBehaviour
{
    public Transform player;
    public float sightRange = 10f;
    public float attackRange = 5f;

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
                if (!Physics.Linecast(this.transform.position, player.position)) {
                    //send a missile TODO

                }
                //Debug.Log("Attack");
            }
            else
            {
            }
        }
    }
}
