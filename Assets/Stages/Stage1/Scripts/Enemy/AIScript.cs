using UnityEngine;
using System.Collections;

public abstract class AIScript
{
    public abstract void OnTriggerEnter2D(Collider2D col);
    public abstract void OnTriggerExit2D(Collider2D col);
    public abstract void update();
}
