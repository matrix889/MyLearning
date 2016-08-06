using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

    private Transform _weapon;
    private string _weaponName;

    void Awake()
    {
        _weaponName = "Stone";
    }

	void Start ()
    {
        _weapon = GameObject.Find(_weaponName).transform;
        animation.CrossFade("Idle");
	}
	
	void Update ()
    {
	
	}


    void OnGUI()
    {
        if (GUILayout.Button("Show/Hide _weapon"))
        {
            if (_weapon.renderer.enabled == true)
                _weapon.renderer.enabled = false;
            else
                _weapon.renderer.enabled = true;
        }
        //動作	
        if (GUILayout.Button("Idle"))
        {
            animation.CrossFade("Idle");
        }
        if (GUILayout.Button("Idle2"))
        {
            animation.CrossFade("Idle2");
        }
        if (GUILayout.Button("Walk"))
        {
            _weapon.renderer.enabled = true;
            animation.CrossFade("Walk");
        }
        if (GUILayout.Button("Walk2"))
        {
            _weapon.renderer.enabled = false;
            animation.CrossFade("Walk2");
        }
        if (GUILayout.Button("Run"))
        {
            _weapon.renderer.enabled = true;
            animation.CrossFade("Run");
        }
        if (GUILayout.Button("Run2"))
        {
            _weapon.renderer.enabled = false;
            animation.CrossFade("Run2");
        }
        if (GUILayout.Button("Jump"))
        {
            _weapon.renderer.enabled = true;
            animation.CrossFade("Jump");
        }
        if (GUILayout.Button("Jump2"))
        {
            _weapon.renderer.enabled = false;
            animation.CrossFade("Jump2");
        }
        if (GUILayout.Button("AttackReady"))
        {
            animation.CrossFade("AttackReady");
        }
        if (GUILayout.Button("Attack1"))
        {
            animation.CrossFade("Attack1");
        }
        if (GUILayout.Button("Attack2"))
        {
            animation.CrossFade("Attack2");
        }
        if (GUILayout.Button("Attack3-1"))
        {
            animation.CrossFade("Attack3-1");
        }
        if (GUILayout.Button("Attack3-2"))
        {
            animation.CrossFade("Attack3-2");
        }
        if (GUILayout.Button("Attack3-3"))
        {
            animation.CrossFade("Attack3-3");
        }
        if (GUILayout.Button("Attack4"))
        {
            animation.CrossFade("Attack4");
        }
        if (GUILayout.Button("Wound"))
        {
            animation.CrossFade("Wound");
        }
        if (GUILayout.Button("Stun"))
        {
            animation.CrossFade("Stun");
        }
        if (GUILayout.Button("HitAway"))
        {
            animation.CrossFade("HitAway");
        }
        if (GUILayout.Button("HitAwayUp"))
        {
            animation.CrossFade("HitAwayUp");
        }
        if (GUILayout.Button("Death"))
        {
            animation.CrossFade("Death");
        }
        if (GUILayout.Button("Magic"))
        {
            animation.CrossFade("Magic");
        }
        if (GUILayout.Button("Fire"))
        {
            animation.CrossFade("Fire");
        }
    }

}
