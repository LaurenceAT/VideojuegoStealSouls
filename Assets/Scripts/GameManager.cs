using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Settings")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerRespawnPoint;
    [SerializeField] private float respawnPlayerDelay;
    [SerializeField] private PlayerControler playerControler;
    public PlayerControler PlayerControler => playerControler;

    [Header("Coin Manager")] 
    [SerializeField] private int _coincollected;
    [SerializeField] private bool coinHaveRandomLook;   
    public int Coincollected => _coincollected;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }


    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCoroutine());
    }

    IEnumerator RespawnPlayerCoroutine()
    {
        yield return new WaitForSeconds(respawnPlayerDelay);
        GameObject newPlayer = Instantiate(playerPrefab, playerRespawnPoint.position, Quaternion.identity);
        newPlayer.name = "Player";
        playerControler = newPlayer.GetComponent<PlayerControler>();

    }

    public void AddCoin() => _coincollected++;
    public bool CoinHaveRandomLook() => coinHaveRandomLook;
}
