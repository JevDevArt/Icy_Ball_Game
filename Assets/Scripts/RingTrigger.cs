using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class RingTrigger : MonoBehaviour
{
    private AudioSource m_AudioSource;
    private Animator animator;
    private Collider2D objectCollider;
    private SpriteRenderer spriteRenderer;
    int value = 1;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        objectCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {

            if (collision.CompareTag("Player"))
            {
                PlayerController player = collision.GetComponentInParent<PlayerController>();
                if (player == null) return;
                player.AddPoints(value);
                objectCollider.enabled = false;
                m_AudioSource.Play();

                StartCoroutine(Delay());
            }
        }
    }

    private IEnumerator Delay()
    {
        animator.Play("ring collected");
        yield return new WaitForSeconds(0.9f);
        Destroy(gameObject);
    }
}