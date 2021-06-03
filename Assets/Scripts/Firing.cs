using UnityEngine;

public class Firing : MonoBehaviour
{
    #region ========== Variables ========

    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _barrel;
    [SerializeField] float _bulletSpeed = 1;

    Animator _anim;

    #endregion ========== Variables ========

    #region ========== Unity-time ========

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Main.Instance.canMove)
        {
            // Rotating player
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                transform.LookAt(hit.point);

            // Launch the animation
            _anim.SetTrigger("Fire");

            // Shooting
            GameObject bullet = Instantiate(_bullet, _barrel.position, _barrel.rotation);

            bullet.GetComponent<Rigidbody>().AddForce(0, _bulletSpeed, 0);
        }
    }

    #endregion ========== Unity-time ========
}