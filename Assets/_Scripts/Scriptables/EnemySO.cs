using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemy Data")]
public class EnemySO : ScriptableObject
{
    public int _health;
    public float _speed;
    public Color _color;
}
