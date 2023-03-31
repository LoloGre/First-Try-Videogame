public class EnemyController : MonoBehaviour {
    public GameObject ogrePrefab;
    public GameObject bossWizardPrefab;
    public float detectionRange = 10f;
    public float moveSpeed = 2f;

    private GameObject player;
    private List<Enemy> enemies = new List<Enemy>();

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");

        // Agregar un nuevo jefe mago a la lista de enemigos
        BossWizard bossWizard = Instantiate(bossWizardPrefab, transform.position, transform.rotation).GetComponent<BossWizard>();
        bossWizard.moveSpeed = moveSpeed;
        enemies.Add(bossWizard);
    }

    void Update() {
        // Código para detectar al jugador y mover a los enemigos
    }
}
