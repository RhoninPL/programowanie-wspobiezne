namespace Programowanie.Wspolbiezne.WCF
{
    public class HelloWorld : IHelloWorld
    {
        #region Implementation of IHelloWorld

        public string Hello()
        {
            return "Hello World";
        }

        #endregion
    }
}