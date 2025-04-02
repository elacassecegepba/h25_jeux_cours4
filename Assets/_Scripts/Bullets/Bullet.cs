using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    private Rigidbody _rb;
    private float _timeLeftToLiveInSeconds;
    [SerializeField] private int _lifeSpanInSeconds = 3;
    [SerializeField] private int _moveSpeedPerSecond = 42;
    [SerializeField] private int _damage = 1;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        _timeLeftToLiveInSeconds = _lifeSpanInSeconds;
    }

    void FixedUpdate() {
        Move();
        ApplyLifeSpan();
    }

    private void Move() {
        _rb.MovePosition(
            transform.position + _moveSpeedPerSecond * Time.fixedDeltaTime * transform.forward
        );
    }

    private void ApplyLifeSpan() {
        _timeLeftToLiveInSeconds -= Time.fixedDeltaTime;
        if (_timeLeftToLiveInSeconds <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}