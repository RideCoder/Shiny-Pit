using UnityEngine;
using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAI))]
public class Enemy : MonoBehaviour
{
    public Health Health { get; private set; }
    public EnemyMovement EnemyMovement { get; private set; }
    public EnemyAI EnemyAI { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Health = GetComponent<Health>();
        EnemyMovement = GetComponent<EnemyMovement>();
        EnemyAI = GetComponent<EnemyAI>();
    }
    void Start()
    {
        Health.OnDamage += Damaged;
        Health.OnDeath += Died;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Damaged(float damage)
    {
        Debug.Log("Damaged");
        DamageNumberManager.ShowDamage(transform.position, damage);
    }

    private void Died()
    {
        Destroy(gameObject);
    }
}
