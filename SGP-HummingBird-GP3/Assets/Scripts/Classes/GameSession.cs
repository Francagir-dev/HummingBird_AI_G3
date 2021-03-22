using UnityEngine;

[System.Serializable]
public class GameSession : MonoBehaviour
{
    #region Attributes

    private int _gsID;
    private string _username;
    private string _actualDate;
    private float _timeMovingAround;

    #endregion

    #region Getters & Setters

    public int GsID
    {
        get => _gsID;
        set => _gsID = value;
    }

    public string Username
    {
        get => _username;
        set => _username = value;
    }

    public string ActualDate
    {
        get => _actualDate;
        set => _actualDate = value;
    }

    public float TimeMovingAround
    {
        get => _timeMovingAround;
        set => _timeMovingAround = value;
    }

    #endregion

    #region Constructors

    public GameSession()
    {
    }

    public GameSession(string username)
    {
        _username = username;
        _actualDate = CreateDate();
    }

    public GameSession(float timeMovingAround)
    {
        _timeMovingAround = timeMovingAround;
        _actualDate = CreateDate();
    }

    public GameSession(string username, float timeMovingAround)
    {
        _username = username;
        _actualDate = CreateDate();
        _timeMovingAround = timeMovingAround;
    }

    private string CreateDate()
    {
        return System.DateTime.Now.Hour + " : " + System.DateTime.Now.Minute + " . "
               + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year +
               ".";
    }

    #endregion
}