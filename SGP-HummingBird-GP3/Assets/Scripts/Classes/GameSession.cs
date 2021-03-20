using UnityEngine;

[System.Serializable]
public class GameSession : MonoBehaviour
{
    #region Attributes

    private int gs_id;
    private string username;
    private string actualDate;
    private float timeMovingAround;

    #endregion

    #region Getters & Setters

    public int gsID
    {
        get => gs_id;
        set => gs_id = value;
    }

    public string Username
    {
        get => username;
        set => username = value;
    }

    public string ActualDate
    {
        get => actualDate;
        set => actualDate = value;
    }

    public float TimeMovingAround
    {
        get => timeMovingAround;
        set => timeMovingAround = value;
    }

    #endregion

    #region Constructors

    public GameSession()
    {
    }

    public GameSession(string username)
    {
        this.username = username;
    }

    public GameSession(float timeMovingAround)
    {
        this.timeMovingAround = timeMovingAround;
    }

    public GameSession(string username, float timeMovingAround)
    {
        this.username = username;
        actualDate = System.DateTime.Now.Hour + " : " + System.DateTime.Now.Minute + " . "
                     + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".";
        this.timeMovingAround = timeMovingAround;
    }

    #endregion
}