using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICCable
{
    void applyStun(float duration);
    void applySlow(float duration);
    void applyPoison(float duration);

}
