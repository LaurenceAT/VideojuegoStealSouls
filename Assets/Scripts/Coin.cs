using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody2D m_rigitbody2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private CoinType coinType;
    private int idCoinIndex;

    private void Awake()
    {
        m_rigitbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        idCoinIndex = Animator.StringToHash("coinIndex");
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        SetRandomCOin();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
            spriteRenderer.enabled = false;
            m_rigitbody2D.simulated = false;
            gameManager.AddCoin();
    }

    private void SetRandomCOin()
    {
        if (!GameManager.Instance.CoinHaveRandomLook())
        {
            UpdateCoinType();
            return;
        }
        var randomCoinIndex = Random.Range(0, 8);
        animator.SetFloat(idCoinIndex, randomCoinIndex);
    }

    private void UpdateCoinType()
    {
        animator.SetFloat(idCoinIndex, (int)coinType);
    }
}
