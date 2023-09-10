using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    private List<Transform> _segments=new List<Transform>();
    public Transform segmentPrefab;
    //  private object scoreText;
    //public int score = 0;
    public int intialsize = 4;

    private ScoreManager scoreManager;
    private bool fingerDown;
    public int pixelDistToDetect = 50;
    private Vector2 startPos;
    //private Vector2 endPos;

    private void Start()
    {
        ResetState();
        //_segments = new List<Transform>();
        //_segments.Add(this.transform);
      
    }
    private void Update()
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown && Input.touchCount > 0)
        {
            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect && _direction != Vector2.down)
            {
                fingerDown = false;
                _direction = Vector2.up;
            }
            else if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect && _direction != Vector2.up)
            {
                fingerDown = false;
                _direction = Vector2.down;
            }
            else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect && _direction != Vector2.right)
            {
                fingerDown = false;
                _direction = Vector2.left;
            }
            else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect && _direction != Vector2.left)
            {
                fingerDown = false;
                _direction = Vector2.right;
            }
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }
        //Check to see if our touch has started
        //if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    startPos = Input.touches[0].position;
        //    fingerDown = true;
        //}

        //if (fingerDown)
        //{
        //    if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        // _direction = Vector2.up;
        //       // Debug.Log("up");
        //    }

        //    else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        //  _direction = Vector2.left;
        //       // Debug.Log("left");
        //    }
        //    else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        // _direction = Vector2.right;
        //       // Debug.Log("right");
        //    }
        //}

        //if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        //{
        //    fingerDown = false;
        //}
        //Check to see if our touch has started
        //if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    startPos = Input.touches[0].position;
        //    fingerDown = true;
        //}

        //if (fingerDown)
        //{
        //    if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect )
        //    {
        //        fingerDown = false;
        //        _direction = Vector2.up;
        //    }
        //    else if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        _direction = Vector2.down;
        //    }
        //    else if (Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        _direction = Vector2.left;
        //    }
        //    else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        _direction = Vector2.right;
        //    }
        //}

        //if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        //{
        //    fingerDown = false;
        //}

        //Testing on PC
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }
        if (fingerDown)
        {
            if (Input.mousePosition.y >= startPos.y + pixelDistToDetect && _direction != Vector2.down)
            {
                fingerDown = false;
                _direction = Vector2.up;

            }
            else if (Input.mousePosition.y <= startPos.y - pixelDistToDetect && _direction != Vector2.up)
            {
                fingerDown = false;
                _direction = Vector2.down;
            }

            else if (Input.mousePosition.x <= startPos.x - pixelDistToDetect && _direction != Vector2.right)
            {
                fingerDown = false;
                _direction = Vector2.left;
            }

            else if (Input.mousePosition.x >= startPos.x + pixelDistToDetect && _direction != Vector2.left)
            {
                fingerDown = false;
                _direction = Vector2.right;
            }

        }
        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }

    }
    private void FixedUpdate()
    {
        for (int i = _segments.Count-1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + _direction.x, Mathf.Round(this.transform.position.y) + _direction.y,0.0f );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);

        // check if there are any segments in the list
        //if (_segments.Count >= 0)
        //{
            segment.position = _segments[_segments.Count - 1].position;
        //}
        //else
        //{
        //    segment.position = this.transform.position;

        //}

        _segments.Add(segment);
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.score += 1; // add 100 points to the score


    }
    private void ResetState()
    {
        _direction = Vector2.zero;

             for (int i = 1; i < _segments.Count; i++)
             {
                Destroy(_segments[i].gameObject);
             }

            _segments.Clear();
            _segments.Add(this.transform);
            for (int i = 1; i < this.intialsize; i++)
            {
                _segments.Add(Instantiate(this.segmentPrefab));
            }
        

             this.transform.position = Vector3.zero;
             ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
             scoreManager.score = 0;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }

}

