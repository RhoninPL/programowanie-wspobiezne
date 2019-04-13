using System.ServiceModel;

namespace Programowanie.Wspolbiezne.WCF
{
    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string Hello();
    }
}