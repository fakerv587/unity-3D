using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SceneController
{
    void LoadResources();                                 
    void print();  
    int getPosition(string name); 
    void moveto(string name);
    void Reset();
}
