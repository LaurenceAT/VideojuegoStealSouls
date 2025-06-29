using UnityEngine;

public class DeadArea : MonoBehaviour
{
    [SerializeField] private PlayerControler player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;        
        player = other.gameObject.GetComponent<PlayerControler>();
        player.Die();
        GameManager.Instance.RespawnPlayer();
        
    } 
}
