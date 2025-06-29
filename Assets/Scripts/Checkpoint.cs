using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isActive;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive) return;
        if (other.CompareTag("Player")) ActiveCheckpoint();
        GameManager.Instance.hasCheckPointActive = true;
        GameManager.Instance.checkpointRespawnPosition = transform.position;

    }

    private void ActiveCheckpoint()
    {
        isActive = true;
        animator.SetTrigger("isActive");
    }
}
