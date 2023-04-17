using System.Net.Security;
using System.ServiceModel;

namespace WcfClient
{
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
    }
}
