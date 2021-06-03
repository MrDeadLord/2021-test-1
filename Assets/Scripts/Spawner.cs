using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region ========== Variables ========

    // Positions of 3 levels and count of how many to spawn
    [SerializeField] Transform[] _positions0;
    [SerializeField] int _count0;
    [SerializeField] Transform[] _positions1;
    [SerializeField] int _count1;
    [SerializeField] Transform[] _positions2;
    [SerializeField] int _count2;

    [SerializeField] GameObject _enemy;

    #endregion ========== Variables ========

    #region ========== Unity-time ========

    private void Start()
    {
        Spawn(_positions0, _count0);
        Spawn(_positions1, _count1);
        Spawn(_positions2, _count2);
    }

    #endregion ========== Unity-time ========

    #region ========== Methods ========

    void Spawn(Transform[] pos, int count)
    {
        int rand = Random.Range(0, pos.Length);
        
        for (int i = 0; i < count; i++)
        {
            do
            {
                rand = Random.Range(0, pos.Length);
            } while (pos[rand] == null);

            Instantiate(_enemy, pos[rand].position, pos[rand].rotation);
            pos[rand] = null;
        }
    }

    #endregion ========== Methods ========
}