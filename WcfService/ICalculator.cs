using System.Net.Security;
using System.ServiceModel;

namespace WcfService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract(ProtectionLevel = ProtectionLevel.None)]
    public interface ICalculator
    {
        [OperationContract]
        int iAdd(int val1, int val2);
        [OperationContract]
        int iSub(int val1, int val2);
        [OperationContract]
        int iMul(int val1, int val2);
        [OperationContract]
        int iDiv(int val1, int val2);
        [OperationContract]
        int iMod(int val1, int val2);
        [OperationContract]
        int HMultiply(int val1, int val2);
        [OperationContract]
        (int, int) CountAndMaxPrimesInRange(int val1, int val2);

    }

}
