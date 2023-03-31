using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public int maxHealth = 100;
    public int currentHealth;
    public int exp;
    public int level = 1;
    public Text levelText;
    public Text expText;
    public Text healthText;
    public Image healthBar;
    public GameObject deathWarning;
    public GameObject gameoverMenu;
    public GameObject winMenu;

    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 moveVelocity;
    private bool isFacingRight = true;
    private bool isDefending = false;
    private bool isDead = false;
    private float nextOgreSpawnTime = 0f;
    private float ogreSpawnDelay = 240f; // 4 minutes

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {

        if (isDead) {
            return;
        }

        // Move input
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        // Flip character based on movement direction
        if (moveInput.x < 0 && isFacingRight) {
            Flip();
        } else if (moveInput.x > 0 && !isFacingRight) {
            Flip();
        }

        // Defend input
        if (Input.GetMouseButtonDown(1)) {
            isDefending = true;
        } else if (Input.GetMouseButtonUp(1)) {
            isDefending = false;
        }

        // Attack input
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Attack");
        }

        // Health warning
        if (currentHealth <= maxHealth * 0.15f) {
            deathWarning.SetActive(true);
        } else {
            deathWarning.SetActive(false);
        }
    }

    void FixedUpdate() {
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);
    }

    void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void TakeDamage(int damage) {
        if (!isDefending) {
            currentHealth -= damage;
            healthText.text = "HP: " + currentHealth.ToString() + "/" + maxHealth.ToString();
            healthBar.fillAmount = (float) currentHealth / (float) maxHealth;

            if (currentHealth <= 0) {
                isDead = true;
                animator.SetTrigger("Death");
                StartCoroutine(GameOver());
            }
        }
    }

    public void Attack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1.5f);

        foreach (Collider2D enemy in hitEnemies) {
            if (enemy.CompareTag("Enemy")) {
                enemy.GetComponent<EnemyController>().TakeDamage(level * 10);
            }
        }
    }

    public void Defend() {
        isDefending = true;
    }

    public void StopDefend() {
        isDefending = false;
    }

    private IEnumerator GameOver() {
        yield return new WaitForSeconds(3);
        gameoverMenu.SetActive(true);
    }

    public void GainExp(int amount) {
        exp += amount;
        expText.text =
