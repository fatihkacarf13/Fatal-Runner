using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecPlayerPowerBar : MonoBehaviour
{
    private Image _secPowerBar;
    public float secCurrentPower;
    //private float _maxPower = 100f;
    public float mButtonDownPower = 0;
    private bool canPowerDown = true;

    void Start()
    {
        _secPowerBar = GetComponent<Image>();

    }

    void Update()
    {

        if (FightLineControl.Instance.bossFight == true)
        {
            if (mButtonDownPower>0)
            {
                if (canPowerDown)
                {

                    StartCoroutine(PowerDownPerSec(0.5f));
                    mButtonDownPower -= 5;

                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                mButtonDownPower += 5;
            }
            secCurrentPower = mButtonDownPower;
            _secPowerBar.fillAmount = secCurrentPower / PlayerPowerBar.Instance.currentPower;

        }
    }

    private IEnumerator PowerDownPerSec(float waitTime)
    {
        canPowerDown = false;
        yield return new WaitForSecondsRealtime(waitTime);
        canPowerDown = true;
    }
}
