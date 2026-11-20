using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private PlayerController player;
    [SerializeField] private TMP_Text ScoreText; private bool collected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        PlayerController player =
            other.GetComponentInParent<PlayerController>();

        if (player == null) return;

        collected = true;
        player.AddPoints(value);
        Destroy(gameObject);
    }
 
    private void Update()
    {
        if (player == null || ScoreText == null) return;
        ScoreText.text = "Points: " + player.GetPoints();
    }
}
