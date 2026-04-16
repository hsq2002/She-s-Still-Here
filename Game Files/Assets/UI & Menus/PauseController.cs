using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This program helps pause the game. 
// As far as I know, this will be helpful for:
// - Pausing player movement
// - Pausing enemy movement
// Whenever:
// - The player pauses the game
// - Player dies or hasn't started the game yet
// - Player wins
// - Player is reading an item
public class PauseController : MonoBehaviour
{
    public static bool isGamePaused { get; private set; } = false;

    public static void SetPause(bool paused)
    {
        isGamePaused = paused;
    }
}
