using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject winText;
    public GameObject loseText;
    public Text levelText;
    public Text expText;
    public Text healthText;
    public Text damageText;
    public Text nameText;
    public int maxEnemies;
    public float spawnInterval;
    public float enemySpeed;
    public float detectionRange;
    public int enemyHealth;
    public int playerHealth;
    public int playerDamage;
    public int exp;
    public int level;
    public string playerName;
    private int enemyCount;
    private float lastSpawnTime;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + level.ToString();
        expText.text = "Exp: " + exp.ToString();
        healthText.text = "Health: " + playerHealth.ToString();
        damageText.text = "Damage: " + playerDamage.ToString();
        nameText.text = playerName;
        winText.SetActive(false);
        loseText.SetActive(false);
        isGameOver = false;
        enemyCount = 0;
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (Time.time - lastSpawnTime > spawnInterval && enemyCount < maxEnemies)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Defend();
        }

        UpdateUI();
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy);
        EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
        enemyController.speed = enemySpeed;
        enemyController.detectionRange = detectionRange;
        enemyController.health = enemyHealth;
        enemyCount++;
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.transform.position, detectionRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                enemyController.TakeDamage(playerDamage);
            }
        }
    }

    void Defend()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.transform.position, detectionRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                playerHealth -= enemyController.damage;
                if (playerHealth <= 0)
                {
                    GameOver(false);
                }
            }
        }
    }

    void UpdateUI()
    {
        levelText.text = "Level: " + level.ToString();
        expText.text = "Exp: " + exp.ToString();
        healthText.text = "Health: " + playerHealth.ToString();
        damageText.text = "Damage: " + playerDamage.ToString();
        nameText.text = playerName;
    }

    public void AddExp(int amount)
    {
        exp += amount;
        if (exp >= 100 * Mathf.Pow(2, level - 1))
        {
            level++;
            exp = 0;
            playerDamage++;
            playerHealth += 10;
        }
    }

    public void GameOver(bool win)
    {
       
