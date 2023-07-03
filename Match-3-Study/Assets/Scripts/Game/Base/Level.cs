using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Level 
{
    public int Number { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int MoveCount { get; set; }
    public string[] Cubes { get; set; }
    public Goal[] Goal{ get; set; }

}
