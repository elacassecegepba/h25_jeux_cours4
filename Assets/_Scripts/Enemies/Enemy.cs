using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour {
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

    protected abstract void EnemyStart();

    protected abstract void Die();
}