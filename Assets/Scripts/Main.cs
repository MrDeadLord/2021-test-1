using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    #region ========== Variables ========

    public bool canMove { get; set; }
    public ParticleSystem effect;   // бпелеммн
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPosition;

    [SerializeField] [Tooltip("Waypoints for the player")] List<Transform> _wayPoints = new List<Transform>();

    public static Main Instance { get; private set; }

    #endregion ========== Variables ========

    #region ========== Unity-time ========

    private void Awake()
    {
        Instance = this;
        canMove = true;

        Instantiate(player, spawnPosition.position, spawnPosition.rotation).GetComponent<Movement>().waypoints = _wayPoints;
    }

    #endregion ========== Unity-time ========

    #region ========== Methods ========
    #endregion ========== Methods ========

    #region ========== Publics ========
    #endregion ========== Publics ========
}