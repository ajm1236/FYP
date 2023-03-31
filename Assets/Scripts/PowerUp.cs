using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    //abstract class from which other power ups can build off of, can have different target if necessary
    public abstract void Power(GameObject target);

}
