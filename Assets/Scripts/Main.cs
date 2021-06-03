using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    #region ========== Variables ========

    public bool canMove { get; set; }
    /// <summary>
    /// Current level to know when to move
    /// </summary>
    public int currentLvl { get; set; }
    public GameObject mainPlayer { get; set; }

    [SerializeField] GameObject _player;
    [SerializeField] Transform _spawnPosition;
    [SerializeField] Transform _playersHealthbar;

    PlayFlowControl _pfControl;

    [SerializeField] [Tooltip("Waypoints for the player")] List<Transform> _wayPoints = new List<Transform>();

    public static Main Instance { get; private set; }

    #endregion ========== Variables ========

    #region ========== Unity-time ========

    private void Awake()
    {
        Instance = this;
        canMove = true;

        _pfControl = GetComponent<PlayFlowControl>();
        _pfControl.enemyCount = 6;

        // Creating a player
        mainPlayer = Instantiate(_player, _spawnPosition.position, _spawnPosition.rotation);
        mainPlayer.GetComponent<Movement>().waypoints = _wayPoints;
    }

    #endregion ========== Unity-time ========

    public PlayFlowControl PlayFlowContr { get { return _pfControl; } }
    public Transform HealthBar { get { return _playersHealthbar; } }
}