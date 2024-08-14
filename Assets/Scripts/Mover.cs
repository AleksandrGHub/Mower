using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] public Transform _way;

    private Vector3[] _waypoints;
    public float _speed;
    private int _currentWaypoint = 0;

    private void Start()
    {
        AddWaypoints();
        transform.position = _waypoints[_currentWaypoint];
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint])
        {
            _currentWaypoint = (++_currentWaypoint) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint], _speed * Time.deltaTime);
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