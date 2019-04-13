using System.ServiceModel;

namespace Programowanie.Wspolbiezne.WCF.Klient
{
    [ServiceContract]
    interface IHelloWorld
    {
        [OperationContract]
        string Hello();
    }

}