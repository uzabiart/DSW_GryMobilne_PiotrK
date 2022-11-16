using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISight
{
    public int zoomRange { get; }

    public void ZoomIn();
}
