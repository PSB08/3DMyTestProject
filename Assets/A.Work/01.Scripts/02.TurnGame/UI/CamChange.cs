using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public Camera mainCam;
    public Camera[] cams;

    private void Start()
    {
        mainCam.gameObject.SetActive(true);
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].enabled = false;
        }
    }

    public void CameraSetting(int num)
    {
        switch (num)
        {
            case 1:
                cams[0].enabled = true;
                cams[1].enabled = false;
                cams[2].enabled = false;
                cams[3].enabled = false;
                break;
            case 2:
                cams[0].enabled = false;
                cams[1].enabled = true;
                cams[2].enabled = false;
                cams[3].enabled = false;
                break;
            case 3:
                cams[0].enabled = false;
                cams[1].enabled = false;
                cams[2].enabled = true;
                cams[3].enabled = false;
                break;
            case 4:
                cams[0].enabled = false;
                cams[1].enabled = false;
                cams[2].enabled = false;
                cams[3].enabled = true;
                break;
        }
    }

    public void MainCamSet()
    {
        mainCam.enabled = true;
        cams[0].enabled = false;
        cams[1].enabled = false;
        cams[2].enabled = false;
        cams[3].enabled = false;
    }

}
