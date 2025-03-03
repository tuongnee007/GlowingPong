using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1);//Xóa đối tượng sau 1s
    }
}
