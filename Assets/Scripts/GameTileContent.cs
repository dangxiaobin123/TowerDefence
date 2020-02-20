using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTileContentType {
    Empty,
    Destination,
    Wall
}
public class GameTileContent : MonoBehaviour {
    [SerializeField]
    GameTileContentType type = default;

    public GameTileContentType Type { get => type; set => type = value; }
    public GameTileContentFactory OriginFactory {
        get => originFactory;
        set {
            Debug.Assert(originFactory==null, "Redfined origin factory!");
            originFactory = value;
        }
    }

    GameTileContentFactory originFactory;

    public void Recycle() {
        originFactory.Reclaim(this);
    }
}