public class PlayerController : MonoBehaviour
{
    public string playerName = "Campesino";
    public int damage = 10;
    public int maxHealth = 100;
    public int currentHealth;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = col.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
            if (enemy.currentHealth <= 0)
            {
                GainExperience(10);
            }
        }
    }

    void GainExperience(int experience)
    {
        experiencePoints += experience;
        if (experiencePoints >= nextLevelExperience)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        nextLevelExperience *= 2;
        maxHealth += 10;
        currentHealth = maxHealth;
        damage += 2;
    }

    // rest of the code
}
