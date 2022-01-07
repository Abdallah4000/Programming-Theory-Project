using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Points : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) 
    {
        
        Destroy(gameObject);
        Destroy(other.gameObject);
        DataSaver.instance.TScore ++;
        if(DataSaver.instance.TScore2 < DataSaver.instance.TScore)
        {
            DataSaver.instance.TScore2 = DataSaver.instance.TScore;
        }
     
    }

}
