using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _Tiles;
    [SerializeField] private Transform _PlayerTran;
    [SerializeField] private List<GameObject> _BackTile = new List<GameObject>();
    private float _Xvalu=13.5f;
    private float _tileLenth = 13.5f;
    private float _minasXvalu = 13.5f;
    private int _TileNumber = 5;

    void Start()
    {
        for (int i = 0; i < _TileNumber; i++)
        {
            AddTile(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(-(_Xvalu  - (_TileNumber *_tileLenth)));
        if(_PlayerTran.position.z < -(_Xvalu  - (_TileNumber *_tileLenth)))
        {
            // Debug.Log(_Xvalu  - (_TileNumber *_tileLenth));?
            AddTile2(Random.Range(0,_Tiles.Length));
            RemoveTile();
        }
        
    }

    private void AddTile( int Num)
    {
        Quaternion rotation = Quaternion.Euler(0,  0,-90);
        GameObject tile = Instantiate(_Tiles[Num], new Vector3(0,-1,_Xvalu),rotation,transform);
        _BackTile.Add(tile);
        _Xvalu+=13.5f;
    }
    private void AddTile2( int Num)
    {
        // Debug.Log(Num);
        Quaternion rotation = Quaternion.Euler(0,  0,-90);
        GameObject tile = Instantiate(_Tiles[Num], new Vector3(0,-1,_Xvalu-_minasXvalu),rotation,transform);
        _BackTile.Add(tile);
        _Xvalu+=13.5f;
        _minasXvalu += 13.5f;
    }

    private void RemoveTile()
    {
        Destroy(_BackTile[0]);
        _BackTile.RemoveAt(0);

    }
}
