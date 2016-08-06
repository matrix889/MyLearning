using UnityEngine;
using System.Collections;
public class Trail : MonoBehaviour
{
    public WeaponTrail TrailObj;//武器柄的节点
    private float t = 0f;
    private float tempT = 0f;
    private float animationIncrement = 0.003f;
    void Start() { }
    void LateUpdate()
    {
        t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);
        if (t > 0)
        {
            while (tempT < t)
            {
                tempT += animationIncrement;
                if (TrailObj.time > 0)
                {
                    TrailObj.Itterate(Time.time - t + tempT);
                }
                else
                {
                    TrailObj.ClearTrail();
                }
            }
            tempT -= t;
            if (TrailObj.time > 0)
            {
                TrailObj.UpdateTrail(Time.time, t);
            }
        }
    }
}