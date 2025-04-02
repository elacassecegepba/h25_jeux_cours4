using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Classe responsable de la gestion du joueur.
/// Gère le déplacement, la rotation et le tir du joueur.
/// Doit être attachée au GameObject du joueur.
/// Utilise un Rigidbody pour le déplacement.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CursorHover))]
public class PlayerController : MonoBehaviour {
    private Rigidbody _rb;
    private Vector3 _movement = Vector3.zero;
    private bool _isAttacking = false;
    [SerializeField] private int _moveSpeedPerSecond = 40;
    [SerializeField] private float _fireDelayInSeconds = 0.1f;
    private float _delayInSecondsBeforeNextFire = 0;
    [SerializeField] private GameObject _bulletContainer;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    private CursorHover _cursorHover;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        _cursorHover = GetComponent<CursorHover>();
    }

    void Update() {
        ProcessFire();
    }

    void FixedUpdate() {
        Move();
        OrientatePlayer();
    }

    void OnMove(InputValue value) {
        Vector2 input = value.Get<Vector2>();
        _movement.x = input.x;
        _movement.z = input.y;
    }

    void OnAttack(InputValue value) {
        _isAttacking = value.isPressed;
    }

    private void ProcessFire() {
        _delayInSecondsBeforeNextFire -= Time.deltaTime;

        if (_isAttacking  && _delayInSecondsBeforeNextFire <= 0) {
            ShootBullet();
            _delayInSecondsBeforeNextFire = _fireDelayInSeconds;
        }
    }

    private void ShootBullet() {
        GameObject bullet = Instantiate(
            _bulletPrefab,
            _bulletSpawnPoint.position,
            _bulletSpawnPoint.rotation,
            _bulletContainer.transform
        );
    }

    private void Move() {
        Vector3 distance =
            _moveSpeedPerSecond *
            Time.fixedDeltaTime *
            _movement;

        _rb.MovePosition(_rb.position + distance);
    }

    private void OrientatePlayer() {
        if(!_cursorHover.IsHovering) { return; }

        Vector3 directionVector = new Vector3(
            _cursorHover.Position.x,
            _rb.position.y,
            _cursorHover.Position.z
        ) - _rb.position;

        Quaternion rotation = Quaternion.LookRotation(
            directionVector,
            Vector3.up
        );

        _rb.MoveRotation(rotation);
    }
}
