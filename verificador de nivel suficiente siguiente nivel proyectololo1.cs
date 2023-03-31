using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int requiredLevel = 2; // nivel requerido para avanzar al siguiente nivel

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void CompleteLevel()
    {
        if (player.level >= requiredLevel)
        {
            // El jugador tiene el nivel suficiente para avanzar al siguiente nivel
            // Aquí colocas el código para cargar el siguiente nivel o escena
        }
        else
        {
            Debug.Log("¡No tienes suficiente nivel para avanzar al siguiente nivel!");
            // Aquí puedes agregar una animación o un mensaje en la pantalla para informar al jugador
        }
    }
}
