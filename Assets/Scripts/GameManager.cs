using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]private PlayerControler _playerControler;

    public PlayerControler PlayerControler { get => _playerControler;}

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddScore()
    {
        Debug.Log("Added Score");
    }
}
