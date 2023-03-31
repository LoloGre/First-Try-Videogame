public class PlayerController : MonoBehaviour
{
    public float speed;
    public float damage;
    public int level;
    public int experience;
    public int maxExperience;
    public int health;
    public int maxHealth;
    public bool canMove;
    public bool canAttack;
    public bool canDefend;
    public TextMeshProUGUI deathWarningText;

    void Start()
    {
        level = 1;
        experience = 0;
        maxExperience = 100;
        health = 100;
        maxHealth = 100;
        canMove = true;
        canAttack = true;
        canDefend = true;
        deathWarningText.gameObject.SetActive(false); // Desactivamos el mensaje al inicio del juego
    }

    void Update()
    {
        // Movimiento del personaje con las teclas
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        if (canMove) transform.Translate(movement * speed * Time.deltaTime);

        // Ataque del personaje con el click izquierdo del ratón
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            // Buscamos al enemigo más cercano en un radio de detección
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f);
            float minDistance = Mathf.Infinity;
            GameObject closestEnemy = null;
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    float distanceToEnemy = Vector2.Distance(transform.position, hitCollider.transform.position);
                    if (distanceToEnemy < minDistance)
                    {
                        minDistance = distanceToEnemy;
                        closestEnemy = hitCollider.gameObject;
                    }
                }
            }

            // Si encontramos un enemigo, lo atacamos
            if (closestEnemy != null)
            {
                EnemyController enemyController = closestEnemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.TakeDamage(damage);
                }
            }
        }

        // Defensa del personaje con el click derecho del ratón
        if (Input.GetMouseButtonDown(1) && canDefend)
        {
            canMove = false;
            canAttack = false;
            canDefend = false;
            StartCoroutine(Defend());
        }

        // Verificación de la vida del personaje
        if (health < maxHealth * 0.15f) // Si la vida es menor al 15%
        {
            deathWarningText.gameObject.SetActive(true); // Activamos el mensaje
        }
        else
        {
            deathWarningText.gameObject.SetActive(false); // Desactivamos el mensaje
        }
    }

    // Corrutina para la defensa del personaje
    IEnumerator Defend()
    {
        yield return new WaitForSeconds(2f);
        canMove = true;
        canAttack = true;
        canDefend = true
