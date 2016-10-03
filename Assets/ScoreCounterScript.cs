using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterScript : MonoBehaviour {
    private Text uiText;
    private static int loop = 0;

    // Use this for initialization
    void Start() {
        uiText = this.GetComponent<Text>();
        UpdateScoreCounter();
    }

    public void AddPoints(int points) {
        Score += points;
        UpdateScoreCounter();
    }

    public void RemovePoints(int points) {
        Score -= points;
        if (Score < 0) Score = 0;
        UpdateScoreCounter();
    }

    public long Score { get; private set; }

    private void UpdateScoreCounter() {
        uiText.text = string.Format("<b><color=red>Score</color></b>: {0}", Score);
        if (Score % 10 == 0) {
            var livesCounter = GameObject.Find("SymbolicLivesCounter");
            if (livesCounter != null) {
                var script = livesCounter.GetComponent<SymbolicLivesCounterScript>();
                if (script != null) {
                    if (Score == 0) script.LoseLife(); else script.AddLife();
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (Time.deltaTime > 0) {
            loop++;
            loop %= 100;
            if (loop == 0) AddPoints(5);
            if (loop % 30 == 0) RemovePoints(1);
        }
    }
}
