using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHP = 100;
    [SerializeField] int _deathTime = 2;

    int _curHP;

    private void Awake()
    {
        _curHP = _maxHP;
    }

    private void Update()
    {
        if (_curHP <= 0)
            Death();
    }

    public void TakeDamage(int dmg)
    {
        _curHP -= dmg;
    }

    void Death()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, _deathTime);
        Main.Instance.PlayFlowContr.enemyCount--;
    }
}