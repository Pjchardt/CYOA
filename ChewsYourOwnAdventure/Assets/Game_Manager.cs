using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour
{
    static Game_Manager Instance;

    void Awake()
    {
        Instance = this;
    }
    

}
