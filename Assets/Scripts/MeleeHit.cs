using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] int _damage = 35;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.GetComponent<Health>() != null)
        {
            coll.transform.GetComponent<Health>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}