using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecPlayerPowerBar : MonoBehaviour
{
    private Image _secPowerBar;
    public float secCurrentPower;
    private float _secMaxPower = 100f;
    public float mButtonDownPower = 0;
    private bool canPowerDown = true;
    private bool _powerLimit = false;

    public static SecPlayerPowerBar Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _secPowerBar = GetComponent<Image>();

    }

    void Update()
    {

        if (FightLineControl.Instance.bossFight == true)
        {
            if (mButtonDownPower > 0 && PlayerPunch.Instance.death == false)
            {
                if (canPowerDown)
                {

                    StartCoroutine(PowerDownPerSec(0.5f));
                    mButtonDownPower -= 5;

                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && !_powerLimit && PlayerPunch.Instance.death == false )
            {
                mButtonDownPower += 5;
            }
            secCurrentPower = mButtonDownPower;
            if (secCurrentPower == PlayerPowerBar.Instance.currentPower)
            {
                _powerLimit = true;
            }
            if (secCurrentPower < PlayerPowerBar.Instance.currentPower)
            {
                _powerLimit = false;
            }
            _secPowerBar.fillAmount = secCurrentPower / _secMaxPower;

        }
    }

    private IEnumerator PowerDownPerSec(float waitTime)
    {
        canPowerDown = false;
        yield return new WaitForSecondsRealtime(waitTime);
        canPowerDown = true;
    }
}
