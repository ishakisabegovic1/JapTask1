namespace DateTests
{
  [TestFixture]
  public class Tests
  {
    Calculator calc = new Calculator();

    [Test]
    public void TestDatePositive()
    {
      DateTime date = new DateTime(2022, 10, 15, 9, 0, 0);
      int expHours = 23;
      calc.CalculateDates(date, expHours, out DateTime startDate, out DateTime endDate);
      Assert.That(endDate, Is.EqualTo(new DateTime(2022, 10, 17, 16, 0, 0)));
    }

    [Test]
    public void TestDatePositiveSecond()
    {
      DateTime date = new DateTime(2022, 10, 15, 0, 0, 25);
      int expHours = 16;
      calc.CalculateDates(date, expHours, out DateTime startDate, out DateTime endDate);
      Assert.That(endDate, Is.EqualTo(new DateTime(2022, 10, 17, 0, 0, 25)));
    }


    [Test]
    public void TestDateNegative()
    {
      DateTime date = new DateTime(2022, 10, 20);
      int expHours = 24;

      calc.CalculateDates(date, expHours, out DateTime startDate, out DateTime endDate);
      Assert.That(endDate, Is.Not.EqualTo(new DateTime(2022, 10, 25)));

    }

    [Test]
    public void TestDateNegativeSecond()
    {
      DateTime date = new DateTime(1998, 6, 21);
      int expHours = 32;
      calc.CalculateDates(date, expHours, out DateTime startDate, out DateTime endDate);
      Assert.That(endDate, Is.Not.EqualTo(new DateTime(1998, 6, 26)));
    }


  }
}
