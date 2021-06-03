using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHP = 100;
    [SerializeField] int _deathTime = 2;
    [SerializeField] Transform _healthUI;

    Rigidbody _rig;
    int _curHP;
    bool _dead = false;
    Vector3 _startScale;

    private void Awake()
    {
        _curHP = _maxHP;
        _rig = GetComponent<Rigidbody>();

        _startScale = _healthUI.localScale;

        if(tag == "Player")        
            _healthUI = Main.Instance.HealthBar;        
    }

    private void Update()
    {
        if (_dead)
            return;

        if (_curHP <= 30 && _rig.isKinematic)
            _rig.isKinematic = false;

        if (_curHP <= 0)
            Death();
    }

    public void TakeDamage(int dmg)
    {
        if (_dead)
            return;

        _curHP -= dmg;
        _healthUI.localScale = new Vector3(_startScale.x, _startScale.y * _curHP * 0.01f, _startScale.z);
    }

    void Death()
    {        
        GetComponent<NavMeshAgent>().enabled = false;
        
        Main.Instance.PlayFlowContr.enemyCount--;

        Destroy(gameObject, _deathTime);

        _dead = true;
    }
}