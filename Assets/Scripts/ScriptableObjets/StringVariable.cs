using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new" + nameof(StringVariable), menuName = ScriptableUtils.VARIABLE_PATH + nameof(StringVariable))]
public class StringVariable : BaseVariable<string>
{

}
