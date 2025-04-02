using UnityEngine;

public class BasicEnemy : Enemy {
    private GameObject _player;

    void FixedUpdate() {
        FollowPlayer();
    }

    private void FollowPlayer() {
        Rb.MovePosition(
            Vector3.MoveTowards(
                transform.position,
                _player.transform.position,
                _enemySO._speed * Time.fixedDeltaTime
            )
        );

        Rb.MoveRotation(
            Quaternion.LookRotation(_player.transform.position - transform.position)
        );
    }

    protected override void EnemyStart() {
        // Trouver un objet avec le tag "Player" dans la scène.
        // Notez qu'il est préférable d'utiliser un tag plutôt que de
        // chercher par type, car cela peut être plus coûteux en termes
        // de performance.
        _player = GameObject.FindGameObjectWithTag("Player");
        //_player = FindAnyObjectByType<PlayerController>().gameObject;

        // Si on avait plusieurs joueurs, on pourrait faire comme ça :
        // _players = GameObject.FindGameObjectsWithTag("Player");
    }

    protected override void Die() {
        Destroy(gameObject);
    }
}