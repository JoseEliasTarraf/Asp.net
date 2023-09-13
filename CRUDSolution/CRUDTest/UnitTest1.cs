namespace CRUDTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            MyMath mm = new MyMath();
            int input1 = 10, inpt2 = 20;
            int expected = 30;

            //Act
            int actual = mm.Add(input1, inpt2);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}