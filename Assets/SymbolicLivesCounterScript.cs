using UnityEngine;
using System.Collections;

public class SymbolicLivesCounterScript : MonoBehaviour {
    public GameObject[] hearts;
    private int lives;

    // Use this for initialization
    void Start() {
        lives = hearts.Length;
    }

    // Update is called once per frame
    void Update() {

    }

    public bool AddLife() {
        if (lives < hearts.Length) {
            lives++;
            if (lives > 5) lives = 5;
            UpdateSymbolicLivesCounter();
            return true;
        }
        return false;
    }

    public bool LoseLife() {
        lives--;
        if (lives > 0) {
            UpdateSymbolicLivesCounter();
            return false;
        }
        lives = 0;
        UpdateSymbolicLivesCounter();
        return true;
    }

    private void UpdateSymbolicLivesCounter() {
        for (int i = 0; i < hearts.Length; i++) 
            hearts[i].SetActive(i < lives);
    }
}
