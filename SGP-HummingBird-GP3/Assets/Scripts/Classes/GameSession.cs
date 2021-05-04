using UnityEngine;

[System.Serializable]
public class GameSession : ScriptableObject
{
    #region Attributes

    private int _id;
    private string _username;
    private string _actualDate;
    private float _timeMovingAround;
    private float _timeOfSession;

    #endregion
    
    #region Constructors

    public GameSession()
    {
        _actualDate = CreateDate();
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

    public GameSession(int gsID, string username, string actualDate, float timeMovingAround)
    {
        _id = gsID;
        _username = username;
        _actualDate = actualDate;
        _timeMovingAround = timeMovingAround;
    }

    public GameSession(int gsID, string username, string actualDate, float timeMovingAround, float timeOfSession)
    {
        _id = gsID;
        _username = username;
        _actualDate = actualDate;
        _actualDate = CreateDate();
        _timeMovingAround = timeMovingAround;
        _timeOfSession = timeOfSession;
    }

    #endregion
    
    #region Getters & Setters

    public int GsID
    {
        get => _id;
        set => _id = value;
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

    public float TimeOfSession
    {
        get => _timeOfSession;
        set => _timeOfSession = value;
    }

    #endregion
    
    #region Methods

    private string CreateDate()
    {
        return System.DateTime.Now.Hour + " : " + System.DateTime.Now.Minute + " . "
               + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year +
               ".";
    }

    public override string ToString()
    {
        return _id + ".- username: " + _username + " date of gameplay: " + _actualDate + " has spend: " +
               _timeMovingAround + " moving around.";
    }

    #endregion
}