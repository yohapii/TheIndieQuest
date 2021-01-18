using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public GameObject dogPrefab;
    public float timePassed = 1f;
    private float setTimePassed;

    // Start is called before the first frame update
    void Start() {
        setTimePassed = timePassed;
    }

    // Update is called once per frame
    void Update() {
        // timePassed stuff is for delaying dog to not spawning faster than 1 time per setTimePassed seconds
        if (timePassed > setTimePassed) {
            timePassed = setTimePassed;
        }
        if (timePassed < setTimePassed) {
            timePassed += Time.deltaTime;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timePassed >= setTimePassed) {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timePassed = 0;
        }
    }
}
