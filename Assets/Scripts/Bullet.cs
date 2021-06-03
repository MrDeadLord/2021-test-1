using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region ========== Variables ========

    [SerializeField] float _speed;
    [SerializeField] float _dieTime = 2;
    [SerializeField] [Range(0, 100)] int _damage = 35;

    Rigidbody _rb;

    #endregion ========== Variables ========

    #region ========== Unity-time ========

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.AddForce(transform.up * _speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, _dieTime);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.GetComponent<Health>() != null)
            coll.transform.GetComponent<Health>().TakeDamage(_damage);
    }

    #endregion ========== Unity-time ========
}
