using UnityEngine;
using System.Collections;

public class Account
{
    public int accountId { get; set; }
    public string strategy { get; set; }
    public string target { get; set; }
    public string segment { get; set; }
    public string customerPriority { get; set; }
    public string businessDriver { get; set; }
    public int avatarId { get; set; }
    public string nickName { get; set; }
    public string id { get; set; }
    public string fax { get; set; }
    public string name { get; set; }
    public string phone { get; set; }
    public string website { get; set; }
    public string accountNumber { get; set; }
    public string sfOwnerId { get; set; }
    public int ownerId { get; set; }
    public Address address { get; set; }
    public int openObjectiveCount { get; set; }
    public Position position { get; set; }
    public Metadata metadata { get; set; }
}

public class Address
{
    public string street { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string postalCode { get; set; }
    public string country { get; set; }
}

public class Position
{
    public int positionId { get; set; }
    public int accountId { get; set; }
    public int contactId { get; set; }
    public int objectiveId { get; set; }
    public int influencerId { get; set; }
    public int eventId { get; set; }
    public int taskId { get; set; }
    public int userId { get; set; }
    public int posX { get; set; }
    public int posY { get; set; }
    public int posZ { get; set; }
    public string avatarStateId { get; set; }
}
public class Metadata
{
    public int createUser { get; set; }
    public int updateUser { get; set; }
    public string createDate { get; set; }
    public string current { get; set; }
    public string updateDate { get; set; }
}


