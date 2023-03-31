    if (exp >= maxExperience) {
        LevelUp();
    }
}

private void LevelUp() {
    level++;
    exp -= maxExperience;
    maxExperience = (int) (maxExperience * 1.5f);
    maxHealth = (int) (maxHealth * 1.5f);
    currentHealth = maxHealth;
    healthText.text = "HP: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    healthBar.fillAmount = 1f;
    levelText.text = "Level " + level.ToString();
    winMenu.SetActive(true);
}

private void SpawnOgre() {
    GameObject ogre = Instantiate(Resources.Load("Ogre")) as GameObject;
    float x = Random.Range(-8f, 8f);
    float y = Random.Range(-4f, 4f);
    ogre.transform.position = new Vector2(x, y);
}

private void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, 1.5f);
}
