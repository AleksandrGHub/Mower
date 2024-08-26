using UnityEngine;

public class PathPointer : MonoBehaviour
{
    [SerializeField] public Transform _way;

    private Vector3[] _waypoints;
    public float _speed;
    private int _currentNumberWaypoint = 0;

    private void Start()
    {
        AddWaypoints();
        transform.position = _waypoints[_currentNumberWaypoint];
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentNumberWaypoint])
        {
            _currentNumberWaypoint = (++_currentNumberWaypoint) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentNumberWaypoint], _speed * Time.deltaTime);
    }

    private void AddWaypoints()
    {
        _waypoints = new Vector3[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
        {
            _waypoints[i] = _way.GetChild(i).position;
        }
    }
}