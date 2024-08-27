using System.Linq;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] public Transform _way;

    private Vector3[] _waypoints;
    public float _speed;
    private int _currentIndexWaypoint = 0;

    private void Start()
    {
        AddWaypoints();
        transform.position = _waypoints[_currentIndexWaypoint];
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentIndexWaypoint])
        {
            _currentIndexWaypoint = (++_currentIndexWaypoint) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentIndexWaypoint], _speed * Time.deltaTime);
    }

    private void AddWaypoints()
    {
        _waypoints = new Vector3[_way.childCount];

        for (int i = 0; i < _waypoints.Count(); i++)
        {
            _waypoints[i] = _way.GetChild(i).position;
        }
    }
}