using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
    public Player player;

    void OnGUI() {
        // Make a background box
        GUI.Box(new Rect(10, 10, 100, 40), "Coins: " + player.getCoins());
    }
}
