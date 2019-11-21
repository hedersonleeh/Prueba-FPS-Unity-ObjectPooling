using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class movePlayerWithMobile : MonoBehaviour
{
    [SerializeField]private FixedJoystick moveJoyStick;
    [SerializeField]private  FixedTouchField touchField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fps =GetComponent<FirstPersonController>();
        fps.RunAxis = moveJoyStick.Direction;
        fps.m_MouseLook.lookAxis = touchField.TouchDist;
    }
}
