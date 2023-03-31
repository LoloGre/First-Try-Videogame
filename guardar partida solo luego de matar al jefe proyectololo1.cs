using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    
    public GameObject ogrePrefab;
    public GameObject bossPrefab;
    public GameObject playerPrefab;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI warningText;
    public GameObject deathWarning;
    public GameObject saveButton;
    public GameObject loadButton;
    public float spawnRange = 20.0f;
    public int maxEnemies = 10;
    public float spawnInterval = 2.0f;
    public float spawnTime = 0.0f;
    public int currentLevel = 1;
    public int currentExperience = 0;
    public int maxExperience = 100;
    public int maxHealth = 100;
    public float currentHealth = 100.0f;
    public float damage = 10.0f;
    public float defense = 0.0f;
    public float attackSpeed = 1.0f;
    public float moveSpeed = 5.0f;
    public bool isDead = false;
    public bool isDefending = false;
    private GameObject player;
    private GameObject boss;
    private bool bossSpawned = false;
    
    // Start is called before the first frame update
    void Start() {
        SpawnPlayer();
        levelText.text = "Level: " + currentLevel.ToString();
        experienceText.text = "Experience: " + currentExperience.ToString() + "/" + maxExperience.ToString();
    }

    // Update is called once per frame
    void Update() {
        if (!isDead) {
            if (Input.GetMouseButtonDown(0)) {
                Attack();
            } else if (Input.GetMouseButtonDown(1)) {
                Defend();
            } else if (Input.GetMouseButtonUp(1)) {
                StopDefending();
            }
            
            if (currentHealth <= maxHealth * 0.15f) {
                deathWarning.SetActive(true);
            } else {
                deathWarning.SetActive(false);
            }
            
            spawnTime += Time.deltaTime;
            if (spawnTime >= spawnInterval && CountEnemies() < maxEnemies) {
                SpawnOgre();
                spawnTime = 0.0f;
            }
            
            if (CountEnemies() == 0 && bossSpawned) {
                saveButton.SetActive(true);
            }
        }
    }
    
    void SpawnPlayer() {
        Vector3 spawnPosition = new Vector3(0, 0.5f, 0);
        player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        player.name = "Campesino";
    }
    
    void SpawnOgre() {
        Vector3 spawnPosition = player.transform.position + Random.insideUnitSphere * spawnRange;
        spawnPosition.y = 0.5f;
        GameObject enemy = Instantiate(ogrePrefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<OgreController>().SetTarget(player);
        enemy.name = "Ogro";
    }
    
    void SpawnBoss() {
        Vector3 spawnPosition = player.transform.position + Random.insideUnitSphere * spawnRange;
        spawnPosition.y = 0.5f;
        boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        boss.GetComponent<BossController>().SetTarget(player);
        boss.name = "Jefe Mago";
        bossSpawned = true;
    }
    
    int CountEnemies() {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    
    void Attack() {
        if (!
