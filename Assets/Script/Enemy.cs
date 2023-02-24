using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;

    void Start()
    {
    }

    void Update()
    {
        if (hp <= 0)
        {
            destroy();
        }

    }

    void destroy()
    {
        //explode animation
        Destroy(gameObject);
    }

    public void takeDamage(int dmg)
    {
        hp -= dmg;
    }
}
