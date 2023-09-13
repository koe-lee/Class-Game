using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerInput> joinedPlayers = new List<PlayerInput>();
    private PlayerInputManager playerInputManager;
    [SerializeField] private List<Transform> starts;

    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        joinedPlayers.Add(player);

        player.transform.position = starts[joinedPlayers.Count - 1].position;
    }
}
