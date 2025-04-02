using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour, IDamageable {
    [SerializeField] private Renderer _body;
    protected EnemySO _enemySO;
    private int _currentLife;
    private Rigidbody _rb;

    protected Rigidbody Rb {
        get { return _rb; }
    }

    void Start() {
        _rb = GetComponent<Rigidbody>();
        EnemyStart();
    }

    public void Init(EnemySO enemySO)
    {
        _enemySO = enemySO;
        _body.material.color = enemySO._color;
        _currentLife = _enemySO._health;
    }

    protected abstract void EnemyStart();

    protected abstract void Die();

    public void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            Die();
        }
    }
}