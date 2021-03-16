using System;
using Beispiel.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beispiel.BLTest
{
  [TestClass]
  public class ConsumerTest
  {
    [TestMethod]
    public void FullNameTestValid()
    {
      //-- Arrange
      Consumer Consumer = new Consumer
      {
        FirstName = "Vasile",
        LastName = "Pop"
      };
      string expected = "Pop, Vasile";

      //-- Act
      string actual = Consumer.FullName;

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FullNameFirstNameEmpty()
    {
      //-- Arrange
      Consumer Consumer = new Consumer
      {
        LastName = "Pop"
      };
      string expected = "Pop";

      //-- Act
      string actual = Consumer.FullName;

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FullNameLastNameEmpty()
    {
      //-- Arrange
      Consumer Consumer = new Consumer
      {
        FirstName = "Vasile"
      };
      string expected = "Vasile";

      //-- Act
      string actual = Consumer.FullName;

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void StaticTest()
    {
      //-- Arrange
      var c1 = new Consumer();
      c1.FirstName = "Vasile";
      Consumer.InstanceCount += 1;

      var c2 = new Consumer();
      c2.FirstName = "Marcel";
      Consumer.InstanceCount += 1;

      var c3 = new Consumer();
      c3.FirstName = "Viorica";
      Consumer.InstanceCount += 1;

      //-- Act

      //-- Assert
      Assert.AreEqual(3, Consumer.InstanceCount);
    }

    [TestMethod]
    public void ValidateValid()
    {
      //-- Arrange
      var Consumer = new Consumer
      {
        FirstName = "Vasile",
        LastName = "Pop",
        EmailAddress = "fPop@hobbiton.me"
      };

      var expected = true;

      //-- Act
      var actual = Consumer.Validate();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ValidateMissingLastName()
    {
      //-- Arrange
      var Consumer = new Consumer
      {
        EmailAddress = "fPop@hobbiton.me"
      };

      var expected = false;

      //-- Act
      var actual = Consumer.Validate();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

  }
}
