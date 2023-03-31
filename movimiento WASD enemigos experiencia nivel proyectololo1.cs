using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public int level = 1;
    public int experience = 0;
    public int experienceToNextLevel = 100;
    public int levelUpCostMultiplier = 2;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            AddExperience(10);
        }
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        Debug.Log("Ganaste " + amount + " puntos de experiencia!");

        if (experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
            experienceToNextLevel *= levelUpCostMultiplier;
            Debug.Log("¡Nivel incrementado a " + level + "!");
        }
    }
}
