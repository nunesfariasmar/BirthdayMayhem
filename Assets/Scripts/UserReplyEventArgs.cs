using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserReplyEventArgs : System.EventArgs
{
    public int SenderId { get; }
    public int Choice { get; }

    public UserReplyEventArgs(int senderId, int choice)
    {
        SenderId = senderId;
        Choice = choice;
    }
}
