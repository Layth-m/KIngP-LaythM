using UnityEngine;

[CreateAssetMenu(fileName = "Pins", menuName = "Scriptable Objects/Pins", order = 1)]
public class Pins : ScriptableObject
{
    public pin[] pins;
    public int getCount()
    {
        return pins.Length;

    }

    public pin getPin(int index)
    {
        return pins[index];
    }
}
