using UnityEngine;

public class PlayFlowControl : MonoBehaviour
{
    public int enemyCount { get; set; }

    private void Update()
    {
        switch (Main.Instance.currentLvl)
        {
            case 0:
                if (enemyCount < 6)
                    Main.Instance.canMove = true;
                break;
            case 1:
                if (enemyCount < 4)
                    Main.Instance.canMove = true;
                break;
            case 3:
                if (enemyCount <= 0)
                    Main.Instance.canMove = true;
                break;
            default:
                break;
        }
    }
}