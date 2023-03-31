using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    public int playerLevel = 1;
    public int playerExp = 0;
    public int expToNextLevel = 100;

    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Show the main menu
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if game is over
        if (isGameOver)
        {
            return;
        }

        // Check for player death
        if (player.GetComponent<PlayerController>().isDead)
        {
            GameOver();
        }
    }

    // Enemy defeated callback function
    public void EnemyDefeated(int exp)
    {
        playerExp += exp;

        // Check for level up
        if (playerExp >= expToNextLevel)
        {
            playerLevel++;
            playerExp -= expToNextLevel;
            expToNextLevel *= 2;
        }
    }

    // Show the main menu
    private void ShowMainMenu()
    {
        // TODO: Implement main menu UI
        Debug.Log("Main menu");
    }

    // Start the game
    public void StartGame()
    {
        // TODO: Hide main menu UI
        Debug.Log("Starting game");

        // Reset player stats
        playerLevel = 1;
        playerExp = 0;
        expToNextLevel = 100;

        // Spawn player and enemies
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i], new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), Quaternion.identity);
        }
    }

    // End the game
    private void GameOver()
    {
        // TODO: Implement game over UI
        Debug.Log("Game over");

        // Set game over flag
        isGameOver = true;
    }
}
