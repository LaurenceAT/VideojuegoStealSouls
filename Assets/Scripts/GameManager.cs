using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlayerControler _playerControler;
    [Header("Coin Manager")]
    [SerializeField] private bool coinHaveRandomLook;

    public PlayerControler PlayerControler { get => _playerControler;}

    [SerializeField] private int _coincollected;
    public int Coincollected { get => _coincollected;}

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddCoin() => _coincollected++;
    public bool CoinHaveRandomLook() => coinHaveRandomLook;
}
