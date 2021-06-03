using UnityEngine;

public class Firing : MonoBehaviour
{
    #region ========== Variables ========

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

            if(Physics.Raycast(ray, out hit))
            {
                Instantiate(Main.Instance.effect, hit.point, Quaternion.identity);
            }

            //transform.rotation = Quaternion.FromToRotation(transform.position, hit.point);

            // Launch the animation
            _anim.SetTrigger("Fire");
        }
    }

    #endregion ========== Unity-time ========
}