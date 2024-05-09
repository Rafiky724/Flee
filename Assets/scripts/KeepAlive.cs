using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAlive : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // Mantener este portal entre escenas
        DontDestroyOnLoad(this.gameObject);
    }
}
