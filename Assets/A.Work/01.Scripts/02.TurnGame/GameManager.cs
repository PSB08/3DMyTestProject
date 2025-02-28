using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Enemy enemy;
    private bool playerTurn = true;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Debug.Log("--게임 시작!--");
        StartTurn();
    }

    void Update()
    {
        if (playerTurn && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    player.MoveToEnemy(enemy);
                    playerTurn = false;
                }
            }
        }
    }

    void StartTurn()
    {
        if (playerTurn)
        {
            Debug.Log("(1)플레이어 턴!");
        }
        else
        {
            Debug.Log("(2)적 턴!");
            StartCoroutine(WaitTime(1));
        }
    }

    private void EnemyAttack()
    {
        enemy.MoveToPlayer(player);
    }

    public void EndPlayerTurn()
    {
        playerTurn = false;
        StartTurn();
    }

    public void EndEnemyTurn()
    {
        playerTurn = true;
        StartTurn();
    }

    private IEnumerator WaitTime(int time)
    {
        yield return new WaitForSeconds(time);
        EnemyAttack();
    }

}
