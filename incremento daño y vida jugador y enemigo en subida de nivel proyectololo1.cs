public float enemyHealthIncreasePercentage = 0.15f;
public float enemyDamageIncreasePercentage = 0.15f;
public float playerHealthIncreasePercentage = 0.12f;
public float playerDamageIncreasePercentage = 0.12f;

// Increase enemy health and damage
foreach (EnemyController enemy in enemies) {
    enemy.currentHealth += Mathf.RoundToInt(enemy.maxHealth * enemyHealthIncreasePercentage);
    enemy.damage += Mathf.RoundToInt(enemy.damage * enemyDamageIncreasePercentage);
}

// Increase player health and damage
player.currentHealth += Mathf.RoundToInt(player.maxHealth * playerHealthIncreasePercentage);
player.damage += Mathf.RoundToInt(player.damage * playerDamageIncreasePercentage);

