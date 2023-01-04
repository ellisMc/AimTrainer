using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (TimerManager.instance.checksum()) && (!PauseMenu.IsPaused))
        {
            ScoreManager.instance.AccuracyCalc(false);
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                if(target != null)
                {
                    target.Hit();
                }
            }
        }
    }
}
