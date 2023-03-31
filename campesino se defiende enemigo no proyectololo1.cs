// en el script enemigo poner 
    
    if (Input.GetMouseButtonDown(1)) {
    // Enemy defend action
}

// en el script del personaje principal poner

    public class PlayerController : MonoBehaviour {

    // ...

    public bool canDefend = true;

    void Update() {
        // ...

        if (Input.GetMouseButtonDown(0)) {
            // Player attack action
        }

        if (canDefend && Input.GetMouseButtonDown(1)) {
            // Player defend action
        }

        // ...
    }

    // ...
}
