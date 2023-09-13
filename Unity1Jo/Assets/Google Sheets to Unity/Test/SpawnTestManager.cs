using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTestManager : MonoBehaviour
{
    public static SpawnTestManager Instance;

    public void Awake()
    {
        if (Instance == null) //정적으로 자신을 체크함, null인진
        {
            Instance = this; //이후 자기 자신을 저장함.
        }
    }

    //public List<int> Listindex = new List<int>();
    //public List<int> ListJellyType = new List<int>();
    //public List<int> ListJellyYpos = new List<int>();
    //public List<int> ListJellyAmount = new List<int>();
    //public List<int> ListObstacleType = new List<int>();
    //public List<int> ListObstacle = new List<int>();
    //public List<int> ListGround = new List<int>();

}
