using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemySpee
{
    [Test]
    public void EnemySpeeSimplePasses()
    {
        var enemy = new GameObject().AddComponent<EnemyMove>();
        var speed = 12;

        Assert.AreEqual(speed, enemy.speed, 0.1f);
    }

}
