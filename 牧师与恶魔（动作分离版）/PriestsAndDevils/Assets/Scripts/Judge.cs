using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public int check(int fromPriestNum, int fromDevilNum, int toPriestNum, int toDevilNum, int boatnum){
        if ((fromPriestNum != 0 && fromDevilNum > fromPriestNum) || (toPriestNum != 0 && toDevilNum > toPriestNum)){
            return -1;
        }
        if (toDevilNum+toPriestNum == 6 && boatnum == 0){
            return 1;
        }
        return 0;
    }
}
