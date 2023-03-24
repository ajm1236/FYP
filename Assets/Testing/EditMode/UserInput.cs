using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UserInput
{
    // A Test behaves as an ordinary method
    [Test]
    public void UserInputSimplePasses()
    {
        GameObject player = Resources.Load<GameObject>("Player");
        Assert.That(player.GetComponent<PlayerInfo>().playerStatus.currentHealth, Is.EqualTo(1f));
        player.GetComponent<PlayerInfo>().HitPlayer(0.7f);
        Assert.That(player.GetComponent<PlayerInfo>().playerStatus.currentHealth, Is.EqualTo(0.3f));
    }

}
