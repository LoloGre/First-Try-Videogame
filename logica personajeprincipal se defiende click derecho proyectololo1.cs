public class Player : MonoBehaviour {
    public int damage = 10;
    public int maxHealth = 100;
    public float attackRange = 1.5f;
    public float moveSpeed = 5f;
    public GameObject attackEffect;
    public GameObject deathEffect;

    private int currentHealth;
    private Enemy currentEnemy;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        // Código para mover al personaje y atacar con el click izquierdo
        // ...
        
        // Código para defenderse con el click derecho si el enemigo puede defenderse
        if (Input.GetMouseButtonDown(1) && currentEnemy != null && currentEnemy.canDefend) {
            // Código para defenderse del ataque del enemigo
        }
    }
}
