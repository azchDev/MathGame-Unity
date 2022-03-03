using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sum
{
    private int x;
    private int y;
    private int r;
    private string str;
    public Sum(int max)
    {
        this.x = Random.Range(0, max);
        this.y = Random.Range(0, max);
        this.r = this.x + this.y;
        this.str = $"{this.x} + {this.y}";
    }

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public int R { get => r; set => r = value; }
    public string Str { get => str; set => str = value; }
}
