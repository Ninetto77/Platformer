using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMoovement player;
    private Shooter shooter;
    private void Awake()
    {
        player = GetComponent<PlayerMoovement>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringsVars.HORIZONTAL_AXIS);
        bool GetJumpButton = Input.GetButtonDown(GlobalStringsVars.JUMP);
        
        player.Move(horizontalDirection, GetJumpButton);

        if (Input.GetButtonDown(GlobalStringsVars.FIRE_1))
        {
            shooter.Shoot();
        }

    }
}
